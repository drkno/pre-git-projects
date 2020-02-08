namespace SMSender
{
    partial class PhonePorts
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
            this.buttonDone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIncoming = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOutgoing = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(205, 16);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(75, 23);
            this.buttonDone.TabIndex = 0;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.ButtonDoneClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Incoming Port";
            // 
            // textBoxIncoming
            // 
            this.textBoxIncoming.Location = new System.Drawing.Point(99, 6);
            this.textBoxIncoming.Name = "textBoxIncoming";
            this.textBoxIncoming.Size = new System.Drawing.Size(100, 20);
            this.textBoxIncoming.TabIndex = 2;
            this.textBoxIncoming.Text = "COM11";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Outgoing Port";
            // 
            // textBoxOutgoing
            // 
            this.textBoxOutgoing.Location = new System.Drawing.Point(99, 29);
            this.textBoxOutgoing.Name = "textBoxOutgoing";
            this.textBoxOutgoing.Size = new System.Drawing.Size(100, 20);
            this.textBoxOutgoing.TabIndex = 4;
            this.textBoxOutgoing.Text = "COM10";
            // 
            // PhonePorts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 53);
            this.Controls.Add(this.textBoxOutgoing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIncoming);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PhonePorts";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhonePorts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIncoming;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOutgoing;
    }
}