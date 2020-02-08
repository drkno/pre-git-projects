using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ColorDropDown
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        

        const int WS_CLIPCHILDREN = 0x2000000;
        const int WS_MINIMIZEBOX = 0x20000;
        const int WS_MAXIMIZEBOX = 0x10000;
        const int WS_SYSMENU = 0x80000;
        const int CS_DBLCLKS = 0x8;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.Style = WS_CLIPCHILDREN | WS_MINIMIZEBOX | WS_SYSMENU;
                cp.ClassStyle = CS_DBLCLKS;

                return cp;
            }
        }
    }
}
