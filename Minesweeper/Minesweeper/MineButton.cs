using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Minesweeper
{
    class MineButton : Button
    {
        private readonly Point _pos;
        private readonly int _number;
        private readonly char _minechar;

        public EventHandler PositionClickedEventHandler;

        public MineButton(int xposition, int yposition, int number, char minechar)
        {
            _pos = new Point(xposition,yposition);
            _number = number;
            _minechar = minechar;
            Click += MineButtonClick;
            MouseDown += MineButtonRightClick;
            Text = "¤";
        }

        private void MineButtonRightClick(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Right || !Enabled) return;
            Text = (Text == _minechar.ToString(CultureInfo.InvariantCulture)) ? "¤" : _minechar.ToString(CultureInfo.InvariantCulture);
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void MineButtonClick(object sender, EventArgs e)
        {
            Enabled = false;
            Text = (_number == -1) ? _minechar.ToString(CultureInfo.InvariantCulture) : (_number==0)?" ":_number.ToString(CultureInfo.InvariantCulture);
            if(PositionClickedEventHandler != null)
                PositionClickedEventHandler(this, null);
        }

        public void MineClicked()
        {
            MineButtonClick(this,null);
        }

        public Point GetPosition()
        {
            return _pos;
        }

        public int GetValue()
        {
            return _number;
        }

        public bool IsAdjacent(Point xy)
        {
            if (!Enabled || _pos == xy) return false;
            if (_pos.X != xy.X && _pos.X != xy.X - 1 && _pos.X != xy.X + 1) return false;
            return _pos.Y == xy.Y || _pos.X == xy.Y - 1 || _pos.Y == xy.Y + 1;
        }
    }
}
