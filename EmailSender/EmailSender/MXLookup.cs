/*
 * EmailSender 1.0
 * Written By: Matthew Knox
 * Copyright Matthew Knox 2012. All rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EmailSender
{
    public partial class MxLookup : Form
    {
        readonly EmailSender _send;
        public MxLookup(IEnumerable<string> resp, EmailSender sender)
        {
            _send = sender;
            InitializeComponent();
            listBox1.Items.AddRange((string[])resp);
        }

        private void Button1Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < listBox1.Items.Count)
            {
                _send.SetServer(listBox1.SelectedItem.ToString());
                Close();
            } else
            {
                MessageBox.Show("Select one.");
            }
        }
    }
}
