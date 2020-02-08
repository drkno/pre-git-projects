namespace TapeTimer
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setGlobalIntervalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iNeedSomebodyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.notJustAnybodyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.youKnowINeedSomeoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heeellllppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.whenIWasYoungerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soMuchYoungerThanTodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNeverNeededAnybodysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpInAnyWayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLengthSec = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTrack = new System.Windows.Forms.TextBox();
            this.textBoxSide = new System.Windows.Forms.TextBox();
            this.textBoxLengthMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBoxSum = new System.Windows.Forms.ListBox();
            this.labelgt = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeViewDisp = new System.Windows.Forms.TreeView();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(249, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setGlobalIntervalMenuItem,
            this.clearMenuItem,
            this.toolStripSeparator3,
            this.exportToExcelToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // setGlobalIntervalMenuItem
            // 
            this.setGlobalIntervalMenuItem.Name = "setGlobalIntervalMenuItem";
            this.setGlobalIntervalMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.setGlobalIntervalMenuItem.Size = new System.Drawing.Size(211, 22);
            this.setGlobalIntervalMenuItem.Text = "Set Global Interval";
            this.setGlobalIntervalMenuItem.Click += new System.EventHandler(this.SetGlobalIntervalMenuItemClick);
            // 
            // clearMenuItem
            // 
            this.clearMenuItem.Name = "clearMenuItem";
            this.clearMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.clearMenuItem.Size = new System.Drawing.Size(211, 22);
            this.clearMenuItem.Text = "Clear";
            this.clearMenuItem.Click += new System.EventHandler(this.ClearMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(208, 6);
            // 
            // exportToExcelToolStripMenuItem
            // 
            this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
            this.exportToExcelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.exportToExcelToolStripMenuItem.Text = "Export";
            this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.ExportToExcelToolStripMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(208, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitMenuItem.Size = new System.Drawing.Size(211, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.iNeedSomebodyToolStripMenuItem,
            this.helpToolStripMenuItem2,
            this.notJustAnybodyToolStripMenuItem,
            this.helpToolStripMenuItem3,
            this.youKnowINeedSomeoneToolStripMenuItem,
            this.heeellllppToolStripMenuItem,
            this.toolStripSeparator1,
            this.whenIWasYoungerToolStripMenuItem,
            this.soMuchYoungerThanTodayToolStripMenuItem,
            this.iNeverNeededAnybodysToolStripMenuItem,
            this.helpInAnyWayToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(228, 22);
            this.helpToolStripMenuItem1.Text = "Help!";
            // 
            // iNeedSomebodyToolStripMenuItem
            // 
            this.iNeedSomebodyToolStripMenuItem.Name = "iNeedSomebodyToolStripMenuItem";
            this.iNeedSomebodyToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.iNeedSomebodyToolStripMenuItem.Text = "I need somebody";
            // 
            // helpToolStripMenuItem2
            // 
            this.helpToolStripMenuItem2.Name = "helpToolStripMenuItem2";
            this.helpToolStripMenuItem2.Size = new System.Drawing.Size(228, 22);
            this.helpToolStripMenuItem2.Text = "Help!";
            // 
            // notJustAnybodyToolStripMenuItem
            // 
            this.notJustAnybodyToolStripMenuItem.Name = "notJustAnybodyToolStripMenuItem";
            this.notJustAnybodyToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.notJustAnybodyToolStripMenuItem.Text = "Not just anybody";
            // 
            // helpToolStripMenuItem3
            // 
            this.helpToolStripMenuItem3.Name = "helpToolStripMenuItem3";
            this.helpToolStripMenuItem3.Size = new System.Drawing.Size(228, 22);
            this.helpToolStripMenuItem3.Text = "Help!";
            // 
            // youKnowINeedSomeoneToolStripMenuItem
            // 
            this.youKnowINeedSomeoneToolStripMenuItem.Name = "youKnowINeedSomeoneToolStripMenuItem";
            this.youKnowINeedSomeoneToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.youKnowINeedSomeoneToolStripMenuItem.Text = "You know I need someone";
            // 
            // heeellllppToolStripMenuItem
            // 
            this.heeellllppToolStripMenuItem.Name = "heeellllppToolStripMenuItem";
            this.heeellllppToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.heeellllppToolStripMenuItem.Text = "Heeellllpp!";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
            // 
            // whenIWasYoungerToolStripMenuItem
            // 
            this.whenIWasYoungerToolStripMenuItem.Name = "whenIWasYoungerToolStripMenuItem";
            this.whenIWasYoungerToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.whenIWasYoungerToolStripMenuItem.Text = "When I was younger";
            // 
            // soMuchYoungerThanTodayToolStripMenuItem
            // 
            this.soMuchYoungerThanTodayToolStripMenuItem.Name = "soMuchYoungerThanTodayToolStripMenuItem";
            this.soMuchYoungerThanTodayToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.soMuchYoungerThanTodayToolStripMenuItem.Text = "So much younger than today";
            // 
            // iNeverNeededAnybodysToolStripMenuItem
            // 
            this.iNeverNeededAnybodysToolStripMenuItem.Name = "iNeverNeededAnybodysToolStripMenuItem";
            this.iNeverNeededAnybodysToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.iNeverNeededAnybodysToolStripMenuItem.Text = "I never needed anybodys";
            // 
            // helpInAnyWayToolStripMenuItem
            // 
            this.helpInAnyWayToolStripMenuItem.Name = "helpInAnyWayToolStripMenuItem";
            this.helpInAnyWayToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.helpInAnyWayToolStripMenuItem.Text = "Help in any way.";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxLengthSec);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxTrack);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxSide);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxLengthMin);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxInterval);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAdd);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(745, 287);
            this.splitContainer1.SplitterDistance = 249;
            this.splitContainer1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(203, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "sec";
            // 
            // textBoxLengthSec
            // 
            this.textBoxLengthSec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLengthSec.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLengthSec.Location = new System.Drawing.Point(123, 187);
            this.textBoxLengthSec.Name = "textBoxLengthSec";
            this.textBoxLengthSec.Size = new System.Drawing.Size(77, 26);
            this.textBoxLengthSec.TabIndex = 5;
            this.textBoxLengthSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(202, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "min";
            // 
            // textBoxTrack
            // 
            this.textBoxTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTrack.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTrack.Location = new System.Drawing.Point(123, 60);
            this.textBoxTrack.Name = "textBoxTrack";
            this.textBoxTrack.Size = new System.Drawing.Size(77, 26);
            this.textBoxTrack.TabIndex = 1;
            this.textBoxTrack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSide
            // 
            this.textBoxSide.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSide.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSide.Location = new System.Drawing.Point(123, 123);
            this.textBoxSide.Name = "textBoxSide";
            this.textBoxSide.Size = new System.Drawing.Size(77, 26);
            this.textBoxSide.TabIndex = 3;
            this.textBoxSide.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxLengthMin
            // 
            this.textBoxLengthMin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLengthMin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLengthMin.Location = new System.Drawing.Point(122, 155);
            this.textBoxLengthMin.Name = "textBoxLengthMin";
            this.textBoxLengthMin.Size = new System.Drawing.Size(78, 26);
            this.textBoxLengthMin.TabIndex = 4;
            this.textBoxLengthMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Length";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Side";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Interval";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Track Number";
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInterval.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInterval.Location = new System.Drawing.Point(123, 91);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(77, 26);
            this.textBoxInterval.TabIndex = 2;
            this.textBoxInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.Location = new System.Drawing.Point(45, 219);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(155, 27);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAddClick);
            this.buttonAdd.Enter += new System.EventHandler(this.ButtonAddClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(492, 287);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBoxSum);
            this.tabPage1.Controls.Add(this.labelgt);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(484, 261);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Summary";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBoxSum
            // 
            this.listBoxSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSum.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSum.FormattingEnabled = true;
            this.listBoxSum.ItemHeight = 16;
            this.listBoxSum.Location = new System.Drawing.Point(3, 3);
            this.listBoxSum.Name = "listBoxSum";
            this.listBoxSum.Size = new System.Drawing.Size(478, 231);
            this.listBoxSum.TabIndex = 1;
            // 
            // labelgt
            // 
            this.labelgt.BackColor = System.Drawing.Color.DimGray;
            this.labelgt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelgt.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelgt.ForeColor = System.Drawing.Color.White;
            this.labelgt.Location = new System.Drawing.Point(3, 234);
            this.labelgt.Name = "labelgt";
            this.labelgt.Size = new System.Drawing.Size(478, 24);
            this.labelgt.TabIndex = 0;
            this.labelgt.Text = "Grand Total:  0.00min";
            this.labelgt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.treeViewDisp);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(484, 261);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tree View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeViewDisp
            // 
            this.treeViewDisp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDisp.Location = new System.Drawing.Point(3, 3);
            this.treeViewDisp.Name = "treeViewDisp";
            this.treeViewDisp.Size = new System.Drawing.Size(478, 231);
            this.treeViewDisp.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.label7.Location = new System.Drawing.Point(27, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Copyright Knox Enterprises 2012-Present";
            // 
            // MainWindow
            // 
            this.AcceptButton = this.buttonAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 287);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Tape Timer - Knox Enterprises";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iNeedSomebodyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem notJustAnybodyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem youKnowINeedSomeoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heeellllppToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem whenIWasYoungerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soMuchYoungerThanTodayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNeverNeededAnybodysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpInAnyWayToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TreeView treeViewDisp;
        private System.Windows.Forms.ToolStripMenuItem setGlobalIntervalMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem clearMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTrack;
        private System.Windows.Forms.TextBox textBoxSide;
        private System.Windows.Forms.TextBox textBoxLengthMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLengthSec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelgt;
        private System.Windows.Forms.ListBox listBoxSum;
        private System.Windows.Forms.Label label7;
    }
}

