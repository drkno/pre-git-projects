namespace Random_Episode
{
    partial class RandEpisodeWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandEpisodeWin));
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.epiArea = new System.Windows.Forms.Label();
            this.openbtn = new System.Windows.Forms.Button();
            this.retrybtn = new System.Windows.Forms.Button();
            this.quitbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPic
            // 
            this.logoPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logoPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logoPic.ErrorImage = ((System.Drawing.Image)(resources.GetObject("logoPic.ErrorImage")));
            this.logoPic.Location = new System.Drawing.Point(3, 3);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(122, 105);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPic.TabIndex = 0;
            this.logoPic.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "The Random Episode I Have Chosen Is:";
            // 
            // epiArea
            // 
            this.epiArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.epiArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.epiArea.Location = new System.Drawing.Point(131, 21);
            this.epiArea.Name = "epiArea";
            this.epiArea.Size = new System.Drawing.Size(301, 61);
            this.epiArea.TabIndex = 2;
            this.epiArea.Text = "Example - [00x00] - The Exemplar";
            this.epiArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openbtn
            // 
            this.openbtn.Location = new System.Drawing.Point(139, 85);
            this.openbtn.Name = "openbtn";
            this.openbtn.Size = new System.Drawing.Size(91, 23);
            this.openbtn.TabIndex = 3;
            this.openbtn.Text = "&Open";
            this.openbtn.UseVisualStyleBackColor = true;
            this.openbtn.Click += new System.EventHandler(this.OpenBtnClick);
            // 
            // retrybtn
            // 
            this.retrybtn.Location = new System.Drawing.Point(236, 85);
            this.retrybtn.Name = "retrybtn";
            this.retrybtn.Size = new System.Drawing.Size(91, 23);
            this.retrybtn.TabIndex = 4;
            this.retrybtn.Text = "&Retry";
            this.retrybtn.UseVisualStyleBackColor = true;
            this.retrybtn.Click += new System.EventHandler(this.RetryBtnClick);
            // 
            // quitbtn
            // 
            this.quitbtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.quitbtn.Location = new System.Drawing.Point(333, 85);
            this.quitbtn.Name = "quitbtn";
            this.quitbtn.Size = new System.Drawing.Size(91, 23);
            this.quitbtn.TabIndex = 5;
            this.quitbtn.Text = "&Quit";
            this.quitbtn.UseVisualStyleBackColor = true;
            this.quitbtn.Click += new System.EventHandler(this.QuitBtnClick);
            // 
            // RandEpisodeWin
            // 
            this.AcceptButton = this.retrybtn;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.CancelButton = this.quitbtn;
            this.ClientSize = new System.Drawing.Size(431, 113);
            this.Controls.Add(this.quitbtn);
            this.Controls.Add(this.retrybtn);
            this.Controls.Add(this.openbtn);
            this.Controls.Add(this.epiArea);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logoPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RandEpisodeWin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FoldName";
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label epiArea;
        private System.Windows.Forms.Button openbtn;
        private System.Windows.Forms.Button retrybtn;
        private System.Windows.Forms.Button quitbtn;
    }
}

