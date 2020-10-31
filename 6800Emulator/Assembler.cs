using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6800Emulator
{
    class Assembler
    {
        InstructionDatabase instructionDatabase = null;
        MemoryManager memoryManager = null;

        PCalculator calc = new PCalculator();

        public Dictionary<string, UInt16> symbolTable = new Dictionary<string, UInt16>();
        Dictionary<int, InstructionInfo> instructionCache = new Dictionary<int, InstructionInfo>();

        UInt16 programCounter = 0x0000;
        int currentLine = 0;

        public List<string> errorMessages = new List<string>();

        public Assembler(InstructionDatabase instructionDatabase, MemoryManager memoryManager)
        {
            this.instructionDatabase = instructionDatabase;
            this.memoryManager = memoryManager;
        }

        public void assemble(string[] lines)
        {
            symbolTable.Clear();
            errorMessages.Clear();
            memoryManager.clearMemory();
            instructionCache.Clear();

            programCounter = 0x0000;

            string[] source = lines;

            for (int i = 0; i < source.Count(); i++)
            {
                // strip out comments
                if (source[i].IndexOf(";") != -1)
                {
                    source[i] = source[i].Remove(source[i].IndexOf(";"));
                }

                source[i] = source[i].Replace("\t", " ");
            }

            //List<InstructionInfo> instructionsUsed = new List<InstructionInfo>();
            
            firstPass(source);
            secondPass(source);
        }

        // first pass gathers all labels and constants ('symbols') and associates them with hex values
        public void firstPass(string[] source)
        {
            string[] thisLine = null;

            for (int i = 0; i < source.Count(); i++)
            {
                currentLine = i;

                // split the line on spaces
                thisLine = source[i].ToUpper().Split(' ');

                if (thisLine.Count() <= 0)
                    continue;

                // need to get the instruction to determine how much to increase the prog counter
                string opcode = thisLine.Count() >= 2 ? thisLine[1] : "";
                if (opcode.Length > 0 && !opcode.StartsWith(".")) // it is not an assembler directive
                {
                    int instIndex = getInstrIndex(getAddressMode(thisLine), opcode);
                    if (instIndex > -1)
                    {
                        InstructionInfo currentInst = instructionDatabase.instructionList[instIndex];
                        instructionCache.Add(currentLine, currentInst);
                    }
                }

                // line is labelled
                if (! source[i].StartsWith(" "))
                {
                    // is the label the same as an instruction mnemonic
                    if (! instructionDatabase.isInstruction(thisLine[0]))
                    {
                        // is the label already in the symbol table
                        if (! symbolTable.ContainsKey(thisLine[0]))
                        {
                            UInt16 labelAddress = programCounter;

                            if (thisLine.Count() >= 3)

                                // define constant
                                if (thisLine[1] == ".EQU")
                                {
                                    labelAddress = evaluateExpression16(thisLine[2]);
                                }

                            symbolTable.Add(thisLine[0], labelAddress);
                        }
                        else
                        {
                            addErrorMessage(i, "[Symbol] Duplicate label name (" + thisLine[0] + ")");
                        }
                    }
                    else
                    {
                        addErrorMessage(i, "[Symbol] Invalid label name (" + thisLine[0] + ")");
                    }
                }

                int instructionPosition = 1;

                // if there is only  label on the line
                if (instructionPosition >= thisLine.Count())
                    continue;
                
                // if line defines a constant, see above
                if (thisLine[instructionPosition].ToUpper() == ".EQU")
                    continue;

                if (thisLine[instructionPosition].ToUpper() == ".BYTE")
                {
                    // reserve space for variable
                    programCounter++;
                    continue;
                }
                
                

                InstructionInfo instruction;
                if (instructionCache.TryGetValue(currentLine, out instruction))
                    programCounter += (UInt16)instruction.dataBits;
            }
        }

        public void secondPass(string[] source)
        {
            string[] thisLine = null;

            programCounter = 0x0000;

            AddressingMode mode; // addressing mode

            for (int i = 0; i < source.Count(); i++)
            {
                currentLine = i;

                thisLine = source[i].ToUpper().Split(' ');

                string opcode = thisLine.Count() >= 2 ? thisLine[1] : "";
                string strOperand = thisLine.Count() >= 3 ? thisLine[2] : "";

                // initialize byte variable
                if (opcode == ".BYTE")
                {
                    byte value = 0x00;

                    if (thisLine.Count() >= 3)
                    {
                        value = evaluateExpression8(thisLine[2]);
                    }

                    memoryManager.setValueAt(programCounter, value);
                    programCounter++;
                    continue;
                }

                InstructionInfo instruction;
                if (instructionCache.TryGetValue(currentLine, out instruction)) // get the instruction info
                {
                    if (instruction.addressingMode == AddressingMode.Immediate)
                        strOperand = strOperand.Substring(1); // ignore #
                    if (instruction.addressingMode == AddressingMode.Indexed)
                        strOperand = strOperand.Replace(",X", "");

                    // set memory based on how many bytes in the operand
                    switch (instruction.dataBits)
                    {
                        case 1:
                            memoryManager.setValueAt(programCounter++, instruction.opcode);
                            break;
                        case 2:
                            memoryManager.setValueAt(programCounter++, instruction.opcode);
                            memoryManager.setValueAt(programCounter++, evaluateExpression8(strOperand));
                            break;
                        case 3:
                            memoryManager.setValueAt(programCounter++, instruction.opcode);
                            UInt16 operand = evaluateExpression16(strOperand);
                            byte firstByte = (byte)(operand / 0x0100);
                            byte secondByte = (byte)(operand % 0x0100);
                            memoryManager.setValueAt(programCounter++, firstByte);
                            memoryManager.setValueAt(programCounter++, secondByte);
                            break;
                    } 
                }
                
            }
        }

        //private void parseLabel(string[] thisLine, int currentLine)
        //{
        //    // is the label the same as an instruction mnemonic
        //    if (!instructionDatabase.isInstruction(thisLine[0]))
        //    {
        //        // is the label already in the symbol table
        //        if (!symbolTable.ContainsKey(thisLine[0]))
        //        {
        //            UInt16 labelAddress = programCounter;

        //            if (thisLine.Count() >= 3)

        //                // define constant
        //                if (thisLine[1].ToUpper() == ".EQU")
        //                {
        //                    labelAddress = evaluateExpression16(thisLine[2]);
        //                }

        //            symbolTable.Add(thisLine[0].ToUpper(), labelAddress);
        //        }
        //        else
        //        {
        //            addErrorMessage(currentLine, "[Symbol] Duplicate label name (" + thisLine[0] + ")");
        //        }
        //    }
        //    else
        //    {
        //        addErrorMessage(currentLine, "[Symbol] Invalid label name (" + thisLine[0] + ")");
        //    }
        //}

        private int getInstrIndex(AddressingMode mode, string opcode)
        {
            int instIndex;
            string modeIdentifier = "";

            switch (mode)
            {
                case AddressingMode.Accumulator:
                    modeIdentifier = "AC";
                    break;
                case AddressingMode.Direct:
                    modeIdentifier = "DI";
                    break;
                case AddressingMode.Extended:
                    modeIdentifier = "EX";
                    break;
                case AddressingMode.Immediate:
                    modeIdentifier = "IM";
                    break;
                case AddressingMode.Indexed:
                    modeIdentifier = "ID";
                    break;
                case AddressingMode.Inherent:
                    modeIdentifier = "IH";
                    break;
                case AddressingMode.None:
                    modeIdentifier = "NO";
                    break;
                case AddressingMode.Relative:
                    modeIdentifier = "RE";
                    break;
            }


            if (instructionDatabase.nameReference.TryGetValue(opcode + modeIdentifier, out instIndex))
            {
                return instIndex;
            }
            else
            {
                addErrorMessage(currentLine, "[Instruction] invalid opcode (" + opcode + ")");
            }
            return -1;
        }

        private AddressingMode getAddressMode(string[] thisLine)
        {
            AddressingMode mode;
            if (thisLine.Count() == 2) // assume it is inherent
                mode = AddressingMode.Inherent;
            else if (thisLine[2].StartsWith("#")) // immediate
            {
                mode = AddressingMode.Immediate; // "IM";
            }
            else if (thisLine[2].EndsWith(",X", true, null)) //indexed
            {
                mode = AddressingMode.Indexed; // "ID";
            }
            else if (thisLine[2] == "") // inherent
            {
                mode = AddressingMode.Inherent; // "IH";
            }
            else // could be direct, extended or relative
            {
                // read the instruction and determine its possible addressing modes
                var possibleModes = from inst in instructionDatabase.instructionList
                                    where inst.name == thisLine[1].ToUpper()
                                    select inst.addressingMode;

                // if there's only one possible mode
                if (possibleModes.Count() == 1) // probably relative
                {
                    mode = possibleModes.First();
                }
                else // direct or extended
                {
                    UInt16 operand = evaluateExpression16(thisLine[2]);
                    if (operand > 0xFF)
                        mode = AddressingMode.Extended;
                    else mode = AddressingMode.Direct;
                }
            }
            return mode;
        }

        public byte evaluateExpression8(string expression)
        {
            try
            {
                return Convert.ToByte(calc.Calculate(parseExpressionString(expression)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0x00;
            }
        }

        public UInt16 evaluateExpression16(string expression)
        {
            try
            {
                return Convert.ToUInt16(calc.Calculate(parseExpressionString(expression)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0x0000;
            }
        }

        public string parseExpressionString(string expression)
        {
            char[] operators = { '+', '-', '*', '/', '|', '^', '\\', '&' };

            string parsedExpression = expression.Replace("'*'", programCounter.ToString());
            parsedExpression = parsedExpression.Replace(" ", "");

            int temp;

            string[] constants = parsedExpression.Replace("(", "").Replace(")", "").Split(operators);

            for (int i = 0; i < constants.Count(); i++)
            {
                if (constants[i].Length <= 0)
                    continue;

                UInt16 value = 0;

                // hex
                if (constants[i].StartsWith("$"))
                {
                    if (constants[i].Length > 5)
                    {
                        addErrorMessage(currentLine, "[Expression] Hexadecimal value cannot be higher than 16-bit (" + constants[i] + ")");
                        value = 0;
                    }
                    else
                    {
                        try
                        {
                            value = Convert.ToUInt16(constants[i].Substring(1), 16);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            addErrorMessage(currentLine, "[Expression] Invalid hexadecimal value (" + constants[i] + ")");
                            value = 0;
                        }
                    }
                }
                // binary
                else if (constants[i].StartsWith("%"))
                {
                    if (constants[i].Length > 17)
                    {
                        addErrorMessage(currentLine, "[Expression] Binary value cannot be higher than 16-bit (" + constants[i] + ")");
                        value = 0;
                    }
                    else
                    {
                        try
                        {
                            value = Convert.ToUInt16(constants[i].Substring(1), 2);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            addErrorMessage(currentLine, "[Expression] Invalid binary value (" + constants[i] + ")");
                            value = 0;
                        }
                    }
                }
                // ASCII
                else if (constants[i].StartsWith("'") && constants[i].Length == 2)
                {
                    if (constants[i].Length > 2)
                    {
                        addErrorMessage(currentLine, "[Expression] ASCII value cannot be more than 1 character (" + constants[i] + ")");
                        value = 0;
                    }
                    else
                    {
                        try
                        {
                            value = (UInt16)((int)constants[i][1]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            addErrorMessage(currentLine, "[Expression] Invalid ASCII value (" + constants[i] + ")");
                            value = 0;
                        }
                    }
                }
                // decimal
                else if (int.TryParse(constants[i], out temp))
                {
                    if (temp > 65535)
                    {
                        addErrorMessage(currentLine, "[Expression] Decimal value cannot be higher than 65535 (" + constants[i] + ")");
                        value = 0;
                    }
                    else
                    {
                        if (! UInt16.TryParse(constants[i], out value))
                        {
                            addErrorMessage(currentLine, "[Expression] Invalid decimal value (" + constants[i] + ")");
                            value = 0;
                        }
                    }
                }
                // label
                else
                {
                    if (symbolTable.ContainsKey(constants[i]))
                    {
                        value = (UInt16)symbolTable[constants[i]];
                    }
                    else
                    {
                        addErrorMessage(currentLine, "[Expression] Undeclared label name (" + constants[i] + ")");
                        value = 0;
                    }
                }

                parsedExpression = parsedExpression.Replace(constants[i], value.ToString());
            }

            return parsedExpression.Replace("\\", "%");
        }

        public void addErrorMessage(int line, string message)
        {
            errorMessages.Add("Line " + line.ToString() + ": " + message);
        }
    }
}
