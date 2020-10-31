namespace _6800Emulator
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.memoryGridView = new System.Windows.Forms.DataGridView();
            this.c0x00 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x0A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x0B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x0C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x0D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x0E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c0x0F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lblSelectedCell = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtGoTo = new System.Windows.Forms.TextBox();
            this.btnClearMemory = new System.Windows.Forms.Button();
            this.assemblerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlStatus = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtErrorMessages = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtSymbols = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.memoryGridView)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.tabControlStatus.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoryGridView
            // 
            this.memoryGridView.AllowUserToAddRows = false;
            this.memoryGridView.AllowUserToDeleteRows = false;
            this.memoryGridView.AllowUserToResizeColumns = false;
            this.memoryGridView.AllowUserToResizeRows = false;
            this.memoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.memoryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c0x00,
            this.c0x01,
            this.c0x02,
            this.c0x03,
            this.c0x04,
            this.c0x05,
            this.c0x06,
            this.c0x07,
            this.c0x08,
            this.c0x09,
            this.c0x0A,
            this.c0x0B,
            this.c0x0C,
            this.c0x0D,
            this.c0x0E,
            this.c0x0F});
            this.memoryGridView.Location = new System.Drawing.Point(465, 55);
            this.memoryGridView.MultiSelect = false;
            this.memoryGridView.Name = "memoryGridView";
            this.memoryGridView.ReadOnly = true;
            this.memoryGridView.Size = new System.Drawing.Size(363, 486);
            this.memoryGridView.TabIndex = 0;
            // 
            // c0x00
            // 
            this.c0x00.HeaderText = "0x00";
            this.c0x00.Name = "c0x00";
            this.c0x00.ReadOnly = true;
            this.c0x00.Width = 50;
            // 
            // c0x01
            // 
            this.c0x01.HeaderText = "0x01";
            this.c0x01.Name = "c0x01";
            this.c0x01.ReadOnly = true;
            this.c0x01.Width = 50;
            // 
            // c0x02
            // 
            this.c0x02.HeaderText = "0x02";
            this.c0x02.Name = "c0x02";
            this.c0x02.ReadOnly = true;
            this.c0x02.Width = 50;
            // 
            // c0x03
            // 
            this.c0x03.HeaderText = "0x03";
            this.c0x03.Name = "c0x03";
            this.c0x03.ReadOnly = true;
            this.c0x03.Width = 50;
            // 
            // c0x04
            // 
            this.c0x04.HeaderText = "0x04";
            this.c0x04.Name = "c0x04";
            this.c0x04.ReadOnly = true;
            this.c0x04.Width = 50;
            // 
            // c0x05
            // 
            this.c0x05.HeaderText = "0x05";
            this.c0x05.Name = "c0x05";
            this.c0x05.ReadOnly = true;
            this.c0x05.Width = 50;
            // 
            // c0x06
            // 
            this.c0x06.HeaderText = "0x06";
            this.c0x06.Name = "c0x06";
            this.c0x06.ReadOnly = true;
            this.c0x06.Width = 50;
            // 
            // c0x07
            // 
            this.c0x07.HeaderText = "0x07";
            this.c0x07.Name = "c0x07";
            this.c0x07.ReadOnly = true;
            this.c0x07.Width = 50;
            // 
            // c0x08
            // 
            this.c0x08.HeaderText = "0x08";
            this.c0x08.Name = "c0x08";
            this.c0x08.ReadOnly = true;
            this.c0x08.Width = 50;
            // 
            // c0x09
            // 
            this.c0x09.HeaderText = "0x09";
            this.c0x09.Name = "c0x09";
            this.c0x09.ReadOnly = true;
            this.c0x09.Width = 50;
            // 
            // c0x0A
            // 
            this.c0x0A.HeaderText = "0x0A";
            this.c0x0A.Name = "c0x0A";
            this.c0x0A.ReadOnly = true;
            this.c0x0A.Width = 50;
            // 
            // c0x0B
            // 
            this.c0x0B.HeaderText = "0x0B";
            this.c0x0B.Name = "c0x0B";
            this.c0x0B.ReadOnly = true;
            this.c0x0B.Width = 50;
            // 
            // c0x0C
            // 
            this.c0x0C.HeaderText = "0x0C";
            this.c0x0C.Name = "c0x0C";
            this.c0x0C.ReadOnly = true;
            this.c0x0C.Width = 50;
            // 
            // c0x0D
            // 
            this.c0x0D.HeaderText = "0x0D";
            this.c0x0D.Name = "c0x0D";
            this.c0x0D.ReadOnly = true;
            this.c0x0D.Width = 50;
            // 
            // c0x0E
            // 
            this.c0x0E.HeaderText = "0x0E";
            this.c0x0E.Name = "c0x0E";
            this.c0x0E.ReadOnly = true;
            this.c0x0E.Width = 50;
            // 
            // c0x0F
            // 
            this.c0x0F.HeaderText = "0x0F";
            this.c0x0F.Name = "c0x0F";
            this.c0x0F.ReadOnly = true;
            this.c0x0F.Width = 50;
            // 
            // txtSource
            // 
            this.txtSource.AcceptsReturn = true;
            this.txtSource.AcceptsTab = true;
            this.txtSource.Location = new System.Drawing.Point(12, 27);
            this.txtSource.Multiline = true;
            this.txtSource.Name = "txtSource";
            this.txtSource.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSource.Size = new System.Drawing.Size(447, 417);
            this.txtSource.TabIndex = 1;
            this.txtSource.WordWrap = false;
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.assemblerToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(840, 24);
            this.menuStripMain.TabIndex = 2;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.lblSelectedCell});
            this.statusStripMain.Location = new System.Drawing.Point(0, 544);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(840, 22);
            this.statusStripMain.TabIndex = 3;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // lblSelectedCell
            // 
            this.lblSelectedCell.Name = "lblSelectedCell";
            this.lblSelectedCell.Size = new System.Drawing.Size(71, 17);
            this.lblSelectedCell.Text = "0x0000:0x00";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(564, 25);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(151, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Go to address";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtGoTo
            // 
            this.txtGoTo.Location = new System.Drawing.Point(465, 28);
            this.txtGoTo.Name = "txtGoTo";
            this.txtGoTo.Size = new System.Drawing.Size(93, 20);
            this.txtGoTo.TabIndex = 5;
            // 
            // btnClearMemory
            // 
            this.btnClearMemory.Location = new System.Drawing.Point(721, 25);
            this.btnClearMemory.Name = "btnClearMemory";
            this.btnClearMemory.Size = new System.Drawing.Size(107, 23);
            this.btnClearMemory.TabIndex = 6;
            this.btnClearMemory.Text = "Clear memory";
            this.btnClearMemory.UseVisualStyleBackColor = true;
            this.btnClearMemory.Click += new System.EventHandler(this.btnClearMemory_Click);
            // 
            // assemblerToolStripMenuItem
            // 
            this.assemblerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem});
            this.assemblerToolStripMenuItem.Name = "assemblerToolStripMenuItem";
            this.assemblerToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.assemblerToolStripMenuItem.Text = "Assembler";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // tabControlStatus
            // 
            this.tabControlStatus.Controls.Add(this.tabPage1);
            this.tabControlStatus.Controls.Add(this.tabPage2);
            this.tabControlStatus.Location = new System.Drawing.Point(12, 450);
            this.tabControlStatus.Name = "tabControlStatus";
            this.tabControlStatus.SelectedIndex = 0;
            this.tabControlStatus.Size = new System.Drawing.Size(447, 91);
            this.tabControlStatus.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtErrorMessages);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(439, 65);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Errors";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtErrorMessages
            // 
            this.txtErrorMessages.Location = new System.Drawing.Point(0, 1);
            this.txtErrorMessages.Multiline = true;
            this.txtErrorMessages.Name = "txtErrorMessages";
            this.txtErrorMessages.ReadOnly = true;
            this.txtErrorMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrorMessages.Size = new System.Drawing.Size(438, 63);
            this.txtErrorMessages.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtSymbols);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(439, 65);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Symbols";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtSymbols
            // 
            this.txtSymbols.Location = new System.Drawing.Point(0, 1);
            this.txtSymbols.Multiline = true;
            this.txtSymbols.Name = "txtSymbols";
            this.txtSymbols.ReadOnly = true;
            this.txtSymbols.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSymbols.Size = new System.Drawing.Size(438, 63);
            this.txtSymbols.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 566);
            this.Controls.Add(this.tabControlStatus);
            this.Controls.Add(this.btnClearMemory);
            this.Controls.Add(this.txtGoTo);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.memoryGridView);
            this.Controls.Add(this.menuStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripMain;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "6800 Emulator";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memoryGridView)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.tabControlStatus.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView memoryGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x00;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x01;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x02;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x03;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x04;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x05;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x06;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x07;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x08;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x09;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x0A;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x0B;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x0C;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x0D;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x0E;
        private System.Windows.Forms.DataGridViewTextBoxColumn c0x0F;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel lblSelectedCell;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtGoTo;
        private System.Windows.Forms.Button btnClearMemory;
        private System.Windows.Forms.ToolStripMenuItem assemblerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlStatus;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtErrorMessages;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtSymbols;





    }
}

