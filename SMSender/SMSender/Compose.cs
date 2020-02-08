using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

namespace SMSender
{
    public partial class Compose : Form
    {
        private readonly PhoneControl _controller;
        public Compose(ref PhoneControl control)
        {
            InitializeComponent();
            _controller = control;
        }

        public Compose(ref PhoneControl control, string to, string message)
        {
            InitializeComponent();
            _controller = control;
            textBoxNumber.Text = to;
            textBoxMessage.Text = message;
        }

        private void ButtonSendClick(object sender, EventArgs e)
        {
            if (_controller.SendSMS(textBoxNumber.Text, textBoxMessage.Text))
            {
                Close();
            }
            else
            {
                labelStatus.Text = "Status: Message sending failed";
            }
        }

        private void TextBoxMessageTextChanged(object sender, EventArgs e)
        {
            var tb = ((RichTextBox) sender).TextLength;
            labelCharacters.Text = tb.ToString(CultureInfo.InvariantCulture) + "/160";
            buttonSend.Enabled = tb <= 160;
        }

        private void ButtonContactsClick(object sender, EventArgs e)
        {
            panelContacts.Visible = !panelContacts.Visible;
        }

        private void ComposeLoad(object sender, EventArgs e)
        {
            foreach (var contact in _controller.GetContactList())
            {
                listBoxContacts.Items.Add(contact);
            }
        }
    }
}
