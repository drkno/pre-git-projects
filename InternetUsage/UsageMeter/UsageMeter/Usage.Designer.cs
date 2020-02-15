namespace UsageMeter
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
            this.remainLabel = new System.Windows.Forms.Label();
            this.usedLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonQuit = new System.Windows.Forms.Label();
            this.buttonWebsite = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // remainLabel
            // 
            this.remainLabel.BackColor = System.Drawing.Color.Black;
            this.remainLabel.Font = new System.Drawing.Font("Gill Sans MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainLabel.ForeColor = System.Drawing.Color.LightGray;
            this.remainLabel.Location = new System.Drawing.Point(5, 38);
            this.remainLabel.Margin = new System.Windows.Forms.Padding(0);
            this.remainLabel.Name = "remainLabel";
            this.remainLabel.Size = new System.Drawing.Size(585, 19);
            this.remainLabel.TabIndex = 10;
            this.remainLabel.Text = "Remaining: 0 MB, 0%";
            this.remainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.remainLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragEventMouseDown);
            // 
            // usedLabel
            // 
            this.usedLabel.BackColor = System.Drawing.Color.Transparent;
            this.usedLabel.Font = new System.Drawing.Font("Gill Sans MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usedLabel.ForeColor = System.Drawing.Color.White;
            this.usedLabel.Location = new System.Drawing.Point(497, 72);
            this.usedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usedLabel.Name = "usedLabel";
            this.usedLabel.Size = new System.Drawing.Size(93, 43);
            this.usedLabel.TabIndex = 9;
            this.usedLabel.Text = "0 MB\r\n0%";
            this.usedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.usedLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragEventMouseDown);
            // 
            // statusLabel
            // 
            this.statusLabel.BackColor = System.Drawing.Color.Black;
            this.statusLabel.Font = new System.Drawing.Font("Gill Sans MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.LightGray;
            this.statusLabel.Location = new System.Drawing.Point(5, 57);
            this.statusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(585, 20);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.Text = "Loading data...";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.statusLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragEventMouseDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Minya Nouvelle", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(585, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "       Usage Meter       ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragEventMouseDown);
            // 
            // buttonQuit
            // 
            this.buttonQuit.AutoSize = true;
            this.buttonQuit.BackColor = System.Drawing.Color.Black;
            this.buttonQuit.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonQuit.ForeColor = System.Drawing.Color.White;
            this.buttonQuit.Location = new System.Drawing.Point(569, 5);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(21, 18);
            this.buttonQuit.TabIndex = 12;
            this.buttonQuit.Text = "r";
            this.buttonQuit.Click += new System.EventHandler(this.QuitbtnClick);
            this.buttonQuit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.buttonQuit.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.buttonQuit.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.buttonQuit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // buttonWebsite
            // 
            this.buttonWebsite.AutoSize = true;
            this.buttonWebsite.BackColor = System.Drawing.Color.Black;
            this.buttonWebsite.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.buttonWebsite.ForeColor = System.Drawing.Color.White;
            this.buttonWebsite.Location = new System.Drawing.Point(550, 6);
            this.buttonWebsite.Name = "buttonWebsite";
            this.buttonWebsite.Size = new System.Drawing.Size(21, 18);
            this.buttonWebsite.TabIndex = 13;
            this.buttonWebsite.Text = "Â";
            this.buttonWebsite.Click += new System.EventHandler(this.WebsiteLinkClicked);
            this.buttonWebsite.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.buttonWebsite.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.buttonWebsite.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.buttonWebsite.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Webdings", 9.8F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(529, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "q";
            this.label2.Click += new System.EventHandler(this.ButtonNextClick);
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown);
            this.label2.MouseEnter += new System.EventHandler(this.ButtonMouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.ButtonMouseLeave);
            this.label2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseUp);
            // 
            // UsageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(595, 161);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonWebsite);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.remainLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usedLabel);
            this.Font = new System.Drawing.Font("Minya Nouvelle", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usage Meter";
            this.Load += new System.EventHandler(this.UsageFormLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UsageFormPaint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragEventMouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label remainLabel;
        private System.Windows.Forms.Label usedLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label buttonQuit;
        private System.Windows.Forms.Label buttonWebsite;
        private System.Windows.Forms.Label label2;

    }
}

