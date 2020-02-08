namespace SMSender
{
    partial class Compose
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
            this.textBoxMessage = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelCharacters = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelContacts = new System.Windows.Forms.Panel();
            this.listBoxContacts = new System.Windows.Forms.ListBox();
            this.buttonContacts = new System.Windows.Forms.Button();
            this.panelContacts.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMessage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMessage.Location = new System.Drawing.Point(12, 38);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(551, 165);
            this.textBoxMessage.TabIndex = 0;
            this.textBoxMessage.Text = "";
            this.textBoxMessage.TextChanged += new System.EventHandler(this.TextBoxMessageTextChanged);
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(488, 10);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSendClick);
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(35, 12);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(234, 20);
            this.textBoxNumber.TabIndex = 2;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(289, 15);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(69, 13);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Status: None";
            // 
            // labelCharacters
            // 
            this.labelCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCharacters.Location = new System.Drawing.Point(424, 10);
            this.labelCharacters.Name = "labelCharacters";
            this.labelCharacters.Size = new System.Drawing.Size(58, 23);
            this.labelCharacters.TabIndex = 4;
            this.labelCharacters.Text = "0/160";
            this.labelCharacters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "To";
            // 
            // panelContacts
            // 
            this.panelContacts.Controls.Add(this.listBoxContacts);
            this.panelContacts.Location = new System.Drawing.Point(35, 32);
            this.panelContacts.Name = "panelContacts";
            this.panelContacts.Size = new System.Drawing.Size(254, 100);
            this.panelContacts.TabIndex = 6;
            this.panelContacts.Visible = false;
            // 
            // listBoxContacts
            // 
            this.listBoxContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxContacts.FormattingEnabled = true;
            this.listBoxContacts.Location = new System.Drawing.Point(0, 0);
            this.listBoxContacts.Name = "listBoxContacts";
            this.listBoxContacts.ScrollAlwaysVisible = true;
            this.listBoxContacts.Size = new System.Drawing.Size(254, 100);
            this.listBoxContacts.TabIndex = 7;
            // 
            // buttonContacts
            // 
            this.buttonContacts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonContacts.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContacts.Location = new System.Drawing.Point(269, 11);
            this.buttonContacts.Name = "buttonContacts";
            this.buttonContacts.Size = new System.Drawing.Size(20, 22);
            this.buttonContacts.TabIndex = 7;
            this.buttonContacts.Text = "▼";
            this.buttonContacts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonContacts.UseVisualStyleBackColor = true;
            this.buttonContacts.Click += new System.EventHandler(this.ButtonContactsClick);
            // 
            // Compose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 215);
            this.Controls.Add(this.buttonContacts);
            this.Controls.Add(this.panelContacts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCharacters);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxMessage);
            this.Name = "Compose";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compose SMS";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ComposeLoad);
            this.panelContacts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBoxMessage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelCharacters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelContacts;
        private System.Windows.Forms.ListBox listBoxContacts;
        private System.Windows.Forms.Button buttonContacts;
    }
}

