using System;
using System.Drawing;
using System.Windows.Forms;

namespace UsageMeter.GUI.Usage
{
    public partial class UsageBar : UserControl
    {
        public UsageBar()
        {
            InitializeComponent();
        }

        bool _gb;
        double _usageAmount;

        public void SetUsage(double usage)
        {
            _usageAmount = usage;
        }

        public void SetIsGb(bool isGb) {
            _gb = isGb;
        }

        Color _bgndColour, _beginColour, _endColour, _eightyColour, _ninetyColour, _borderColour;
        double _allowance;

        public void SetBgndColor(Color backgroundColor) {
            _bgndColour = backgroundColor;
        }

        public void SetBeginColor(Color bColor) {
            _beginColour = bColor;
        }

        public void SetEndColor(Color eColor) {
            _endColour = eColor;
        }

        public void Set80PercentColour(Color eColor) {
            _eightyColour = eColor;
        }

        public void Set90PercentColour(Color nColor) {
            _ninetyColour = nColor;
        }

        public void SetBorderColour(Color bColor) {
            _borderColour = bColor;
        }

        public void SetAllowance(double allowancenum) {
            _allowance = allowancenum;
        }

        public Color CurrentBarColour(double derivedPoint) {
            if(_beginColour.IsEmpty || _endColour.IsEmpty){
                _beginColour = Color.LawnGreen;
                _endColour = Color.Red;
            }
            if(derivedPoint <= 70.0){ return _beginColour; }
    
            if(_eightyColour.IsEmpty || _ninetyColour.IsEmpty){
                _eightyColour = Color.Yellow;
                _ninetyColour = Color.Orange;
            }
    
            Color colour1, colour2; var pt = 0.0;
            if(derivedPoint <= 80.0)
            {
                colour1 = _beginColour; 
                colour2 = _eightyColour; 
                pt = (derivedPoint - 70.0)/10.0;
            }
            else if(derivedPoint <= 90.0)
            {
                colour1 = _eightyColour; 
                colour2 = _ninetyColour; 
                pt = (derivedPoint - 80.0)/10.0;
            }
            else if(derivedPoint >= 100)
            {
                colour1 = _endColour;
                colour2 = _endColour;
                pt = 1.0;
            }
            else 
            { 
                colour1 = _ninetyColour; 
                colour2 = _endColour; 
                pt = (derivedPoint - 90.0)/10.0; 
            }


            float[] beginComponents = {colour1.R, colour1.G, colour1.B};
            float[] endComponents = {colour2.R, colour2.G, colour2.B};
            var resultant = new[] {0.0, 0.0, 0.0};
    
            for (var i = 0; i < 3; i++)
            {
                
                resultant[i] = beginComponents[i] * (1.0-pt);
                resultant[i] += endComponents[i] * pt;
                Console.WriteLine(resultant[i]);
            }

            return Color.FromArgb((int) (resultant[0]), (int) (resultant[1]), (int) (resultant[2]));
        }

        public void SetNeedsUpdating()
        {
            Invalidate();
            Update();
        }

        private void UsageBarPaint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(0,0,Width,Height);
            // Make sure a background colour is set
            if(_bgndColour.IsEmpty){ SetBgndColor(Color.Blue); }
            // Fill the background colour
            e.Graphics.Clear(_bgndColour);
    
            // Fill Usage Bar using derived colour
            var usageRect = rect;
            usageRect.Width = (int)(rect.Width * ((_usageAmount >= 100)?1.0:(_usageAmount / 100.0)));

            e.Graphics.FillRectangle(new SolidBrush(CurrentBarColour(_usageAmount)),usageRect);
    
            // Check that border has a colour
            if(_borderColour.IsEmpty){ _borderColour = Color.LightGray; }
    
            // Set Border of UsageBar
            const int borThick = 1;
            e.Graphics.DrawRectangle(new Pen(_borderColour, borThick), rect.X + borThick/2, rect.Y + borThick / 2, rect.Width - borThick, rect.Height - borThick);
    
            // Draw Triangles
            var xpos1 = (_usageAmount <= 100.0) ? (int)(rect.Width * (_usageAmount / 100.0) - 8.0) : rect.Width - 8;
            var xpos2 = (_usageAmount <= 100.0) ? (int)((rect.Width * (_usageAmount / 100.0)) + 8.0) : rect.Width + 8;
            var xpos3 = (_usageAmount <= 100.0) ? (int) (rect.Width*(_usageAmount/100.0)) : 100;
            e.Graphics.FillPolygon(new SolidBrush(_borderColour),new[]{new Point(xpos1, 0), new Point(xpos2, 0), new Point(xpos3, rect.Height/6)});
            e.Graphics.FillPolygon(new SolidBrush(_borderColour), new[] { new Point(xpos1, rect.Height), new Point(xpos2, rect.Height), new Point(xpos3, (int)(rect.Height - rect.Height / 6.0)) });

            // Draw "Usage Meter" and Allowance

            // generate contrasting colour for text:
            var col = CurrentBarColour(_usageAmount);
            var y = 0.2126 * col.R + 0.7152 * col.G + 0.0722 * col.B;
            col = (y > 0.4) ? Color.Black : Color.Gainsboro;
            var font = new Font("Arial",7);
            var ht = e.Graphics.MeasureString("U", font).Height;
            e.Graphics.DrawString("USAGE METER",font,new SolidBrush(col),5,rect.Height-5-ht);
            font = new Font("Arial",8,FontStyle.Bold);
            var allowanceDisp = (_gb) ? (_allowance.ToString("0.00") + "GB") : (_allowance.ToString("0.") + "MB");
            e.Graphics.DrawString(allowanceDisp, font, new SolidBrush(col),5,rect.Height-5-ht-e.Graphics.MeasureString(allowanceDisp,font).Height);

            // Draw Used Percentage
            var percentageRect = new Rectangle(0,0,80,20);
            percentageRect.X = (int)(rect.Width/2.0 - percentageRect.Width/2.0);
            percentageRect.Y = (int)(rect.Height/2.0 - percentageRect.Height/2.0);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb((int)(0.5*255.0),Color.Black)), percentageRect);
            font = new Font("Arial",8);
            var percentUsedStr = _usageAmount.ToString("0.00") + "%";
            var pt = e.Graphics.MeasureString(percentUsedStr, font);
            e.Graphics.DrawString(percentUsedStr,font,new SolidBrush(Color.White), (float)(rect.Width/2.0 - pt.Width/2.0), (float)(rect.Height/2.0 - pt.Height/2.0));
        }
    }
}
