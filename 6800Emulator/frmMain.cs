using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if the contents of the text window came from a file, see if it has
            // changed. If it has - ask he user if it should be saved first. The
            // file will already be closed because we close it as soon as we
            // finish loading the text control with it

            bool okToProceed = true;

            if (Program.currentlyOpenFileName.Length > 0 && txtSource.TextLength > 0)
            {
                StreamReader reader = new StreamReader(File.Open(Program.currentlyOpenFileName, FileMode.Open, FileAccess.Read));
                if (reader != null)
                {
                    string fileContent = reader.ReadToEnd();
                    reader.Close();

                    if (fileContent != txtSource.Text)
                    {
                        // the content of the file does not match the content of the text box - ask the user
                        // if the file should be saved.

                        DialogResult result = MessageBox.Show("The file content has changed, do you wish to save it?", "File has changed", MessageBoxButtons.YesNoCancel);
                        switch (result)
                        {
                            case DialogResult.Yes:
                                StreamWriter writer = new StreamWriter(File.Open(Program.currentlyOpenFileName, FileMode.OpenOrCreate, FileAccess.Write));
                                if (writer != null)
                                {
                                    writer.Write(txtSource.Text);
                                    writer.Close();
                                }
                                break;
                            case DialogResult.No:
                                break;
                            case DialogResult.Cancel:
                                okToProceed = false;
                                break;
                        }
                    }
                }
            }

            // when we get here either the file content did not change from that originally loaded or there was no file open
            // and okToProceed will still be true.

            if (okToProceed)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                DialogResult result = openFileDialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    StreamReader reader = new StreamReader(File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read));
                    if (reader != null)
                    {
                        Program.currentlyOpenFileName = openFileDialog.FileName;
                        txtSource.Text = reader.ReadToEnd();
                        reader.Close();
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if there is a file open, we already have the file name. If not, we need to ask
            // the user where the file should be saved and what it's name should be.

            if (Program.currentlyOpenFileName.Length > 0)
            {
                StreamWriter writer = new StreamWriter(File.Open(Program.currentlyOpenFileName, FileMode.OpenOrCreate, FileAccess.Write));
                if (writer != null)
                {
                    writer.Write(txtSource.Text);
                    writer.Close();
                }
            }
            else
            {
                // we need to use the SaveFileDialog to get the path and filename to save to.

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                DialogResult result = saveFileDialog.ShowDialog(this);
                saveFileDialog.CheckFileExists = false;

                if (result == DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(File.Open(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write));
                    if (writer != null)
                    {
                        Program.currentlyOpenFileName = saveFileDialog.FileName;
                        writer.Write(txtSource.Text);
                        writer.Close();
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // we need to use the SaveFileDialog to get the path and filename to save to.

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            DialogResult result = saveFileDialog.ShowDialog(this);
            saveFileDialog.CheckFileExists = false;

            if (result == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(File.Open(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write));
                if (writer != null)
                {
                    Program.currentlyOpenFileName = saveFileDialog.FileName;
                    writer.Write(txtSource.Text);
                    writer.Close();
                }
            }
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            // if there is no file open and there is no text in the source window - disable the save button

            if (Program.currentlyOpenFileName.Length == 0 && txtSource.Text.Length == 0)
            {
                saveToolStripMenuItem.Enabled = false;
            }
        }
    }
}
