using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ATM;

namespace KnoxKonnect
{
    public partial class Login : Form
    {
        public Login()
        {
            loggedIn = new Account(this);
            InitializeComponent();
        }

        private void LabelUsernameClick(object sender, EventArgs e)
        {
            userBox.Select();
        }

        private void LabelPasswordClick(object sender, EventArgs e)
        {
            passwordBox.Select();
        }

        private void PasswordBoxTextChanged(object sender, EventArgs e)
        {
            if (passwordBox.Text.Length > 0)
            {
                if (labelPassword.Visible)
                {
                    labelPassword.Visible = false;
                }
            }
            else
            {
                labelPassword.Visible = true;
            }
        }

        private void UserBoxTextChanged(object sender, EventArgs e)
        {
            if (userBox.Text.Length > 0)
            {
                if (labelUsername.Visible)
                {
                    labelUsername.Visible = false;
                }
            }
            else
            {
                labelUsername.Visible = true;
            }
        }

        private void Form1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Environment.Exit(0);
            }
        }

        private void LabelQuitClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LabelQuitMouseEnter(object sender, EventArgs e)
        {
            labelQuit.ForeColor = Color.Red;
        }

        private void LabelQuitMouseLeave(object sender, EventArgs e)
        {
            labelQuit.ForeColor = Color.White;
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Label1MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0);
        }

        private Account loggedIn;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            loggedIn.SetUser(200,"","",0);

            passwordBox.Text = "";
            userBox.Text = "";
            this.Hide();
            loggedIn.Show();
        }

        public void Logout()
        {
            this.Show();
        }
    }
}