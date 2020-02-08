using System;
using System.Linq;
using System.Windows.Forms;
using UsageMeter.Retreivers;

namespace UsageMeter.GUI.Phone
{
    public partial class PhoneCallDisplay : Form
    {
        public PhoneCallDisplay(IInternetAndPhoneData list)
        {
            InitializeComponent();
            var phoneCalls = list.GetPhoneCalls().ToArray();
            foreach (var t in phoneCalls)
            {
                var item = new ListViewItem(t.FromNumber);
                item.SubItems.Add(t.NumberCalled);
                item.SubItems.Add(t.RawNumber);
                item.SubItems.Add(t.Cost.ToString("C"));
                item.SubItems.Add(t.Discount.ToString("C"));
                item.SubItems.Add(t.DateTime.ToString("d"));
                item.SubItems.Add(t.DateTime.ToString("t"));
                var timespan = TimeSpan.FromSeconds(t.Duration);
                item.SubItems.Add(timespan.Hours + ":" + timespan.Minutes.ToString("00") + 
                    ":" + timespan.Seconds.ToString("00") + "." + timespan.Milliseconds);
                item.SubItems.Add(t.CallType.ToString());
                listViewPhoneCalls.Items.Add(item);
            }
        }
    }
}
