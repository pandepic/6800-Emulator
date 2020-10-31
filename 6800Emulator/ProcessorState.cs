using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6800Emulator
{
    enum CCRFlag
    {
        HalfCarry,
        InterruptMask,
        Negative,
        Zero,
        Overflow,
        Carry
    }

    class ProcessorState
    {
        Dictionary<CCRFlag, byte> flagBitmasks = new Dictionary<CCRFlag, byte>();

        // conditional code register (H I N Z V C)
        public byte CCR = 0x00;

        // accumulators
        public byte accumulatorA = 0x00;
        public byte accumulatorB = 0x00;

        public UInt16 indexRegister = 0x0000;
        public UInt16 programCounter = 0x0000;
        public UInt16 stackPointer = 0x0000;

        public ProcessorState()
        {
            // initialise CCR flag bitmasks
            flagBitmasks.Add(CCRFlag.HalfCarry      , Convert.ToByte("100000", 2));
            flagBitmasks.Add(CCRFlag.InterruptMask  , Convert.ToByte("010000", 2));
            flagBitmasks.Add(CCRFlag.Negative       , Convert.ToByte("001000", 2));
            flagBitmasks.Add(CCRFlag.Zero           , Convert.ToByte("000100", 2));
            flagBitmasks.Add(CCRFlag.Overflow       , Convert.ToByte("000010", 2));
            flagBitmasks.Add(CCRFlag.Carry          , Convert.ToByte("000001", 2));

            accumulatorA = 0x00;
            accumulatorB = 0x00;

            indexRegister = 0x0000;
            programCounter = 0x0000;
            stackPointer = 0x0000;
        }

        public void incrementProgramCounter()
        {
            programCounter++;
        }

        public void setFlag(CCRFlag flag)
        {
            CCR = (byte)(CCR | flagBitmasks[flag]);
        }

        public void clearFlag(CCRFlag flag)
        {
            CCR = (byte)(CCR ^ flagBitmasks[flag]);
        }

        public bool isFlagSet(CCRFlag flag)
        {
            if ((CCR & flagBitmasks[flag]) != 0)
                return true;

            return false;
        }

        public string getCCRAsString()
        {
            return Convert.ToString(CCR, 2);
        }
    }
}
