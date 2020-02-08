using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMSender
{
    public partial class SMSPanel : Form
    {
        private PhoneControl _phoneControl;
        public SMSPanel()
        {
            InitializeComponent();
            var ports = new PhonePorts();
            ports.ShowDialog();
            _phoneControl = new PhoneControl(ports.Mobile);
        }

        private void SMSPanelLoad(object sender, EventArgs e)
        {
            // Load SMS List
            foreach(var item in _phoneControl.GetMessageList())
            {
                listBoxMessages.Items.Add(item);
            }
        }

        private void ButtonReplyClick(object sender, EventArgs e)
        {
            var compose = new Compose(ref _phoneControl, textBoxFrom.Text,"");
            compose.ShowDialog();
        }

        private void ButtonForwardClick(object sender, EventArgs e)
        {
            var compose = new Compose(ref _phoneControl, "", richTextBoxMessage.Text);
            compose.ShowDialog();
        }

        private void ButtonNewClick(object sender, EventArgs e)
        {
            var compose = new Compose(ref _phoneControl);
            compose.ShowDialog();
        }

        private void ListBoxMessagesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMessages.SelectedIndex < 0 || listBoxMessages.SelectedIndex >= listBoxMessages.Items.Count)
                return;
            var selection = (PhoneControl.MessageStruct)listBoxMessages.SelectedItem;
            textBoxFrom.Text = selection.From.ToString();
            textBoxTo.Text = selection.To.ToString();
            richTextBoxMessage.Text = selection.Message;
        }
    }
}
