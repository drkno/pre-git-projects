using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace ColorDropDown
{
    public class ColourComboBox : ComboBox
    {
        public ColourComboBox()
        {
            if (Items.Count != 0) return;
            Populate();
        }

        public Color Color
        {
            get { return SelectedItem != null ? (Color) SelectedItem : Color.Transparent; }
            set
            {
                if (Items.IndexOf(value) < 0) return;
                SelectedIndex = Items.IndexOf(value);
            }
        }

        public void Populate()
        {
            Items.Clear();
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            var col = typeof (Color).GetProperties(BindingFlags.Static | BindingFlags.Public).Where(
                c => c.PropertyType == typeof (Color)).Select(c => (Color) c.GetValue(c, null)).ToArray();
            for (var i = 0; i < col.Length; i++)
            {
                if (col[i] == Color.Transparent) continue;
                Items.Add(col[i]);
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                var color = (Color) Items[e.Index];
                e.Graphics.FillRectangle(new SolidBrush(e.BackColor), e.Bounds);
                e.Graphics.FillRectangle(new SolidBrush(color),
                                         new Rectangle(e.Bounds.X + 3, e.Bounds.Y + 3, e.Bounds.Height*2 - 8,
                                                       e.Bounds.Height - 6));
                e.Graphics.DrawString(color.Name, e.Font, new SolidBrush(e.ForeColor),
                                      new PointF(e.Bounds.Height*2, e.Bounds.Y + (e.Bounds.Height - e.Font.Height)/2));
                return;
            }
            base.OnDrawItem(e);
        }
    }
}