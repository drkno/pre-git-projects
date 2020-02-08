using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UsageMeter.GUI.Phone;
using System.Threading;
using UsageMeter.Retreivers;
using UsageMeter.Retreivers.Spark;

namespace UsageMeter.GUI.Usage
{
    public partial class UsageForm : Form
    {
        public UsageForm()
        {
            InitializeComponent();
            usageBar.MouseDown += DragEventMouseDown;
            usageGraph.MouseDown += DragEventMouseDown;
            panel1.MouseDown += DragEventMouseDown;
            usageBar.SetIsGb(true);
            usageGraph.SetIsGb(true);
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void QuitbtnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void UsageFormLoad(object sender, EventArgs e)
        {
            GetDataT();
        }

        private void DragEventMouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
            catch (Exception ex)
            {
                var crash = new Crash(ex);
                crash.ShowDialog();
                Environment.Exit(0);
            }
        }

        private void ButtonQuitMouseEnter(object sender, EventArgs e)
        {
            buttonQuit.BackColor = Color.Red;
        }

        private void ButtonQuitMouseLeave(object sender, EventArgs e)
        {
            buttonQuit.BackColor = Color.DarkRed;
        }

        private void ButtonBlueMouseEnter(object sender, EventArgs e)
        {
            ((Label) sender).BackColor = Color.LightSkyBlue;
        }

        private void ButtonBlueMouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Navy;
        }

        private void LoadingToggle()
        {
            panelLoading.Visible = !panelLoading.Visible;
        }

        private void ButtonWebsiteClick(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.spark.co.nz");
            } catch(Exception ex)
            {
                var crash = new Crash(ex);
                crash.ShowDialog();
                Environment.Exit(0);
            }
        }

        private void ButtonRefreshClick(object sender, EventArgs e)
        {
            LoadingToggle();
            GetDataT();
        }

        private void ButtonPhoneClick(object sender, EventArgs e)
        {
            try
            {
                if (_internetSource as IInternetAndPhoneData == null) return;
                var phoneData = (IInternetAndPhoneData) _internetSource;
                var phoneCallDisp = new PhoneCallDisplay(phoneData);
                phoneCallDisp.Show();
            }
            catch (Exception ex)
            {
                var crash = new Crash(ex);
                crash.ShowDialog();
                Environment.Exit(0);
            }
        }

        private void ButtonMoreClick(object sender, EventArgs e)
        {
            try
            {
                var usageDataDisp = new UsageDataDisplay(_internetSource);
                usageDataDisp.Show();
            }
            catch(Exception ex)
            {
                var crash = new Crash(ex);
                crash.ShowDialog();
                Environment.Exit(0);
            }
        }

        private readonly IInternetData _internetSource = new Spark();

        private void GetData()
        {
            var spark = _internetSource;
            try
            {
                var login = spark.GetLogin;
                if (login.LoginRequired)
                {
                    login.ShowDialog();
                    if (!login.DetailsWereProvided)
                    {
                        throw new Exception("Login was required, and you didn't login.");
                    }
                }
                spark.GetData();
            }
            catch (Exception e)
            {
                var crash = new Crash(e);
                crash.ShowDialog();
                Environment.Exit(-1);
            }

            double download, upload, overall, allowance;
            spark.GetInternetTotals(out download, out upload, out overall, out allowance);

            Invoke(new MethodInvoker(delegate
                                     {
                                         var gb = double.Parse(ToMbGb(allowance, false, ByteTypes.GB));
                usageBar.SetAllowance(gb);
                usageGraph.SetAllowance(gb);
                usageBar.SetUsage((overall / allowance) * 100.0);

                var res = spark.GetDaysOfUsage().Select(data => (data.TotalUsed / data.TotalAllowed) * 100.0).Select(dummy => dummy).ToList();
                usageGraph.SetData(res.ToArray());
                if (spark as IInternetAndPhoneData == null)
                {
                    buttonPhone.Hide();
                }
                labelAllowance.Text = ToMbGb(allowance);
                labelRemaining.Text = ToMbGb(allowance - overall);
                labelUsage.Text = ToMbGb(overall);
                labelLastRet.Text = DateTime.Now.ToString("dd/MM/yy HH:mm.ss");
                usageBar.SetNeedsUpdating();
                usageGraph.SetGraphNeedsUpdating();
                LoadingToggle();
            }));
        }

        private void GetDataT()
        {
            var thread = new Thread(GetData);
            thread.Start();
        }

        enum ByteTypes
        {
            // ReSharper disable InconsistentNaming
            // ReSharper disable UnusedMember.Local
            B = 0,
            KB = 1,
            MB = 2,
            GB = 3,
            TB = 4,
            Auto = -1
            // ReSharper restore UnusedMember.Local
            // ReSharper restore InconsistentNaming
        }

        private static string ToMbGb(double amount, bool includeUnit = true, ByteTypes byteType = ByteTypes.Auto)
        {
            var neg = false;
            if (amount < 0)
            {
                amount *= -1;
                neg = true;
            }

            var numDiv = 0;
            while ((amount >= 1024.0 || byteType != ByteTypes.Auto) && numDiv < (int)(byteType == ByteTypes.Auto ? ByteTypes.TB : byteType))
            {
                amount /= 1024.0;
                numDiv++;
            }

            var result = amount.ToString("0.00");
            if (includeUnit)
            {
                result += " " + Enum.Parse(typeof(ByteTypes), numDiv.ToString(CultureInfo.InvariantCulture));
            }

            if (neg)
            {
                result = result.StartsWith("-") ? result.Substring(1) : "-" + result;
            }
            return result;
        }
    }
}