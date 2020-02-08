#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace DataGraph
{
    public sealed partial class Graph : UserControl
    {
        private double[] _dataPoints;
        private LinearGradientBrush _gradientBrush;
        private Color _lowerColour = Color.GreenYellow;
        private Color _upperColour = Color.Red;
        private Color _trendlineColour = Color.Red;

        public Graph()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public bool FiguresOnBars { get; set; }
        public string[] BarFigures { get; set; }
        public bool UpperBoundScaling { get; set; }
        public double UpperBoundScalingValue { get; set; }
        public string YAxisLabel { get; set; }
        public bool ShowYAxis { get; set; }
        public bool Seperator { get; set; }
        public int SeperatorWidth { get; set; }
        public bool ShowTrendline { get; set; }

        public Color TrendlineColor
        {
            get { return _trendlineColour; }
            set { _trendlineColour = value; }
        }

        private LinearGradientBrush GradientBrush
        {
            get { return _gradientBrush ?? (_gradientBrush = GenerateNewBrush()); }
        }

        public Color LowerColour
        {
            get { return _lowerColour; }
            set
            {
                _gradientBrush = GenerateNewBrush();
                _lowerColour = value;
            }
        }

        public Color UpperColour
        {
            get { return _upperColour; }
            set
            {
                _gradientBrush = GenerateNewBrush();
                _upperColour = value;
            }
        }

        public double[] DataPoints
        {
            get { return _dataPoints; }
            set
            {
                if (value == null) return;
                _dataPoints = value;
                Refresh();
            }
        }

        private double CalculateRelativeHeight(int pos)
        {
            return DataPoints[pos]/DataPoints.Max();
        }

        private Color CalculateColour(double percentage)
        {
            if (percentage >= 1.0)
            {
                return UpperColour;
            }

            if (percentage <= 0.0)
            {
                return LowerColour;
            }

            var r = (double) Convert.ToInt32(UpperColour.R) - Convert.ToInt32(LowerColour.R);
            var g = (double) Convert.ToInt32(UpperColour.G) - Convert.ToInt32(LowerColour.G);
            var b = (double) Convert.ToInt32(UpperColour.B) - Convert.ToInt32(LowerColour.B);

            r *= percentage;
            g *= percentage;
            b *= percentage;

            r += LowerColour.R;
            g += LowerColour.G;
            b += LowerColour.B;

            return Color.FromArgb((int) r, (int) g, (int) b);
        }

        private LinearGradientBrush GenerateNewBrush()
        {
            var upperColour = UpperColour;
            if (!UpperBoundScaling)
                return new LinearGradientBrush(new Rectangle(new Point(0, 0), Size), upperColour, LowerColour, 90.0f);
            var max = DataPoints.Max();
            max /= UpperBoundScalingValue;
            upperColour = CalculateColour(max);
            return new LinearGradientBrush(new Rectangle(new Point(0, 0), Size), upperColour, LowerColour, 90.0f);
        }

        private void DrawBar(Graphics graphics, int xPos, double relativeHeight)
        {
            var wid = ((float) Bounds.Width/DataPoints.Length);
            var pos = xPos*wid;
            var barRect = new RectangleF(pos, (float) (Bounds.Height - Bounds.Height*relativeHeight), wid,
                (float) (Bounds.Height*relativeHeight));
            graphics.FillRectangle(GradientBrush, barRect);

            if (Seperator)
            {
                graphics.DrawLine(new Pen(BackColor, SeperatorWidth), pos - SeperatorWidth/2.0f, 0,
                    pos - SeperatorWidth/2.0f, Height);
            }
        }

        //private Color GetContrastingColour()
        private void DrawUsed(Graphics graphics, int xPos)
        {
            if (xPos >= BarFigures.Length)
            {
                return;
            }

            var wid = (int) ((double) Bounds.Width/DataPoints.Length);
            var pos = xPos*wid;

            var stringSize = graphics.MeasureString(BarFigures[xPos], Font);
            var verticalDistance = Height/2.0f;
            verticalDistance -= stringSize.Height/2.0f;

            graphics.DrawString(BarFigures[xPos], Font, Brushes.DarkGray, pos + wid/2.0f - stringSize.Width/2.0f,
                verticalDistance);
        }

        private void DrawLine(Graphics graphics)
        {
            var points = new List<PointF>();
            var wid = (int) ((double) Bounds.Width/DataPoints.Length);
            points.Add(new PointF(wid/2.0f, (float)(Bounds.Height - Bounds.Height*CalculateRelativeHeight(0))));
            for (var i = 1; i < DataPoints.Length - 1; i++)
            {
                var height = (Bounds.Height - Bounds.Height*CalculateRelativeHeight(i)) +
                             (Bounds.Height - Bounds.Height*CalculateRelativeHeight(i - 1)) +
                             (Bounds.Height - Bounds.Height*CalculateRelativeHeight(i + 1));
                height /= 3.0f;
                points.Add(new PointF(i*wid + wid/2.0f, (float)height));
            }
            points.Add(new Point((DataPoints.Length - 1)*wid + wid/2,
                (int) (Bounds.Height - Bounds.Height*CalculateRelativeHeight(DataPoints.Length - 1))));
            var graphicsPath = new GraphicsPath(FillMode.Winding);
            graphicsPath.AddCurve(points.ToArray());
            graphics.DrawPath(new Pen(_trendlineColour), graphicsPath);
        }

        private void GraphPaint(object sender, PaintEventArgs e)
        {
            if (DataPoints.Length == 0) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(BackColor);
            for (var i = 0; i < DataPoints.Length; i++)
            {
                DrawBar(e.Graphics, i, CalculateRelativeHeight(i));
                if (FiguresOnBars)
                {
                    DrawUsed(e.Graphics, i);
                }
            }
            if(ShowTrendline) DrawLine(e.Graphics);
        }
    }
}