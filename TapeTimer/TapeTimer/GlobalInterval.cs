using System;
using System.Windows.Forms;

namespace TapeTimer
{
    public partial class GlobalInterval : Form
    {
        private readonly MainWindow _parent;
        public GlobalInterval(MainWindow wnd, ref int interval)
        {
            InitializeComponent();
            _parent = wnd;
            textBoxinterval.Text = interval.ToString("00");
        }

        private void ButtonSetClick(object sender, EventArgs e)
        {
            int interval;
            if(int.TryParse(textBoxinterval.Text,out interval) == false)
            {
                MessageBox.Show("Please input a valid interval.", "Global Interval", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            _parent.SetInterval(interval);
            Close();
        }
    }
}
