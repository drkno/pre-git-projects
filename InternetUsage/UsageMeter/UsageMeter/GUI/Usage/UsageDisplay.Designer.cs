namespace UsageMeter.GUI.Usage
{
    partial class UsageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsageForm));
            this.buttonQuit = new System.Windows.Forms.Label();
            this.buttonWebsite = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelRemaining = new System.Windows.Forms.Label();
            this.labelAllowance = new System.Windows.Forms.Label();
            this.labelUsage = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelLastRet = new System.Windows.Forms.Label();
            this.buttonMore = new System.Windows.Forms.Button();
            this.buttonPhone = new System.Windows.Forms.Button();
            this.panelLoading = new System.Windows.Forms.Panel();
            this.labelWarn = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.usageGraph = new UsageMeter.GUI.Usage.UsageGraph();
            this.usageBar = new UsageMeter.GUI.Usage.UsageBar();
            this.panelLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit.BackColor = System.Drawing.Color.DarkRed;
            this.buttonQuit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonQuit.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonQuit.ForeColor = System.Drawing.Color.White;
            this.buttonQuit.Location = new System.Drawing.Point(460, 0);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(45, 20);
            this.buttonQuit.TabIndex = 12;
            this.buttonQuit.Text = "r";
            this.buttonQuit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonQuit.Click += new System.EventHandler(this.QuitbtnClick);
            this.buttonQuit.MouseEnter += new System.EventHandler(this.ButtonQuitMouseEnter);
            this.buttonQuit.MouseLeave += new System.EventHandler(this.ButtonQuitMouseLeave);
            // 
            // buttonWebsite
            // 
            this.buttonWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWebsite.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonWebsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonWebsite.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonWebsite.ForeColor = System.Drawing.Color.White;
            this.buttonWebsite.Location = new System.Drawing.Point(416, 0);
            this.buttonWebsite.Name = "buttonWebsite";
            this.buttonWebsite.Size = new System.Drawing.Size(45, 20);
            this.buttonWebsite.TabIndex = 13;
            this.buttonWebsite.Text = "Â";
            this.buttonWebsite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonWebsite.Click += new System.EventHandler(this.ButtonWebsiteClick);
            this.buttonWebsite.MouseEnter += new System.EventHandler(this.ButtonBlueMouseEnter);
            this.buttonWebsite.MouseLeave += new System.EventHandler(this.ButtonBlueMouseLeave);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.BackColor = System.Drawing.Color.Navy;
            this.buttonRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonRefresh.Font = new System.Drawing.Font("Webdings", 9.8F);
            this.buttonRefresh.ForeColor = System.Drawing.Color.White;
            this.buttonRefresh.Location = new System.Drawing.Point(371, 0);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(45, 20);
            this.buttonRefresh.TabIndex = 14;
            this.buttonRefresh.Text = "q";
            this.buttonRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefreshClick);
            this.buttonRefresh.MouseEnter += new System.EventHandler(this.ButtonBlueMouseEnter);
            this.buttonRefresh.MouseLeave += new System.EventHandler(this.ButtonBlueMouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Location = new System.Drawing.Point(213, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 20);
            this.panel1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "           Statistics           ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Usage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(21, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Allowance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Remaining";
            // 
            // labelRemaining
            // 
            this.labelRemaining.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRemaining.ForeColor = System.Drawing.Color.White;
            this.labelRemaining.Location = new System.Drawing.Point(101, 106);
            this.labelRemaining.Name = "labelRemaining";
            this.labelRemaining.Size = new System.Drawing.Size(89, 16);
            this.labelRemaining.TabIndex = 24;
            this.labelRemaining.Text = "0MB";
            this.labelRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAllowance
            // 
            this.labelAllowance.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAllowance.ForeColor = System.Drawing.Color.White;
            this.labelAllowance.Location = new System.Drawing.Point(101, 78);
            this.labelAllowance.Name = "labelAllowance";
            this.labelAllowance.Size = new System.Drawing.Size(89, 16);
            this.labelAllowance.TabIndex = 23;
            this.labelAllowance.Text = "0MB";
            this.labelAllowance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelUsage
            // 
            this.labelUsage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsage.ForeColor = System.Drawing.Color.White;
            this.labelUsage.Location = new System.Drawing.Point(101, 51);
            this.labelUsage.Name = "labelUsage";
            this.labelUsage.Size = new System.Drawing.Size(89, 16);
            this.labelUsage.TabIndex = 22;
            this.labelUsage.Text = "0MB";
            this.labelUsage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(4, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Last Retreived";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLastRet
            // 
            this.labelLastRet.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLastRet.ForeColor = System.Drawing.Color.White;
            this.labelLastRet.Location = new System.Drawing.Point(4, 152);
            this.labelLastRet.Name = "labelLastRet";
            this.labelLastRet.Size = new System.Drawing.Size(205, 16);
            this.labelLastRet.TabIndex = 26;
            this.labelLastRet.Text = "00/00/00 00:00.00";
            this.labelLastRet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonMore
            // 
            this.buttonMore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonMore.FlatAppearance.BorderSize = 0;
            this.buttonMore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonMore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMore.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMore.ForeColor = System.Drawing.Color.White;
            this.buttonMore.Location = new System.Drawing.Point(191, 174);
            this.buttonMore.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMore.Name = "buttonMore";
            this.buttonMore.Size = new System.Drawing.Size(22, 25);
            this.buttonMore.TabIndex = 27;
            this.buttonMore.TabStop = false;
            this.buttonMore.Text = "+";
            this.buttonMore.UseVisualStyleBackColor = false;
            this.buttonMore.Click += new System.EventHandler(this.ButtonMoreClick);
            // 
            // buttonPhone
            // 
            this.buttonPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonPhone.FlatAppearance.BorderSize = 0;
            this.buttonPhone.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonPhone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPhone.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonPhone.ForeColor = System.Drawing.Color.White;
            this.buttonPhone.Location = new System.Drawing.Point(0, 174);
            this.buttonPhone.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPhone.Name = "buttonPhone";
            this.buttonPhone.Size = new System.Drawing.Size(22, 25);
            this.buttonPhone.TabIndex = 28;
            this.buttonPhone.TabStop = false;
            this.buttonPhone.Text = "Å";
            this.buttonPhone.UseVisualStyleBackColor = false;
            this.buttonPhone.Click += new System.EventHandler(this.ButtonPhoneClick);
            // 
            // panelLoading
            // 
            this.panelLoading.BackColor = System.Drawing.Color.Black;
            this.panelLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLoading.Controls.Add(this.labelWarn);
            this.panelLoading.Controls.Add(this.progressBar1);
            this.panelLoading.Controls.Add(this.label2);
            this.panelLoading.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.panelLoading.Location = new System.Drawing.Point(94, 70);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(317, 97);
            this.panelLoading.TabIndex = 0;
            // 
            // labelWarn
            // 
            this.labelWarn.AutoSize = true;
            this.labelWarn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWarn.ForeColor = System.Drawing.Color.White;
            this.labelWarn.Location = new System.Drawing.Point(62, 62);
            this.labelWarn.Name = "labelWarn";
            this.labelWarn.Size = new System.Drawing.Size(188, 28);
            this.labelWarn.TabIndex = 2;
            this.labelWarn.Text = "This could take a few minutes.\r\nPlease do not quit while this is visible.";
            this.labelWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(58, 36);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(192, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(114, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loading...";
            // 
            // usageGraph
            // 
            this.usageGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usageGraph.Location = new System.Drawing.Point(213, 20);
            this.usageGraph.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.usageGraph.Name = "usageGraph";
            this.usageGraph.Size = new System.Drawing.Size(293, 178);
            this.usageGraph.TabIndex = 16;
            // 
            // usageBar
            // 
            this.usageBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.usageBar.Location = new System.Drawing.Point(0, 199);
            this.usageBar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.usageBar.Name = "usageBar";
            this.usageBar.Size = new System.Drawing.Size(506, 55);
            this.usageBar.TabIndex = 15;
            // 
            // UsageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(506, 254);
            this.Controls.Add(this.panelLoading);
            this.Controls.Add(this.buttonPhone);
            this.Controls.Add(this.buttonMore);
            this.Controls.Add(this.labelLastRet);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelRemaining);
            this.Controls.Add(this.labelAllowance);
            this.Controls.Add(this.labelUsage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.usageGraph);
            this.Controls.Add(this.usageBar);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonWebsite);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Minya Nouvelle", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usage Meter";
            this.Load += new System.EventHandler(this.UsageFormLoad);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragEventMouseDown);
            this.panelLoading.ResumeLayout(false);
            this.panelLoading.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label buttonQuit;
        private System.Windows.Forms.Label buttonWebsite;
        private System.Windows.Forms.Label buttonRefresh;
        private GUI.Usage.UsageBar usageBar;
        private GUI.Usage.UsageGraph usageGraph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelRemaining;
        private System.Windows.Forms.Label labelAllowance;
        private System.Windows.Forms.Label labelUsage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelLastRet;
        private System.Windows.Forms.Button buttonMore;
        private System.Windows.Forms.Button buttonPhone;
        private System.Windows.Forms.Panel panelLoading;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelWarn;

    }
}

