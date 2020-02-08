using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AreaCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            points = new List<PointF>();
            var OpenFile = new OpenFileDialog();
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(OpenFile.FileName);
            }
            else
            {
                Environment.Exit(0);
            }
            
        }

        private List<PointF> points;
        private Image img;
        private double ScaleF;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var width = img.Width;
            var height = img.Height;
            if (((double) Width/Height) > ((double) width/height))
            {
                ScaleF = (double)Height/height;
                height = Height;
                width = ((int)(width*ScaleF));
            }
            else if (((double)Width / Height) < ((double)width / height))
            {
                ScaleF = (double)Width / width;
                height = ((int)(height * ScaleF));
                width = Width;
            }
            else
            {
                ScaleF = (double)Width / width;
                width = Width;
                height = Height;
            }
            e.Graphics.DrawImage(img,0,0,width,height);

            if(points.Count < 3) return;
            var pts = new List<PointF>();
            foreach (var point in points)
            {
                var pt = new PointF((float)(point.X * ScaleF), (float)(point.Y * ScaleF));
                pts.Add(pt);
            }
            textBox2.Text = (PolygonArea(pts) * double.Parse(textBox1.Text)).ToString();
            e.Graphics.DrawPolygon(new Pen(Color.Red,2.0f), pts.ToArray());
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            var pt = new PointF((float)((MousePosition.X-Left-8.0f)/ScaleF),(float)((MousePosition.Y-Top-30.0f)/ScaleF));
            points.Add(pt);
            Refresh();
        }

        public static double PolygonArea(IEnumerable<PointF> polygon)
        {
            var e = polygon.GetEnumerator();
            if (!e.MoveNext()) return 0;
            PointF first = e.Current, last = first;

            double area = 0;
            while (e.MoveNext())
            {
                PointF next = e.Current;
                area += next.X * last.Y - last.X * next.Y;
                last = next;
            }
            area += first.X * last.Y - last.X * first.Y;
            return area / 2;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
