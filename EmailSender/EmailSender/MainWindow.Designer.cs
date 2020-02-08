namespace EmailSender
{
    partial class EmailSender
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
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.richTextBoxContent = new System.Windows.Forms.RichTextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxAuto = new System.Windows.Forms.CheckBox();
            this.buttonAttach = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxRichText = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNumberOfCopies = new System.Windows.Forms.TextBox();
            this.panelAdvanced = new System.Windows.Forms.Panel();
            this.buttonCloseAdvanced = new System.Windows.Forms.Button();
            this.buttonAdvancedOptions = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.Location = new System.Drawing.Point(86, 12);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(804, 20);
            this.textBoxEmail.TabIndex = 0;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.TextBoxEmailTextChanged);
            // 
            // richTextBoxContent
            // 
            this.richTextBoxContent.AcceptsTab = true;
            this.richTextBoxContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxContent.Location = new System.Drawing.Point(16, 84);
            this.richTextBoxContent.Name = "richTextBoxContent";
            this.richTextBoxContent.Size = new System.Drawing.Size(983, 383);
            this.richTextBoxContent.TabIndex = 4;
            this.richTextBoxContent.Text = "";
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(896, 10);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(103, 46);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSendClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "From:";
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFrom.Location = new System.Drawing.Point(86, 34);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(804, 20);
            this.textBoxFrom.TabIndex = 1;
            this.textBoxFrom.TextChanged += new System.EventHandler(this.PraserTextBoxTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "SMTP Server:";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServer.Location = new System.Drawing.Point(103, 3);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.ReadOnly = true;
            this.textBoxServer.Size = new System.Drawing.Size(364, 20);
            this.textBoxServer.TabIndex = 2;
            this.textBoxServer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxServerKeyDown);
            // 
            // buttonQuery
            // 
            this.buttonQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuery.Enabled = false;
            this.buttonQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuery.Location = new System.Drawing.Point(524, 3);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(103, 20);
            this.buttonQuery.TabIndex = 6;
            this.buttonQuery.Text = "Query";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.ButtonQueryClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Subject:";
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSubject.Location = new System.Drawing.Point(86, 57);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(804, 20);
            this.textBoxSubject.TabIndex = 3;
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Items.AddRange(new object[] {
            "25",
            "587",
            "465",
            "2525",
            "275"});
            this.comboBoxPort.Location = new System.Drawing.Point(103, 26);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(75, 21);
            this.comboBoxPort.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Server Port:";
            // 
            // checkBoxAuto
            // 
            this.checkBoxAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAuto.AutoSize = true;
            this.checkBoxAuto.Checked = true;
            this.checkBoxAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAuto.Location = new System.Drawing.Point(473, 5);
            this.checkBoxAuto.Name = "checkBoxAuto";
            this.checkBoxAuto.Size = new System.Drawing.Size(48, 17);
            this.checkBoxAuto.TabIndex = 14;
            this.checkBoxAuto.Text = "Auto";
            this.checkBoxAuto.UseVisualStyleBackColor = true;
            this.checkBoxAuto.CheckedChanged += new System.EventHandler(this.CheckBoxAutoCheckedChanged);
            // 
            // buttonAttach
            // 
            this.buttonAttach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAttach.Location = new System.Drawing.Point(524, 27);
            this.buttonAttach.Name = "buttonAttach";
            this.buttonAttach.Size = new System.Drawing.Size(103, 21);
            this.buttonAttach.TabIndex = 15;
            this.buttonAttach.Text = "Attach File(s)";
            this.buttonAttach.UseVisualStyleBackColor = true;
            this.buttonAttach.Click += new System.EventHandler(this.ButtonAttachClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBoxRichText);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.buttonAttach);
            this.panel1.Controls.Add(this.textBoxNumberOfCopies);
            this.panel1.Controls.Add(this.buttonQuery);
            this.panel1.Controls.Add(this.textBoxServer);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxPort);
            this.panel1.Controls.Add(this.checkBoxAuto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 76);
            this.panel1.TabIndex = 16;
            // 
            // checkBoxRichText
            // 
            this.checkBoxRichText.AutoSize = true;
            this.checkBoxRichText.Location = new System.Drawing.Point(524, 52);
            this.checkBoxRichText.Name = "checkBoxRichText";
            this.checkBoxRichText.Size = new System.Drawing.Size(100, 17);
            this.checkBoxRichText.TabIndex = 17;
            this.checkBoxRichText.Text = "Allow Rich Text";
            this.checkBoxRichText.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Number of Copies:";
            // 
            // textBoxNumberOfCopies
            // 
            this.textBoxNumberOfCopies.Location = new System.Drawing.Point(103, 50);
            this.textBoxNumberOfCopies.Name = "textBoxNumberOfCopies";
            this.textBoxNumberOfCopies.Size = new System.Drawing.Size(75, 20);
            this.textBoxNumberOfCopies.TabIndex = 15;
            this.textBoxNumberOfCopies.Text = "1";
            this.textBoxNumberOfCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelAdvanced
            // 
            this.panelAdvanced.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelAdvanced.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelAdvanced.Controls.Add(this.buttonCloseAdvanced);
            this.panelAdvanced.Controls.Add(this.panel1);
            this.panelAdvanced.Location = new System.Drawing.Point(194, 209);
            this.panelAdvanced.Name = "panelAdvanced";
            this.panelAdvanced.Size = new System.Drawing.Size(639, 99);
            this.panelAdvanced.TabIndex = 17;
            this.panelAdvanced.Visible = false;
            // 
            // buttonCloseAdvanced
            // 
            this.buttonCloseAdvanced.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonCloseAdvanced.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonCloseAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseAdvanced.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCloseAdvanced.Location = new System.Drawing.Point(560, 2);
            this.buttonCloseAdvanced.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCloseAdvanced.Name = "buttonCloseAdvanced";
            this.buttonCloseAdvanced.Size = new System.Drawing.Size(75, 16);
            this.buttonCloseAdvanced.TabIndex = 17;
            this.buttonCloseAdvanced.Text = "X";
            this.buttonCloseAdvanced.UseVisualStyleBackColor = false;
            this.buttonCloseAdvanced.Click += new System.EventHandler(this.ButtonCloseAdvancedClick);
            // 
            // buttonAdvancedOptions
            // 
            this.buttonAdvancedOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdvancedOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdvancedOptions.Location = new System.Drawing.Point(896, 55);
            this.buttonAdvancedOptions.Name = "buttonAdvancedOptions";
            this.buttonAdvancedOptions.Size = new System.Drawing.Size(103, 23);
            this.buttonAdvancedOptions.TabIndex = 18;
            this.buttonAdvancedOptions.Text = "Advanced Options";
            this.buttonAdvancedOptions.UseVisualStyleBackColor = true;
            this.buttonAdvancedOptions.Click += new System.EventHandler(this.ButtonAdvancedOptionsClick);
            // 
            // EmailSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 479);
            this.Controls.Add(this.buttonAdvancedOptions);
            this.Controls.Add(this.panelAdvanced);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.richTextBoxContent);
            this.Controls.Add(this.textBoxEmail);
            this.Name = "EmailSender";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmailSender";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelAdvanced.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.RichTextBox richTextBoxContent;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxAuto;
        private System.Windows.Forms.Button buttonAttach;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxRichText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxNumberOfCopies;
        private System.Windows.Forms.Panel panelAdvanced;
        private System.Windows.Forms.Button buttonCloseAdvanced;
        private System.Windows.Forms.Button buttonAdvancedOptions;
    }
}

