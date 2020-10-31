using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _6800Emulator
{
    public partial class frmMain : Form
    {
        InstructionDatabase instructionDatabase = null;
        MemoryManager memoryManager = null;

        Assembler assembler = null;

        public frmMain()
        {
            InitializeComponent();

            instructionDatabase = new InstructionDatabase();
            instructionDatabase.buildDatabase();

            memoryManager = new MemoryManager(memoryGridView);

            assembler = new Assembler(instructionDatabase, memoryManager);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            /* temporary to remember how to convert strings to hex in C#
            // Store integer 182
            byte decValue = 0x55;
            // Convert integer 182 as a hex in a string variable
            string hexValue = decValue.ToString("X");
            Console.WriteLine(hexValue);
            */

            memoryManager.clearMemory();
            memoryGridView.CellClick += new DataGridViewCellEventHandler(memoryGridView_CellClick);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void memoryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            refreshSelectedCellLabel();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                string s = txtGoTo.Text.ToUpper();

                if (s.StartsWith("0X"))
                    s = s.Remove(0, 2);

                UInt16 address = Convert.ToUInt16(s, 16);

                selectMemoryGridCellAtAddress(address);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void selectMemoryGridCellAtAddress(UInt16 address)
        {
            if (memoryGridView.CurrentCell != null)
                memoryGridView.CurrentCell.Selected = false;

            memoryGridView.Rows[address / 0x10].Cells[address % 0x10].Selected = true;
            memoryGridView.CurrentCell = memoryGridView.Rows[address / 0x10].Cells[address % 0x10];

            refreshSelectedCellLabel();
        }

        void refreshSelectedCellLabel()
        {
            if (memoryGridView.SelectedCells.Count <= 0)
                return;

            string selectedCell = memoryGridView.Rows[memoryGridView.SelectedCells[0].RowIndex].HeaderCell.Value.ToString().Substring(0, 5);
            selectedCell += memoryGridView.Columns[memoryGridView.SelectedCells[0].ColumnIndex].Name.Substring(4, 1);
            selectedCell += ":" + memoryGridView.SelectedCells[0].Value.ToString();

            lblSelectedCell.Text = selectedCell;
        }

        private void btnClearMemory_Click(object sender, EventArgs e)
        {
            memoryManager.clearMemory();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] lines = txtSource.Lines;

            assembler.assemble(lines);

            txtErrorMessages.Text = "";
            txtSymbols.Text = "";

            for (int i = 0; i < assembler.symbolTable.Count; i++)
            {
                txtSymbols.Text += assembler.symbolTable.ElementAt(i).Key + " = " + assembler.symbolTable.ElementAt(i).Value.ToString("X") + "\r\n";
            }

            for (int i = 0; i < assembler.errorMessages.Count; i++)
            {
                txtErrorMessages.Text += assembler.errorMessages[i] + "\r\n";
            }

            txtErrorMessages.Text += "\r\n";
            txtErrorMessages.Text += "--------------------------------";
            txtErrorMessages.Text += "\r\n";

            txtErrorMessages.Text += "Assembler finished with " + assembler.errorMessages.Count.ToString() + " error(s)\r\n";
        }
    }
}
