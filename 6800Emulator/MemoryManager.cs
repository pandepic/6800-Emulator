using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _6800Emulator
{
    class MemoryManager
    {
        public byte[] memoryArray = new byte[0x10000];

        public DataGridView memoryGridView = null;

        public MemoryManager(DataGridView memoryGridView)
        {
            this.memoryGridView = memoryGridView;
        }

        public void clearMemory()
        {
            for (int i = 0x0000; i < 0x10000; i += 0x01)
            {
                memoryArray[i] = 0x00;
            }

            buildMemoryDataGridView();
        }

        public void setValueAt(UInt16 address, byte value)
        {
            if (address >= memoryArray.Count())
                return;

            memoryArray[address] = value;

            updateMemoryDataGridViewForAddress(address);
        }

        public byte getValueAt(UInt16 address)
        {
            if (address >= memoryArray.Count())
                return 0x0000;

            return memoryArray[address];
        }

        public UInt16 getTwoByteValueAt(UInt16 address)
        {
            if (address >= memoryArray.Count())
                return 0x0000;

            if ((address + 0x0001) >= memoryArray.Count())
                return 0x0000;

            UInt16 value = memoryArray[address];

            value = (UInt16)(value << 8);

            value = (UInt16)(value ^ memoryArray[address + 0x0001]);

            return value;
        }

        public void updateMemoryDataGridViewForAddress(UInt16 address)
        {
            try
            {
                if (memoryGridView == null)
                    return;

                string val = memoryArray[address].ToString("X");

                if (val.Length == 1)
                    val = "0" + val;

                memoryGridView.Rows[address / 0x10].Cells[address % 0x10].Value = "0x" + val;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void buildMemoryDataGridView()
        {
            try
            {
                if (memoryGridView == null)
                    return;

                memoryGridView.Rows.Clear();

                for (int i = 0x0000; i < 0x10000; i += 0x10)
                {
                    string[] thisRow = new string[16];

                    for (int x = 0; x < 16; x++)
                    {
                        string cell = memoryArray[i + x].ToString("X");

                        if (cell.Length == 1)
                            cell = "0" + cell;

                        thisRow[x] = "0x" + cell;
                    }

                    DataGridViewRowHeaderCell header = new DataGridViewRowHeaderCell();
                    string headerText = i.ToString("X");

                    while (headerText.Length < 4)
                        headerText = "0" + headerText;

                    header.Value = "0x" + headerText;

                    memoryGridView.Rows.Add(thisRow);
                    memoryGridView.Rows[memoryGridView.Rows.Count - 1].HeaderCell = header;
                }

                memoryGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
