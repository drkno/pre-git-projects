using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace FlatmateSorter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button4Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog {ShowNewFolderButton = false};
            if (dialog.ShowDialog() != DialogResult.OK) return;
            var files = Directory.EnumerateFiles(dialog.SelectedPath);
            foreach (var file in files)
            {
                var reader = new StreamReader(file);
                var contents = reader.ReadToEnd();
                reader.Close();

                var date = contents.Substring(contents.IndexOf("Date: ", StringComparison.Ordinal) + 6);
                date = date.Substring(0, date.IndexOf("\r\n", StringComparison.Ordinal));

                var email = contents.Substring(contents.IndexOf("Reply-To: ", StringComparison.Ordinal) + 10);
                email = email.Substring(0, email.IndexOf("\r\n", StringComparison.Ordinal));

                var message = contents.Substring(contents.IndexOf("<i>", StringComparison.Ordinal) + 3,
                    contents.IndexOf("</i>", StringComparison.Ordinal) - contents.IndexOf("<i>", StringComparison.Ordinal));
                message = message.Replace("=\r\n", "");
                message = HttpUtility.HtmlDecode(message);
                message = Regex.Replace(message, "<.*", "");
                message = Regex.Replace(message, "=.{2}", "");

                var phone = "";
                foreach (var match in Regex.Matches(message, @"[0-9 ]{7,14}"))
                {
                    phone = match.ToString();
                    break;
                }
                phone = phone.Replace(" ", "");

                var item = new ListViewItem {Checked = false};
                item.SubItems.Add(date);    // 1
                item.SubItems.Add(email);   // 2
                item.SubItems.Add(message); // 3
                item.SubItems.Add(phone);   // 4
                item.SubItems.Add("");      // 5

                listView1.Items.Add(item);
            }
        }

        private void ListView1SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0 && listView1.SelectedIndices[0] < 0) return;
            if (listView1.SelectedItems.Count < 1) return;
            textBoxEmail.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBoxPhone.Text = listView1.SelectedItems[0].SubItems[4].Text;
            richTextBoxRecv.Text = listView1.SelectedItems[0].SubItems[3].Text;
            richTextBoxNotes.Text = listView1.SelectedItems[0].SubItems[5].Text;
            checkBox1.Checked = listView1.SelectedItems[0].Checked;
        }

        private void RichTextBoxNotesTextChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0 && listView1.SelectedIndices[0] < 0) return;
            if (listView1.SelectedItems.Count < 1) return;
            listView1.SelectedItems[0].SubItems[5].Text = richTextBoxNotes.Text;
            Console.WriteLine(richTextBoxNotes.Text);
        }

        private void TextBoxEmailTextChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0 && listView1.SelectedIndices[0] < 0) return;
            if (listView1.SelectedItems.Count < 1) return;
            listView1.SelectedItems[0].SubItems[2].Text = textBoxEmail.Text;
        }

        private void TextBoxPhoneTextChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0 && listView1.SelectedIndices[0] < 0) return;
            if (listView1.SelectedItems.Count < 1) return;
            listView1.SelectedItems[0].SubItems[4].Text = textBoxPhone.Text;
        }

        private void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0 && listView1.SelectedIndices[0] < 0) return;
            if (listView1.SelectedItems.Count < 1) return;
            listView1.SelectedItems[0].Checked = checkBox1.Checked;
        }

        private void ListView1ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0 && listView1.SelectedIndices[0] < 0) return;
            if (listView1.SelectedItems.Count < 1) return;
            if(e.Item != listView1.SelectedItems[0]) return;
            checkBox1.Checked = e.Item.Checked;
        }

        private void Button1Click(object sender, EventArgs e)
        {
            Process.Start("mailto:" + textBoxEmail.Text.Trim());
        }

        private void Button2Click(object sender, EventArgs e)
        {
            Mailto(true);
        }

        private void Mailto(bool check)
        {
            var to = "mailto:?bcc=";
            foreach (var person in listView1.Items.Cast<object>().Where(person => ((ListViewItem)person).Checked == check))
            {
                if (to.Contains("@")) to += ",";
                to += ((ListViewItem) person).SubItems[2].Text;
            }
            Process.Start(to);
        }

        private void Button3Click(object sender, EventArgs e)
        {
            Mailto(false);
        }

        private void Button6Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var saveFile = new SaveFileDialog {Filter = "*.fdb|*.fdb"};
            if (saveFile.ShowDialog() != DialogResult.OK) return;
            var writer = new StreamWriter(saveFile.FileName);
            foreach (ListViewItem person in listView1.Items)
            {
                writer.WriteLine(person.Checked + "|" + person.SubItems[0].Text + "|" + person.SubItems[1].Text + "|" + person.SubItems[2].Text + "|" + person.SubItems[3].Text + "|" + person.SubItems[4].Text + "|" + person.SubItems[5].Text);
            }
            writer.Close();
        }

        private new void Load()
        {
            var openFile = new OpenFileDialog {Filter = "*.fdb|*.fdb"};
            if (openFile.ShowDialog() != DialogResult.OK) return;
            var reader = new StreamReader(openFile.FileName);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if(string.IsNullOrWhiteSpace(line)) continue;
                var split = line.Split('|');
                if (split.Length != 7) continue;
                var item = new ListViewItem {Checked = bool.Parse(split[0])};

                item.SubItems.Add(split[2]);
                item.SubItems.Add(split[3]);
                item.SubItems.Add(split[4]);
                item.SubItems.Add(split[5]);
                item.SubItems.Add(split[6]);

                listView1.Items.Add(item);
            }
            reader.Close();
        }

        private void Button5Click(object sender, EventArgs e)
        {
            Load();
        }
    }
}
