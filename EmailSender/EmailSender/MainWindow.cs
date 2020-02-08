#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

#endregion

namespace EmailSender
{
    public partial class EmailSender : Form
    {
        private string[] _attachmentCollection;
        private bool _automx = true;

        public EmailSender()
        {
            InitializeComponent();
            comboBoxPort.SelectedIndex = 0;
        }

        public void SetServer(string host)
        {
            textBoxServer.Text = host;
        }


        private void ButtonSendClick(object sender, EventArgs e)
        {
            try
            {
                var sending = new Sending();
                sending.Show();

                var mxServers = new List<string>();
                var toAddresses = new List<string>();
                toAddresses.AddRange(textBoxEmail.Text.Split(';'));
                var fromAddresses = new List<string>();
                fromAddresses.AddRange(textBoxFrom.Text.Split(';'));
                var random = new Random();
                const bool isHtml = false;
                var msgBody = (checkBoxRichText.Checked) ? richTextBoxContent.Rtf : richTextBoxContent.Text;

                if (_automx)
                {
                    mxServers.AddRange(textBoxServer.Text.Split(';').Select(mxServer => DnsMx.GetMxRecords(mxServer)[0]));
                }
                else
                {
                    mxServers.Add(textBoxServer.Text);
                }

                int numMessages;
                if (!int.TryParse(textBoxNumberOfCopies.Text, out numMessages))
                {
                    MessageBox.Show("Invalid Number of Messages. Defaulting to 1.", "Email Sender", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    textBoxNumberOfCopies.Text = "1";
                    numMessages = 1;
                }
                for (var j = 0; j < numMessages; j++)
                {
                    for (var i = 0; i < mxServers.Count; i++)
                    {
                        var smtpClient = new SmtpClient
                                             {
                                                 Host = mxServers[i],
                                                 DeliveryMethod = SmtpDeliveryMethod.Network,
                                                 Port = int.Parse(comboBoxPort.SelectedItem.ToString())
                                             };
                        var mailMessage =
                            new MailMessage(new MailAddress(fromAddresses[random.Next(0, fromAddresses.Count)]),
                                            new MailAddress(toAddresses[i]))
                                {
                                    Subject = textBoxSubject.Text,
                                    Body = msgBody,
                                    IsBodyHtml = isHtml
                                };
                        if (_attachmentCollection != null)
                        {
                            foreach (string attch in _attachmentCollection)
                            {
                                mailMessage.Attachments.Add(new Attachment(attch));
                            }
                        }
                        smtpClient.Send(mailMessage);
                    }
                }

                if (MessageBox.Show("Clear? (Including Attachments)", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    textBoxEmail.Clear();
                    textBoxFrom.Clear();
                    textBoxServer.Clear();
                    textBoxSubject.Clear();
                    richTextBoxContent.Clear();
                    _attachmentCollection = null;
                    _automx = true;
                }

                sending.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occured and its all your fault.\nYes you heard me, YOUR FAULT.\n\nTech Crap:\n" +
                    ex.Message);
            }
        }

        private void ButtonQueryClick(object sender, EventArgs e)
        {
            MessageBox.Show("This manual tool is for a single domain only and will not check after the first ';'.",
                            "MX Query", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (textBoxEmail.TextLength <= 0 || !textBoxEmail.Text.Contains("@")) return;
            if (textBoxServer.Text.Contains(";"))
            {
                textBoxServer.Text = textBoxServer.Text.Substring(0,
                                                                  textBoxServer.Text.IndexOf(";",
                                                                                             StringComparison.Ordinal));
            }
            var mxRecords = DnsMx.GetMxRecords(textBoxServer.Text);
            if (_automx)
            {
                textBoxServer.Text = mxRecords[0];
            }
            else
            {
                var mxLookup = new MxLookup(mxRecords, this);
                mxLookup.ShowDialog();
            }
        }

        private void TextBoxEmailTextChanged(object sender, EventArgs e)
        {
            PraserTextBoxTextChanged(sender, e);
            if (!_automx) return;
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text)) return;
            var addr = textBoxEmail.Text.Split(';');
            textBoxServer.Text = addr.Aggregate("",
                                                (current, s) =>
                                                current + ((current.Length > 0) ? ";" : "") +
                                                s.Substring(s.IndexOf("@", StringComparison.Ordinal) + 1));
        }

        private void TextBoxServerKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Tab)
            {
                _automx = false;
            }
        }

        private void CheckBoxAutoCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAuto.Checked)
            {
                textBoxServer.ReadOnly = true;
                buttonQuery.Enabled = false;
                _automx = true;
            }
            else
            {
                _automx = false;
                textBoxServer.ReadOnly = false;
                buttonQuery.Enabled = true;
            }
        }

        private void ButtonAttachClick(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog {Multiselect = true, Filter = "Any Files|*.*"};
            if (openFile.ShowDialog() != DialogResult.OK) return;
            _attachmentCollection = openFile.FileNames;
        }

        private void PraserTextBoxTextChanged(object sender, EventArgs e)
        {
            var txtBox = ((TextBox) sender);
            var fromValue = txtBox.Text;
            if (string.IsNullOrWhiteSpace(fromValue)) return;
            if (!fromValue.Contains(" ") && !fromValue.Contains(",")) return;
            for (var i = 0; i < fromValue.Length; i++)
            {
                if (fromValue[i] != ' ' && fromValue[i] != ',') continue;
                var aStringBuilder = new StringBuilder(fromValue);
                aStringBuilder.Remove(i, 1);
                aStringBuilder.Insert(i, ";");
                fromValue = aStringBuilder.ToString();
            }
            txtBox.Text = fromValue;
            txtBox.Select(fromValue.Length, 0);
        }

        private void ButtonCloseAdvancedClick(object sender, EventArgs e)
        {
            panelAdvanced.Visible = false;
        }

        private void ButtonAdvancedOptionsClick(object sender, EventArgs e)
        {
            panelAdvanced.Visible = true;
        }
    }
}