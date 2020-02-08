using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SamaritinUI
{
    public sealed partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



            // Triangle Shape
            _triangleBrush = new SolidBrush(Color.FromArgb(235, 61, 70));
            _trianglePoint = new PointF[3];
            _trianglePoint[0] = new PointF(Width / 2.0f - 10, Height / 2.0f + 20.0f);
            _trianglePoint[1] = new PointF(Width / 2.0f + 10, Height / 2.0f + 20.0f);
            _trianglePoint[2] = new PointF(Width / 2.0f, Height / 2.0f);

            // Text
            var gfx = CreateGraphics();
            //gfx.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            var format = StringFormat.GenericTypographic;
            format.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            _characterWidth = gfx.MeasureString("W", Font, Width, format);
            _characterWidth.Width = MeasureDisplayStringWidth(gfx, "W", Font);
            _textBrush = new SolidBrush(Color.FromArgb(61, 79, 83));
        }

        private static int MeasureDisplayStringWidth(Graphics graphics, string text, Font font)
        {
            var format  = new StringFormat();
            var rect    = new RectangleF(0, 0, 1000, 1000);
            CharacterRange[] ranges = { new CharacterRange(0, text.Length) };
            format.SetMeasurableCharacterRanges(ranges);
            var regions = graphics.MeasureCharacterRanges (text, font, rect, format);
            rect    = regions[0].GetBounds (graphics);
            return (int)(rect.Right + 1.0f);
        }

        private bool _firstRun = true;
        private void Form1Paint(object sender, PaintEventArgs e)
        {
            if (!_firstRun) return;
            _firstRun = false;
            ShowString("what are your commands ?");
        }

        private readonly SizeF _characterWidth;
        private readonly Brush _triangleBrush;
        private readonly Brush _textBrush;
        private readonly PointF[] _trianglePoint;
        private void DrawTriangle(Graphics e)
        {
            e.FillPolygon(_triangleBrush, _trianglePoint);
        }

        private void DrawText(string text, Graphics e)
        {
            var leftShift = GetStringLeftshift(text);
            for (var i = leftShift; i < text.Length+leftShift; i++)
            {
                e.DrawString(text[(i - leftShift)].ToString(CultureInfo.InvariantCulture), Font, _textBrush, (_trianglePoint[2].X + i * _characterWidth.Width - _characterWidth.Width / 2.0f) + 1.0f, _trianglePoint[2].Y - _characterWidth.Height);
            }
        }

        private void DrawTextUnderscore(string text, Graphics e)
        {
            var leftShift = GetStringLeftshift(text);
            e.DrawLine(new Pen(_textBrush), (_trianglePoint[2].X + leftShift * _characterWidth.Width - _characterWidth.Width / 2.0f), _trianglePoint[2].Y - 2f, (_trianglePoint[2].X + (text.Length + leftShift) * _characterWidth.Width - _characterWidth.Width / 2.0f), _trianglePoint[2].Y - 2f);
        }

        private int GetStringLeftshift(string text)
        {
            char[] vowel = {'A', 'E', 'I', 'O', 'U'};
            var ind = text.Length-1;
            foreach (var v in vowel)
            {
                if (text.IndexOf(v) != -1 && text.IndexOf(v) < ind)
                {
                    ind = text.IndexOf(v);
                }
            }
            return -ind;
        }

        private void ClearScreen(Graphics e)
        {
            e.Clear(BackColor);
        }

        #region Animate String
        private Thread _workerThread;
        public void ShowString(string text)
        {
            _workerThread = new Thread(ShowStringWorker);
            _workerThread.Start(text);
        }

        private void ShowStringWorker(object text)
        {
            var gfx = CreateGraphics();
            gfx.SmoothingMode = SmoothingMode.AntiAlias;
            var textSplit = ((string) text).ToUpper().Trim().Split(' ');
            for (var i = 0; i < textSplit.Length; i++)
            {
                var i1 = i;
                Invoke(new MethodInvoker(() =>
                                         {
                                             DrawTriangle(gfx);
                                             DrawText(textSplit[i1], gfx);
                                             DrawTextUnderscore(textSplit[i1], gfx);
                                         }));
                Thread.Sleep(textSplit[i].Length * 150);
                Invoke(new MethodInvoker(() => ClearScreen(gfx)));
                Thread.Sleep(100);
            }
            Invoke(new MethodInvoker(() =>
            {
                DrawTextUnderscore("     ", gfx);
            }));
        }
        #endregion

        private void button1_Click(object sender, System.EventArgs e)
        {
            ShowString("what are your commands ?");
        }
    }
}
