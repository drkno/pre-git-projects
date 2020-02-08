using System.Windows.Forms;
using UsageMeter.Retreivers;

namespace UsageMeter.GUI.Usage
{
    public partial class UsageDataDisplay : Form
    {
        public UsageDataDisplay(IInternetData usageData)
        {
            InitializeComponent();
            foreach (var day in usageData.GetDaysOfUsage())
            {
                var usg = new ListViewItem(ToMbGb(day.TotalUsed));
                usg.SubItems.Add(ToMbGb(day.TotalDownload));
                usg.SubItems.Add(ToMbGb(day.TotalUpload));
                usg.SubItems.Add(day.Date.ToString("dd/MM/yyyy"));
                usg.SubItems.Add(ToMbGb(day.TotalAllowed));
                listViewUsageData.Items.Add(usg);
            }
        }

        private string ToMbGb(double amount)
        {
            var numDiv = 0;
            while (amount >= 1024.0 && numDiv < 4)
            {
                amount /= 1024.0;
                numDiv++;
            }

            var result = amount.ToString("0.00") + " ";

            switch (numDiv)
            {
                case 0: result += "B"; break;
                case 1: result += "KB"; break;
                case 2: result += "MB"; break;
                case 3: result += "GB"; break;
                case 4: result += "TB"; break;
            }

            return result;
        }
    }
}
