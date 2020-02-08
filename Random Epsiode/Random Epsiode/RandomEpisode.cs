using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Random_Episode
{
    public partial class RandEpisodeWin : Form
    {
        private readonly List<string> _episodelist;
        private readonly RandomNumber _rand;
        private int _selectedepisode;

        public RandEpisodeWin()
        {
            InitializeComponent();

            // Set Window Title
            var exepath = Path.GetDirectoryName(Application.ExecutablePath);
            if (exepath != null)
            {
                Text = exepath.Substring(exepath.LastIndexOf('\\') + 1);

                // Set Window Picture
                if (File.Exists(exepath + "\\#iconimg.png"))
                {
                    logoPic.ImageLocation = exepath + "\\#iconimg.png";
                }
                else if (File.Exists(exepath + "\\#iconimg.jpg"))
                {
                    logoPic.ImageLocation = exepath + "\\#iconimg.jpg";
                }
                else if (File.Exists(exepath + "\\#iconimg.gif"))
                {
                    logoPic.ImageLocation = exepath + "\\#iconimg.gif";
                }
                else
                {
                    logoPic.ImageLocation = exepath + "\\#iconimg.png";
                }
            }

            // Get List of Episodes
            _episodelist = new List<string>();
            GetFiles(exepath + "\\");

            // Set and Display Episode
            _rand = new RandomNumber(1,_episodelist.Count);
            NewEpisode();
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void QuitBtnClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RetryBtnClick(object sender, EventArgs e)
        {
            NewEpisode();
        }

        private void OpenBtnClick(object sender, EventArgs e)
        {
            if (_episodelist.Count == 0 || File.Exists(_episodelist[_selectedepisode]) == false)
            {
                MessageBox.Show("How can I open a non existant file?", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            else
            {
                Process.Start(_episodelist[_selectedepisode]);
            }
        }

        private void NewEpisode()
        {
            if (_episodelist.Count == 0)
            {
                Text = "No TV Show Detected";
                MessageBox.Show((epiArea.Text = "No Episodes Found"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                openbtn.Enabled = retrybtn.Enabled = false;
            }
            else
            {
                retrybtn.Select();
                var i = _rand.Next()-1;
                while (i == _selectedepisode)
                {
                    i = _rand.Next()-1;
                }
                _selectedepisode = i;

                var output =
                    _episodelist[_selectedepisode].Substring(_episodelist[_selectedepisode].LastIndexOf('\\') + 1);
                output = output.Substring(0, output.LastIndexOf('.'));

                if(Regex.IsMatch(output,"([^*]*[ ][-][ ][\\[][0-9][0-9][x][0-9][0-9][\\]][ ][-][ ][^*]*)"))
                {
                    output = output.Replace("] - ", "]\n");
                    output = output.Replace(" - [", ": [");
                }
                else if (Regex.IsMatch(output, "([^*]*[ ][-][ ][\\[][0-9][0-9][x][0-9][0-9][\\]])"))
                {
                    output = output.Replace(" - [", ": [");
                }
                epiArea.Text = output;
            }
        }


        public void GetFiles(string path)
        {
            if (File.Exists(path))
            {
                ProcessFile(path);
            }
            else if (Directory.Exists(path))
            {
                ProcessDirectory(path);
            }
        }

        public void ProcessDirectory(string targetDirectory)
        {
            var fileEntries = Directory.GetFiles(targetDirectory);
            foreach (var fileName in fileEntries)
            {
                ProcessFile(fileName);
            }

            var subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (var subdirectory in subdirectoryEntries)
            {
                ProcessDirectory(subdirectory);
            }
        }

        public void ProcessFile(string path)
        {
            if (IsMedia(path))
            {
                _episodelist.Add(path);
            }
        }

        readonly List<string> _filetypes = new List<string> { "mov", "mkv", "avi", "wmv", "flv", "mpg", "vob", "mp4", "mod" };
        private bool IsMedia(string path)
        {
            return _filetypes.Any(path.Contains);
        }

        internal class RandomNumber
        {
            public byte[] RandomArray = new byte[] { 0x0 };
            private readonly int _maxnum;
            private readonly int _minnum;
            private int _iterator;

            public RandomNumber()
            {
                _maxnum = 255;
                _minnum = 1;
                _iterator = RandomArray.Length;
            }

            /// <summary>
            /// New Random Number Class
            /// </summary>
            /// <param name="min">No less than 1</param>
            /// <param name="max">No more than 255</param>
            public RandomNumber(int min, int max)
            {
                _maxnum = max;
                _minnum = min;
                _iterator = RandomArray.Length;
            }

            public int Next()
            {
                int num;
                do
                {
                    EndOfArray();
                    num = Convert.ToInt32(RandomArray[_iterator]);
                    _iterator++;
                } while (num > _maxnum || num < _minnum);
                return num;
            }

            private void EndOfArray()
            {
                if (_iterator != RandomArray.Length) return;
                NewArray();
            }

            public void NewArray()
            {
                _iterator = 0;
                RandomNumberGenerator.Create().GetNonZeroBytes(RandomArray);
            }
        }
    }
}