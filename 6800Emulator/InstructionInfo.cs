using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6800Emulator
{
    enum AddressingMode
    {
        None,
        Inherent,
        Accumulator,
        Immediate,
        Direct,
        Extended,
        Relative,
        Indexed
    }

    class InstructionInfo
    {
        public int dataBits = 0;
        public AddressingMode addressingMode = AddressingMode.None;
        public string name = "";
        public byte opcode = 0x00;

        public InstructionInfo(int dataBits, AddressingMode addressingMode, string name, byte opcode)
        {
            this.dataBits = dataBits;
            this.addressingMode = addressingMode;
            this.name = name;
            this.opcode = opcode;
        }
    }
}
