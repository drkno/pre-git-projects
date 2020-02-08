using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DecBinHex
{
    public partial class Form1 : Form
    {
        const string ERRORMSG = "Number invalid/too small/large for 64bit integer.";
        string output;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Focused == true)
            {
                textBox2.Text = toBinary(textBox1.Text);
                textBox3.Text = toHex(textBox1.Text);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Focused == true)
            {
                output = FromBin(textBox2.Text);
                textBox1.Text = toDec(output);
                textBox3.Text = toHex(output);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Focused == true)
            {
                output = FromHex(textBox3.Text);
                textBox1.Text = toDec(output);
                textBox2.Text = toBinary(output);
            }
        }

        private string toBinary(string num)
        {
            try
            {
                string returned = Convert.ToString(Convert.ToInt64(num), 2);
                return returned;
            }
            catch
            {
                if (num == "")
                {
                    return "0";
                }
                return ERRORMSG;
            }
        }

        private string toHex(string num)
        {
            try
            {
                string returned = Convert.ToString(Convert.ToInt64(num), 16);
                return returned;
            }
            catch
            {
                if (num == "")
                {
                    return "0";
                }
                return ERRORMSG;
            }
        }

        private string toDec(string num)
        {
            try
            {
                return Convert.ToString(Convert.ToInt64(num), 10);
            }
            catch
            {
                if (num == "")
                {
                    return "0";
                }
                return ERRORMSG;
            }
        }

        public static string FromHex(string hex)
        {
            try
            {
                return Convert.ToString(Int64.Parse(hex, System.Globalization.NumberStyles.AllowHexSpecifier));
            }
            catch
            {
                if (hex == "")
                {
                    return "0";
                }
                return ERRORMSG;
            }
        }

        public static string FromBin(string bin)
        {
            try
            {
                long l = Convert.ToInt64(bin, 2);
                Int64 m = (Int64)l;
                return m.ToString();
            }
            catch
            {
                if (bin == "")
                {
                    return "0";
                }
                return ERRORMSG;
            }
        }

    }
}
