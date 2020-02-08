using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace UsageMeter.GUI.Usage
{
    public partial class UsageGraph : UserControl
    {
        public UsageGraph()
        {
            InitializeComponent();
        }

        //#### Global Variables ####
        private Color[] _barColours;
        private double[] _dataArray;
        private Color _bgroundColor, _defaultBarColour;
        private int _barSeparation = 3, _graphMargin = 15, _barWidth = 10;
        private bool _autoMargin = true, _autoWidth = true, _autoColours = true, _autoSeparation = true;
        //####       ####       ####

        // Background Control Methods
        private void SetBackgroundColour(Color backgndColour)
        {
            _bgroundColor = (backgndColour.IsEmpty) ? Color.DarkGray:backgndColour;
        }

        private void SetGraphMargin(int margin)
        {
            _graphMargin = (margin < 0) ? 10 : margin;
            _autoMargin = false;
        }

        // Bar Control Methods
        private void SetBarColour(Color barColour)
        {
            _defaultBarColour = (barColour.IsEmpty) ? Color.Blue : barColour;
        }

        private void SetBarColours(Color[] barColours)
        {
            _barColours = barColours;
            _autoColours = false;
        }

        private void SetBarColourWithIndex(Color barColour, int index)
        {
            // Not Implemented
        }

        private void SetBarSeperation(bool isAuto, int seperation)
        {
            if (isAuto)
            {
                _autoSeparation = true;
                return;
            }
            _barSeparation = (seperation < 0) ? 3 : seperation;
            _autoSeparation = false;
        }

        private void SetBarWidth(bool isAuto, int seperation)
        {
            if (isAuto)
            {
                _autoWidth = true;
                return;
            }
            _barWidth = (seperation < 0) ? 10 : seperation;
            _autoWidth = false;
        }

        // Data Control Methods
        public void SetData(double[] barData)
        {
            _dataArray = barData;
        }

        private void SetAxisMinMax(bool isAuto, double min, double max)
        {

        }

        // Other
        public void SetGraphNeedsUpdating()
        {
            Invalidate();
            Update();
        }

        private void UsageGraphPaint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0,0,Width,Height);

            if(_dataArray == null)
            {
                var data = new[] { 75.0, 80.0, 85.0, 90.0, 95.0, 100.0 };
                SetData(data);
            }

            SetBarColour(Color.Empty);
            SetBackgroundColour(Color.Empty);

            // Set Background
            e.Graphics.Clear(_bgroundColor);

            // Create Bars

            var barw = (float)(rect.Width - (_dataArray.Length - 1.0) * _barSeparation - 2.0 * _graphMargin) / _dataArray.Length;
            var barh = (float)(rect.Height - 2.0 * _graphMargin) * (100.0/_allowance);

            for (var i = 0; i < _dataArray.Length; i++)
            {
                var fillRect = rect;
                fillRect.Width = (int)barw;
                fillRect.Height = (int)((_dataArray[i] / 100.0) * barh);
                fillRect.Y = rect.Height - _graphMargin - fillRect.Height;
                fillRect.X = (int)(_graphMargin + i * barw + (float)i * _barSeparation);


                var br = new LinearGradientBrush(rect, Color.Black, Color.Black, 0, false);
                var cb = new ColorBlend
                             {
                                 Positions = new[] {0, 1/6f, 2/6f, 1},
                                 Colors = new[] {Color.Red, Color.Orange, Color.Yellow, Color.LawnGreen}
                             };
                br.InterpolationColors = cb;
                br.RotateTransform(90);
                e.Graphics.FillRectangle(br, fillRect);

                var str = _dataArray[i].ToString("0.0");
                var strft = new Font("Arial", 6);
                var strsz = e.Graphics.MeasureString(str,strft);
                e.Graphics.DrawString(str,strft, new SolidBrush(Color.White), fillRect.X + (fillRect.Width/2)-(strsz.Width/2),fillRect.Y+fillRect.Height + 2);
            }
            e.Graphics.DrawLine(new Pen(Color.White), rect.X+_graphMargin-_barSeparation,rect.Y+_graphMargin,rect.X+_graphMargin-_barSeparation,rect.Y+rect.Height-_graphMargin);
            e.Graphics.DrawString("%",new Font("Arial",6), new SolidBrush(Color.White), rect.X+_graphMargin-_barSeparation-4,rect.Y+_graphMargin-10);
        }

        private bool _isGb;
        public void SetIsGb(bool b)
        {
            _isGb = b;
        }

        private double _allowance;
        public void SetAllowance(double p)
        {
            _allowance = p;
        }
    }
}
