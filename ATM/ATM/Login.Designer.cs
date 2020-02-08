namespace KnoxKonnect
{
    partial class Login
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
            this.userBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelQuit = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCreateAcct = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // userBox
            // 
            this.userBox.BackColor = System.Drawing.Color.Black;
            this.userBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userBox.ForeColor = System.Drawing.Color.Lime;
            this.userBox.Location = new System.Drawing.Point(10, 31);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(220, 20);
            this.userBox.TabIndex = 1;
            this.userBox.TextChanged += new System.EventHandler(this.UserBoxTextChanged);
            this.userBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1KeyDown);
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.Color.Black;
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordBox.ForeColor = System.Drawing.Color.Lime;
            this.passwordBox.Location = new System.Drawing.Point(10, 55);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(220, 20);
            this.passwordBox.TabIndex = 2;
            this.passwordBox.UseSystemPasswordChar = true;
            this.passwordBox.TextChanged += new System.EventHandler(this.PasswordBoxTextChanged);
            this.passwordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1KeyDown);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Black;
            this.buttonLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Location = new System.Drawing.Point(235, 41);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(33, 24);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "->";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            this.buttonLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Webdings", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.label1.Location = new System.Drawing.Point(3, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ï";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Knox Bank - Please Login";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.buttonCreateAcct);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labelQuit);
            this.panel1.Controls.Add(this.labelPassword);
            this.panel1.Controls.Add(this.labelUsername);
            this.panel1.Controls.Add(this.buttonLogin);
            this.panel1.Controls.Add(this.passwordBox);
            this.panel1.Controls.Add(this.userBox);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 132);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1MouseDown);
            // 
            // labelQuit
            // 
            this.labelQuit.AutoSize = true;
            this.labelQuit.BackColor = System.Drawing.Color.Black;
            this.labelQuit.Font = new System.Drawing.Font("Webdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.labelQuit.Location = new System.Drawing.Point(261, -1);
            this.labelQuit.Name = "labelQuit";
            this.labelQuit.Size = new System.Drawing.Size(19, 17);
            this.labelQuit.TabIndex = 7;
            this.labelQuit.Text = "r";
            this.labelQuit.Click += new System.EventHandler(this.LabelQuitClick);
            this.labelQuit.MouseEnter += new System.EventHandler(this.LabelQuitMouseEnter);
            this.labelQuit.MouseLeave += new System.EventHandler(this.LabelQuitMouseLeave);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelPassword.ForeColor = System.Drawing.Color.LightGray;
            this.labelPassword.Location = new System.Drawing.Point(98, 58);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password";
            this.labelPassword.Click += new System.EventHandler(this.LabelPasswordClick);
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.labelUsername.ForeColor = System.Drawing.Color.LightGray;
            this.labelUsername.Location = new System.Drawing.Point(97, 35);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "Username";
            this.labelUsername.Click += new System.EventHandler(this.LabelUsernameClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(7, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "                                                                                 " +
                "     ";
            // 
            // buttonCreateAcct
            // 
            this.buttonCreateAcct.BackColor = System.Drawing.Color.Black;
            this.buttonCreateAcct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.buttonCreateAcct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateAcct.Location = new System.Drawing.Point(10, 99);
            this.buttonCreateAcct.Name = "buttonCreateAcct";
            this.buttonCreateAcct.Size = new System.Drawing.Size(258, 24);
            this.buttonCreateAcct.TabIndex = 9;
            this.buttonCreateAcct.Text = "Create New Account";
            this.buttonCreateAcct.UseVisualStyleBackColor = false;
            // 
            // Login
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(282, 134);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Knox Konnect";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelQuit;
        private System.Windows.Forms.Button buttonCreateAcct;
        private System.Windows.Forms.Label label3;
    }
}

