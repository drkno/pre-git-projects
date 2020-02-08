using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UsageMeter
{
    public partial class UsageDoughnut : UserControl
    {
        private float _penWidth = 1;

        public UsageDoughnut()
        {
            InitializeComponent();
        }

        public float PenWidth
        {
            get { return _penWidth; }
            set { _penWidth = value; }
        }

        public List<Tuple<string, float, Color>> Sections { get; set; }

        private void UsageDoughnutPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            var di = GetMaxRadius() * 2;
            var startPos = GetMaxRadiusPosition();
            e.Graphics.FillPie(Brushes.LightGray, startPos.X, startPos.Y, di, di, 0.0f, 360.0f);
            //e.Graphics.DrawEllipse(Pens.Black, startPos.X, startPos.Y, di - PenWidth, di - PenWidth);
            if (Sections == null) return;
            var startAngle = 0.0f;
            foreach (var section in Sections)
            {
                var pt = GetPositionOnCircle(startAngle + section.Item2 / 2, di / 2.0f);
                var center = GetCenterPoint();
                pt.X += center.X;
                pt.Y += center.Y;
                var pieBrush = new LinearGradientBrush(pt, GetCenterPoint(), section.Item3, Color.LightGray);
                e.Graphics.FillEllipse(Brushes.Black, pt.X, pt.Y, 5.0f, 5.0f);
                e.Graphics.FillPie(pieBrush, startPos.X, startPos.Y, di, di, startAngle, section.Item2);
                //e.Graphics.FillPie(new SolidBrush(section.Item3), startPos.X, startPos.Y, di, di, startAngle, section.Item2);
                //e.Graphics.DrawArc(new Pen(section.Item3, PenWidth), startPos.X, startPos.Y, di - PenWidth, di - PenWidth, startAngle, section.Item2);
                startAngle += section.Item2;
            }
        }

        private PointF GetCenterPoint()
        {
            var x = Width / 2.0f;
            var y = Height / 2.0f;
            return new PointF(x, y);
        }

        private int GetMaxRadius()
        {
            var radius = Width > Height ? Height : Width;
            return radius/2;
        }

        private PointF GetMaxRadiusPosition()
        {
            var rad = GetMaxRadius();
            var centerPoint = GetCenterPoint();
            centerPoint.X -= rad;
            centerPoint.Y -= rad;
            return centerPoint;
        }

        private PointF GetPositionOnCircle(float angle, float radius)
        {
            angle = (float)(angle/(180.0f/Math.PI));
            var centerPoint = GetCenterPoint();
            var result = new PointF(0.0f, 0.0f);
            
            centerPoint.Y = (float) Math.Round(centerPoint.Y + radius*Math.Sin(angle));
            centerPoint.X = (float) Math.Round(centerPoint.X + radius*Math.Cos(angle));
            return result;
        }
    }
}
