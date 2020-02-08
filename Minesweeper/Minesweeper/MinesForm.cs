using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MinesForm : Form
    {
        private static readonly Rectangle BtnSize = new Rectangle(30,30,30,30);
        private int[,] _mineArray;

        public MinesForm()
        {
            InitializeComponent();

            const char mineChar = '۞';
            var xbtns = (Width - 2*BtnSize.X)/BtnSize.Width;
            var ybtns = (Height - 2*BtnSize.Y)/BtnSize.Height;

            _mineArray = GenerateMines(xbtns,ybtns,10);
            InsertMineNumbers(ref _mineArray);

            for (var i = 0; i < xbtns; i++)
            {
                for (var j = 0; j < ybtns; j++)
                {
                    var btn = new MineButton(i, j, _mineArray[i,j], mineChar)
                              {
                                  Width = BtnSize.Width,
                                  Height = BtnSize.Height,
                                  Left = i*BtnSize.Width + BtnSize.X,
                                  Top = j*BtnSize.Height + BtnSize.Y,
                                  TabStop = false,
                                  PositionClickedEventHandler = MineButtonClicked,
                                  Font = new Font("Arial",12)
                              };
                    Controls.Add(btn);
                    Controls[Controls.Count-1].Show();
                }
            }
        }

        private bool _mineDisable;
        public void MineClicked()
        {
            _mineDisable = true;
            for (var i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].GetType() == typeof (MineButton))
                {
                    ((MineButton) Controls[i]).MineClicked();
                }
            }
        }

        private void MineButtonClicked(object sender, EventArgs e)
        {
            if(_mineDisable) return;
            var btn = (MineButton) sender;
            if (btn.GetValue() == -1)
            {
                MineClicked();
            }
            if (btn.GetValue() != 0) return;
            ClearAdjacent(btn);
        }

        private void ClearAdjacent(MineButton xy)
        {
            for (var i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].GetType() != typeof (MineButton)) continue;
                var btn = (MineButton) Controls[i];
                if(!btn.Enabled) continue;
                if(!btn.IsAdjacent(xy.GetPosition())) continue;
                if(btn.GetValue() != -1) btn.PerformClick();
            }
        }

        private static int[,] GenerateMines(int x, int y, int mines)
        {
            var positList = new int[x,y];
            var randomX = new KRandomNumber(1, x);
            var randomY = new KRandomNumber(1, y);
            for (var i = 0; i < mines; i++)
            {
                x = randomX.Next() - 1;
                y = randomY.Next() - 1;
                if (positList[x,y] == -1)
                {
                    i--;
                    continue;
                }
                positList[x, y] = -1;
            }
            return positList;
        }

        private void InsertMineNumbers(ref int[,] mineArray)
        {
            for (var i = 0; i < mineArray.GetLength(0); i++)
            {
                for (var j = 0; j < mineArray.GetLength(1); j++)
                {
                    if(mineArray[i,j] != -1) continue;
                    if (i - 1 >= 0 && mineArray[i - 1, j] != -1){ mineArray[i - 1, j]++; }
                    if (i + 1 < mineArray.GetLength(0) && mineArray[i + 1, j] != -1) { mineArray[i + 1, j]++; }
                    if (j - 1 >= 0 && mineArray[i, j - 1] != -1) { mineArray[i, j - 1]++; }
                    if (j + 1 < mineArray.GetLength(1) && mineArray[i, j + 1] != -1) { mineArray[i, j + 1]++; }

                    if (i - 1 >= 0 && j - 1 >= 0 && mineArray[i - 1, j - 1] != -1){ mineArray[i - 1, j - 1]++; }
                    if (i + 1 < mineArray.GetLength(0) && j + 1 < mineArray.GetLength(1) && mineArray[i + 1, j + 1] != -1) { mineArray[i + 1, j + 1]++; }
                    if (i + 1 < mineArray.GetLength(0) && j - 1 >= 0 && mineArray[i + 1, j - 1] != -1) { mineArray[i + 1, j - 1]++; }
                    if (i - 1 >= 0 && j + 1 < mineArray.GetLength(1) && mineArray[i - 1, j + 1] != -1) { mineArray[i - 1, j + 1]++; }
                }
            }
        }

        private void ButtonNewClick(object sender, EventArgs e)
        {
            for (var i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].GetType() == typeof (MineButton))
                {
                    Controls.RemoveAt(i);
                }
            }

            const char mineChar = '۞';
            var xbtns = (Width - 2 * BtnSize.X) / BtnSize.Width;
            var ybtns = (Height - 2 * BtnSize.Y) / BtnSize.Height;

            _mineArray = GenerateMines(xbtns, ybtns, 10);
            InsertMineNumbers(ref _mineArray);

            for (var i = 0; i < xbtns; i++)
            {
                for (var j = 0; j < ybtns; j++)
                {
                    var btn = new MineButton(i, j, _mineArray[i, j], mineChar)
                    {
                        Width = BtnSize.Width,
                        Height = BtnSize.Height,
                        Left = i * BtnSize.Width + BtnSize.X,
                        Top = j * BtnSize.Height + BtnSize.Y,
                        TabStop = false,
                        PositionClickedEventHandler = MineButtonClicked,
                        Font = new Font("Arial", 12)
                    };
                    Controls.Add(btn);
                    Controls[Controls.Count - 1].Show();
                }
            }
        }
    }
}
