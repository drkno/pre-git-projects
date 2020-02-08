using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMSender
{
    public partial class PhonePorts : Form
    {
        public BluetoothPhone Mobile;
        public PhonePorts()
        {
            InitializeComponent();
        }

        private void ButtonDoneClick(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBoxIncoming.Text) || string.IsNullOrWhiteSpace(textBoxOutgoing.Text)) return;
            Mobile = new BluetoothPhone
            {
                OutgoingPort = new SerialPort(textBoxOutgoing.Text, 115200),
                IncomingPort = new SerialPort(textBoxIncoming.Text, 115200)
            };
            Close();
        }
    }
}
