using System;
using System.Windows.Forms;

namespace UsageMeter.Retreivers.Spark
{
    public partial class SparkLogin : Form, ILogin
    {
        public SparkLogin()
        {
            InitializeComponent();
            DetailsWereProvided = false;
        }

        public bool DetailsWereProvided { get; private set; }
        public bool LoginRequired { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private void ButtonLoginClick(object sender, EventArgs e)
        {
            Username = textBoxUsername.Text;
            Password = textBoxPassword.Text;
            DetailsWereProvided = true;
            Close();
        }
    }
}
