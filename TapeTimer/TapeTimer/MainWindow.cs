using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TapeTimer
{
    struct Track
    {
        public double Length;
        public int Side;
        public int TrackNumber;
        public int Interval;

        public double GetLength(int sideNum)
        {
            return sideNum == Side ? (Length + (Interval/60.00)) : 0;
        }

        public override string ToString()
        {
            return "Track " + TrackNumber + " :    " + (Length+(Interval/60.00)).ToString("0.00") + "min";
        }
    }

    public partial class MainWindow : Form
    {
        List<Track> _tracks = new List<Track>();
        List<int> _sides = new List<int>();
        private int _globalInterval = 2;
        private double _grandTotal;

        public MainWindow()
        {
            InitializeComponent();
            textBoxTrack.Text = "1";
            textBoxSide.Text = "1";
            textBoxInterval.Text = _globalInterval.ToString("00");
            textBoxSide.Focus();
            textBoxSide.SelectAll();
        }

        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void SetGlobalIntervalMenuItemClick(object sender, EventArgs e)
        {
            var globalInt = new GlobalInterval(this,ref _globalInterval);
            globalInt.ShowDialog();
        }

        public void SetInterval(int interval)
        {
            _globalInterval = interval;
            textBoxInterval.Text = _globalInterval.ToString("00");
        }

        private void ButtonAddClick(object sender, EventArgs e)
        {
            try
            {
                var track = new Track();
                if (int.TryParse(textBoxInterval.Text, out track.Interval) == false)
                {
                    MessageBox.Show("The interval number entered was invalid.", "Add Track", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    textBoxInterval.Select();
                    return;
                }

                if (int.TryParse(textBoxSide.Text, out track.Side) == false)
                {
                    MessageBox.Show("The side number entered was invalid.", "Add Track", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    textBoxSide.Select();
                    return;
                }

                if (int.TryParse(textBoxTrack.Text, out track.TrackNumber) == false)
                {
                    MessageBox.Show("The track number entered was invalid.", "Add Track", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    textBoxTrack.Select();
                    return;
                }

                if (double.TryParse(textBoxLengthMin.Text, out track.Length) == false)
                {
                    MessageBox.Show("The minutes part of the track length entered was invalid.", "Add Track",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxLengthMin.Select();
                    return;
                }

                double temp;
                if (double.TryParse(textBoxLengthSec.Text, out temp) == false)
                {
                    MessageBox.Show("The minutes part of the track length entered was invalid.", "Add Track",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxLengthSec.Select();
                    return;
                }
                temp /= 60;
                track.Length += temp;

                _tracks.Add(track);
                if (_sides.Contains(track.Side))
                {
                    treeViewDisp.Nodes[_sides.IndexOf(track.Side)].Nodes.Add(track.ToString());

                    var total = _tracks.Sum(track1 => track1.GetLength(track.Side));

                    listBoxSum.Items[_sides.IndexOf(track.Side)] = "Subtotal for Side " +
                                                                   track.Side.ToString(CultureInfo.InvariantCulture) +
                                                                   ":         " + total.ToString("0.00") + "min";
                }
                else
                {
                    treeViewDisp.Nodes.Add(new TreeNode("Side " + track.Side.ToString(CultureInfo.InvariantCulture)));
                    _sides.Add(track.Side);
                    treeViewDisp.Nodes[_sides.IndexOf(track.Side)].Nodes.Add(track.ToString());
                    listBoxSum.Items.Add("Subtotal for Side " + track.Side.ToString(CultureInfo.InvariantCulture) +
                                         ":         " + (track.Length + (track.Interval/60.00)).ToString("0.00") + "min");
                }

                textBoxTrack.Text = (track.TrackNumber + 1).ToString(CultureInfo.InvariantCulture);
                textBoxInterval.Text = _globalInterval.ToString("00");
                textBoxLengthMin.Text = "";
                textBoxLengthSec.Text = "";
                textBoxSide.Focus();
                textBoxSide.SelectAll();
                treeViewDisp.ExpandAll();

                _grandTotal += track.Length + (track.Interval/60.00);
                labelgt.Text = "Grand Total:  " + _grandTotal.ToString("0.00") + "min";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearMenuItemClick(object sender, EventArgs e)
        {
            switch (MessageBox.Show("You pressed the clear button. Are you sure this is what you want to do?", "Clear",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.No: return;
            }
            _tracks.Clear();
            _sides.Clear();
            treeViewDisp.Nodes.Clear();
            listBoxSum.Items.Clear();
            labelgt.Text = "Grand Total:  0.00min";
        }

        private void ExportToExcelToolStripMenuItemClick(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog {Filter = "*.csv|*.csv"};
            if (saveFile.ShowDialog() != DialogResult.OK) return;
            var streamWriter = new StreamWriter(saveFile.FileName);

            streamWriter.WriteLine("Track,Length,Interval");
            foreach (var side in _sides)
            {
                var total = _tracks.Sum(track1 => track1.GetLength(side));
                streamWriter.WriteLine("Side " + side + ":," + total);
                for (var i = 0; i < _tracks.Count; i++)
                {
                    if(_tracks[i].Side == side)
                    {
                        streamWriter.WriteLine("Track " + _tracks[i].TrackNumber + "," + _tracks[i].Length + "," + _tracks[i].Interval);
                    }
                }
            }

            streamWriter.WriteLine("\nGrand Total: " + _grandTotal);
            streamWriter.Close();
        }
    }
}
