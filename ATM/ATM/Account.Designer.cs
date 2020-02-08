namespace ATM
{
    partial class Account
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
            this.labelBalance = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonChangePwd = new System.Windows.Forms.Button();
            this.buttonTransferFunds = new System.Windows.Forms.Button();
            this.buttonDeposit = new System.Windows.Forms.Button();
            this.buttonWithdraw = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelBalance
            // 
            this.labelBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelBalance.Font = new System.Drawing.Font("Arial Black", 60F, System.Drawing.FontStyle.Bold);
            this.labelBalance.ForeColor = System.Drawing.Color.Yellow;
            this.labelBalance.Location = new System.Drawing.Point(201, 8);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(449, 151);
            this.labelBalance.TabIndex = 0;
            this.labelBalance.Text = "$0";
            this.labelBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonLogout
            // 
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Location = new System.Drawing.Point(8, 130);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(187, 23);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "&Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.ButtonLogoutClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.buttonChangePwd);
            this.panel1.Controls.Add(this.buttonTransferFunds);
            this.panel1.Controls.Add(this.buttonDeposit);
            this.panel1.Controls.Add(this.buttonWithdraw);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelBalance);
            this.panel1.Controls.Add(this.buttonLogout);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 167);
            this.panel1.TabIndex = 2;
            // 
            // buttonChangePwd
            // 
            this.buttonChangePwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangePwd.Location = new System.Drawing.Point(8, 101);
            this.buttonChangePwd.Name = "buttonChangePwd";
            this.buttonChangePwd.Size = new System.Drawing.Size(187, 23);
            this.buttonChangePwd.TabIndex = 6;
            this.buttonChangePwd.Text = "&Change Password";
            this.buttonChangePwd.UseVisualStyleBackColor = true;
            // 
            // buttonTransferFunds
            // 
            this.buttonTransferFunds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTransferFunds.Location = new System.Drawing.Point(8, 72);
            this.buttonTransferFunds.Name = "buttonTransferFunds";
            this.buttonTransferFunds.Size = new System.Drawing.Size(187, 23);
            this.buttonTransferFunds.TabIndex = 5;
            this.buttonTransferFunds.Text = "&Transfer Funds";
            this.buttonTransferFunds.UseVisualStyleBackColor = true;
            this.buttonTransferFunds.Click += new System.EventHandler(this.buttonTransferFunds_Click);
            // 
            // buttonDeposit
            // 
            this.buttonDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeposit.Location = new System.Drawing.Point(8, 43);
            this.buttonDeposit.Name = "buttonDeposit";
            this.buttonDeposit.Size = new System.Drawing.Size(187, 23);
            this.buttonDeposit.TabIndex = 4;
            this.buttonDeposit.Text = "&Deposit";
            this.buttonDeposit.UseVisualStyleBackColor = true;
            this.buttonDeposit.Click += new System.EventHandler(this.buttonDeposit_Click);
            // 
            // buttonWithdraw
            // 
            this.buttonWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWithdraw.Location = new System.Drawing.Point(8, 14);
            this.buttonWithdraw.Name = "buttonWithdraw";
            this.buttonWithdraw.Size = new System.Drawing.Size(187, 23);
            this.buttonWithdraw.TabIndex = 3;
            this.buttonWithdraw.Text = "&Withdraw";
            this.buttonWithdraw.UseVisualStyleBackColor = true;
            this.buttonWithdraw.Click += new System.EventHandler(this.buttonWithdraw_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "You Have";
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(661, 169);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Account";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banking";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonChangePwd;
        private System.Windows.Forms.Button buttonTransferFunds;
        private System.Windows.Forms.Button buttonDeposit;
        private System.Windows.Forms.Button buttonWithdraw;
    }
}

