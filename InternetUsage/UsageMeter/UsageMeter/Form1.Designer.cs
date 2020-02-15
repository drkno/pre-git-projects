namespace UsageMeter
{
    partial class usageForm
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
            this.UsageBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.websiteLink = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.allowLabel = new System.Windows.Forms.Label();
            this.usedLabel = new System.Windows.Forms.Label();
            this.remainLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.remper = new System.Windows.Forms.Label();
            this.usedper = new System.Windows.Forms.Label();
            this.allowper = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UsageBar
            // 
            this.UsageBar.Location = new System.Drawing.Point(12, 154);
            this.UsageBar.Name = "UsageBar";
            this.UsageBar.Size = new System.Drawing.Size(413, 27);
            this.UsageBar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(438, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usage Meter";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Used:";
            // 
            // websiteLink
            // 
            this.websiteLink.AutoSize = true;
            this.websiteLink.Location = new System.Drawing.Point(156, 31);
            this.websiteLink.Name = "websiteLink";
            this.websiteLink.Size = new System.Drawing.Size(126, 13);
            this.websiteLink.TabIndex = 4;
            this.websiteLink.TabStop = true;
            this.websiteLink.Text = "Go to the Kinect Website";
            this.websiteLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteLink_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Remaining:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Allowance:";
            // 
            // allowLabel
            // 
            this.allowLabel.Location = new System.Drawing.Point(150, 64);
            this.allowLabel.Name = "allowLabel";
            this.allowLabel.Size = new System.Drawing.Size(132, 13);
            this.allowLabel.TabIndex = 8;
            this.allowLabel.Text = "0 MB";
            this.allowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usedLabel
            // 
            this.usedLabel.Location = new System.Drawing.Point(150, 86);
            this.usedLabel.Name = "usedLabel";
            this.usedLabel.Size = new System.Drawing.Size(132, 13);
            this.usedLabel.TabIndex = 9;
            this.usedLabel.Text = "0 MB";
            this.usedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remainLabel
            // 
            this.remainLabel.Location = new System.Drawing.Point(150, 108);
            this.remainLabel.Name = "remainLabel";
            this.remainLabel.Size = new System.Drawing.Size(132, 13);
            this.remainLabel.TabIndex = 10;
            this.remainLabel.Text = "0 MB";
            this.remainLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(30, 130);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(371, 13);
            this.statusLabel.TabIndex = 11;
            this.statusLabel.Text = "Error: Data was unable to be retrived.";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // remper
            // 
            this.remper.Location = new System.Drawing.Point(288, 108);
            this.remper.Name = "remper";
            this.remper.Size = new System.Drawing.Size(113, 13);
            this.remper.TabIndex = 14;
            this.remper.Text = "0%";
            this.remper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usedper
            // 
            this.usedper.Location = new System.Drawing.Point(288, 86);
            this.usedper.Name = "usedper";
            this.usedper.Size = new System.Drawing.Size(113, 13);
            this.usedper.TabIndex = 13;
            this.usedper.Text = "0%";
            this.usedper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // allowper
            // 
            this.allowper.Location = new System.Drawing.Point(288, 64);
            this.allowper.Name = "allowper";
            this.allowper.Size = new System.Drawing.Size(113, 13);
            this.allowper.TabIndex = 12;
            this.allowper.Text = "0%";
            this.allowper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 194);
            this.Controls.Add(this.remper);
            this.Controls.Add(this.usedper);
            this.Controls.Add(this.allowper);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.remainLabel);
            this.Controls.Add(this.usedLabel);
            this.Controls.Add(this.allowLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.websiteLink);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UsageBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "usageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usage Meter";
            this.Load += new System.EventHandler(this.usageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar UsageBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel websiteLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label allowLabel;
        private System.Windows.Forms.Label usedLabel;
        private System.Windows.Forms.Label remainLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label remper;
        private System.Windows.Forms.Label usedper;
        private System.Windows.Forms.Label allowper;
    }
}

