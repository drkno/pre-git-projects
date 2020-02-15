using System;
using System.Windows.Forms;

namespace UsageMeter.GUI
{
    public partial class Crash : Form
    {
        private readonly Exception _exception;
        private string GenerateMessage()
        {
            var message = _exception.Message;
            message += "\nDATA:\n" + _exception.Data;
            var exc = _exception;
            while (exc.InnerException != null)
            {
                message = "\n\nINNER:\n" + _exception.Message;
                message += "\nDATA:\n" + _exception.Data;
                exc = exc.InnerException;
            }
            return message;
        }

        public Crash(Exception ex)
        {
            InitializeComponent();
            _exception = ex;
            richTextBoxException.Text = GenerateMessage();
        }

        private void LinkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            const string url = "mailto:matthew@makereti.co.nz?subject=Usage%20Meter%20Crash&body=";
            var body = "Usage Meter crashed!\n" + "---- Exception Details ----\n" + 
                GenerateMessage() + "\n----    End Details    ----";
            body = body.Replace(" ", "%20");
            body = body.Replace("\n", "%0A");
            body = body.Replace("'", "%27");
            System.Diagnostics.Process.Start(url + body);
        }
    }
}
