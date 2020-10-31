using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6800Emulator
{
    class InstructionDatabase
    {
        // references to the list index of the instruction by operand(byte) or name(string)
        public Dictionary<byte, int> opcodeReference = new Dictionary<byte, int>();
        public Dictionary<string, int> nameReference = new Dictionary<string, int>();

        public List<InstructionInfo> instructionList = new List<InstructionInfo>();

        public InstructionDatabase()
        {

        }

        public void buildDatabase()
        {
            buildInstructionList();

            opcodeReference.Clear();
            nameReference.Clear();

            for (int i = 0; i < instructionList.Count; i++)
            {
                opcodeReference.Add(instructionList[i].opcode, i);

                // add two letters on the end of the name to identify addressing mode
                string addressMode = "";

                switch (instructionList[i].addressingMode)
                {
                    case AddressingMode.Accumulator:
                        addressMode = "AC";
                        break;
                    case AddressingMode.Direct:
                        addressMode = "DI";
                        break;
                    case AddressingMode.Extended:
                        addressMode = "EX";
                        break;
                    case AddressingMode.Immediate:
                        addressMode = "IM";
                        break;
                    case AddressingMode.Indexed:
                        addressMode = "ID";
                        break;
                    case AddressingMode.Inherent:
                        addressMode = "IH";
                        break;
                    case AddressingMode.None:
                        addressMode = "NO";
                        break;
                    case AddressingMode.Relative:
                        addressMode = "RE";
                        break;
                }

                nameReference.Add(instructionList[i].name + addressMode, i);
            }

        }

        public bool isInstruction(string name)
        {
            for (int i = 0; i < instructionList.Count; i++)
                if (instructionList[i].name == name.ToUpper())
                    return true;

            return false;
        }

        public void buildInstructionList()
        {
            instructionList.Clear();

            // Status instructions -Inherent- (0x01 - 0x0F)
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "NOP", 0x01));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "TAP", 0x06));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "TPA", 0x07));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "INX", 0x08));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "DEX", 0x09));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "CLV", 0x0A));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "SEV", 0x0B));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "CLC", 0x0C));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "SEC", 0x0D));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "CLI", 0x0E));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "SEI", 0x0F));

            // Accumulator instructions -Inherent- (0x10 - 0x1B)
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "SBA", 0x10));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "CBA", 0x11));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "TAB", 0x16));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "TBA", 0x17));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "DAA", 0x19));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "ABA", 0x1B));

            // Branch instructions -Relative- (0x20 - 0x2F)
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BRA", 0x20));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BHI", 0x22));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BLS", 0x23));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BCC", 0x24));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BCS", 0x25));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BNE", 0x26));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BEQ", 0x27));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BVC", 0x28));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BVS", 0x29));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BPL", 0x2A));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BMI", 0x2B));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BGE", 0x2C));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BLT", 0x2D));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BGT", 0x2E));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Relative, "BLE", 0x2F));

            // Stack instructions -Inherent- (0x30 - 0x3F)
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "TSX", 0x30));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "INS", 0x31));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "PULA", 0x32));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "PULB", 0x33));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "DES", 0x34));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "TXS", 0x35));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "PSHA", 0x36));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "PSHB", 0x37));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "RTS", 0x39));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "RTI", 0x3B));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "WAI", 0x3E));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "SWI", 0x3F));

            // Accumulator A logical instructions -Inherent- (0x40 - 0x4F)
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "NEGA", 0x40));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "COMA", 0x43));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "LSRA", 0x44));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "RORA", 0x46));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "ASRA", 0x47));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "ASLA", 0x48));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "ROLA", 0x49));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "DECA", 0x4A));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "INCA", 0x4C));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "TSTA", 0x4D));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "CLRA", 0x4F));

            // Accumulator B logical instructions -Inherent- (0x50 - 0x5F)
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "NEGB", 0x50));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "COMB", 0x53));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "LSRB", 0x54));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "RORB", 0x56));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "ASRB", 0x57));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "ASLB", 0x58));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "ROLB", 0x59));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "DECB", 0x5A));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "INCB", 0x5C));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "TSTB", 0x5D));
            instructionList.Add(new InstructionInfo(1, AddressingMode.Inherent, "CLRB", 0x5F));

            // Indexed memory logical instructions -Indexed- (0x60 - 0x6F)
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "NEG", 0x60));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "COM", 0x63));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "LSR", 0x64));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "ROR", 0x66));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "ASR", 0x67));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "ASL", 0x68));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "ROL", 0x69));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "DEC", 0x6A));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "INC", 0x6C));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "TST", 0x6D));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "JMP", 0x6E));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "CLR", 0x6F));

            // Extended memory logical instructions -Extended- (0x70 - 0x7F)
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "NEG", 0x70));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "COM", 0x73));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "LSR", 0x74));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "ROR", 0x76));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "ASR", 0x77));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "ASL", 0x78));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "ROL", 0x79));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "DEC", 0x7A));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "INC", 0x7C));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "TST", 0x7D));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "JMP", 0x7E));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "CLR", 0x7F));

            // Immediate arithmetic instructions A -Immediate- (0x80 - 0x8F)
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "SUBA", 0x80));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "CMPA", 0x81));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "SBCA", 0x82));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "ANDA", 0x84));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "BITA", 0x85));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "LDAA", 0x86));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "EORA", 0x88));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "ADCA", 0x89));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "ORAA", 0x8A));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "ADDA", 0x8B));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Immediate, "CPX", 0x8C));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "BSR", 0x8D));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "LDS", 0x8E));

            // Direct arithmetic instructions A -Direct- (0x90 - 0x9F)
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "SUBA", 0x90));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "CMPA", 0x91));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "SBCA", 0x92));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "ANDA", 0x94));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "BITA", 0x95));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "LDAA", 0x96));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "STAA", 0x97));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "EORA", 0x98));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "ADCA", 0x99));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "ORAA", 0x9A));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "ADDA", 0x9B));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "CPX", 0x9C));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "LDS", 0x9E));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "STS", 0x9F));

            // Indexed arithmetic instructions A -Indexed- (0xA0 - 0xAF)
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "SUBA", 0xA0));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "CMPA", 0xA1));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "SBCA", 0xA2));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "ANDA", 0xA4));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "BITA", 0xA5));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "LDAA", 0xA6));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "STAA", 0xA7));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "EORA", 0xA8));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "ADCA", 0xA9));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "ORAA", 0xAA));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "ADDA", 0xAB));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "CPX", 0xAC));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "JSR", 0xAD));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "LDS", 0xAE));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "STS", 0xAF));

            // Extended arithmetic instructions A -Extended- (0xB0 - 0xBF)
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "SUBA", 0xB0));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "CMPA", 0xB1));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "SBCA", 0xB2));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "ANDA", 0xB4));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "BITA", 0xB5));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "LDAA", 0xB6));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "STAA", 0xB7));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "EORA", 0xB8));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "ADCA", 0xB9));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "ORAA", 0xBA));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "ADDA", 0xBB));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "CPX", 0xBC));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "JSR", 0xBD));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "LDS", 0xBE));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "STS", 0xBF));

            // Immediate arithmetic instructions B -Immediate- (0xC0 - 0xCF)
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "SUBB", 0xC0));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "CMPB", 0xC1));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "SBCB", 0xC2));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "ANDB", 0xC4));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "BITB", 0xC5));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "LDAB", 0xC6));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "EORB", 0xC8));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "ADCB", 0xC9));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "ORAB", 0xCA));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "ADDB", 0xCB));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Immediate, "LDX", 0xCE));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Immediate, "STX", 0xCF));

            // Direct arithmetic instructions B -Direct- (0xD0 - 0xDF)
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "SUBB", 0xD0));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "CMPB", 0xD1));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "SBCB", 0xD2));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "ANDB", 0xD4));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "BITB", 0xD5));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "LDAB", 0xD6));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "STAB", 0xD7));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "EORB", 0xD8));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "ADCB", 0xD9));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "ORAB", 0xDA));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "ADDB", 0xDB));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "LDX", 0xDE));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Direct, "STX", 0xDF));

            // Indexed arithmetic instructions B -Indexed- (0xE0 - 0xEF)
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "SUBB", 0xE0));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "CMPB", 0xE1));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "SBCB", 0xE2));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "ANDB", 0xE4));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "BITB", 0xE5));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "LDAB", 0xE6));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "STAB", 0xE7));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "EORB", 0xE8));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "ADCB", 0xE9));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "ORAB", 0xEA));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "ADDB", 0xEB));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "LDX", 0xEE));
            instructionList.Add(new InstructionInfo(2, AddressingMode.Indexed, "STX", 0xEF));

            // Extended arithmetic instructions B -Extended- (0xF0 - 0xFF)
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "SUBB", 0xF0));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "CMPB", 0xF1));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "SBCB", 0xF2));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "ANDB", 0xF4));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "BITB", 0xF5));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "LDAB", 0xF6));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "STAB", 0xF7));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "EORB", 0xF8));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "ADCB", 0xF9));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "ORAB", 0xFA));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "ADDB", 0xFB));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "LDX", 0xFE));
            instructionList.Add(new InstructionInfo(3, AddressingMode.Extended, "STX", 0xFF));
        }
    }
}
