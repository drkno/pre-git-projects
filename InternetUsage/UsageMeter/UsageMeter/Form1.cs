using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;


namespace UsageMeter
{
    struct UsageCounter
    {
        // https://www.telecom.co.nz/mbbmeter2?accountnum=247070176&refnum=247068058

        public double TotalAllowance;
        public double CurrentUsage;
        public int BillingStartDay;

        public double TheoryPercentage()
        {
            if (DateTime.Now.Day < BillingStartDay)
            {
                int totalDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1);
                int daysLeft = totalDays - (DateTime.Now.Day - BillingStartDay);
                return (double)daysLeft / (double)totalDays * 100.00;
            }
            else
            {
                int totalDays = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
                int daysLeft = totalDays - (DateTime.Now.Day - BillingStartDay);
                return (double)daysLeft / (double)totalDays * 100.00;
            }
        }

        public double ActualPercentage()
        {
            return CurrentUsage / TotalAllowance * 100;
        }

        public double Remaining()
        {
            return TotalAllowance - CurrentUsage;
        }

        public double TheoryRemaining()
        {
            return (TheoryPercentage() / 100) * TotalAllowance;
        }

    }

    public partial class usageForm : Form
    {

        // Progress Bar Colours
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void SetPaused(ProgressBar input)
        {
            SendMessage(input.Handle, 0x410, 0x0003, 0);
        }
        private void SetError(ProgressBar input)
        {
            SendMessage(input.Handle, 0x410, 0x0002, 0);
        }
        private void SetNormal(ProgressBar input)
        {
            SendMessage(input.Handle, 0x410, 0x0001, 0);
        }


        public usageForm()
        {
            InitializeComponent();
        }

        private void quitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usageForm_Load(object sender, EventArgs e)
        {
            UsageBar.Step = 1;
            UsageBar.Value = 100;
            SetPaused(UsageBar);
            GetKinectInfo();
        }

        private void websiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.kinect.co.nz");
        }


        const string USER_AGENT = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/13.1";

        private void GetKinectInfo()
        {
            CookieContainer cookieJar;
            HttpWebRequest getHttp = (HttpWebRequest)HttpWebRequest.Create("http://kinect.co.nz");
            getHttp.UserAgent = USER_AGENT;
            getHttp.AllowAutoRedirect = true;
            getHttp.CookieContainer = new CookieContainer();
            HttpWebResponse respHttp = (HttpWebResponse)getHttp.GetResponse();

            if (respHttp.StatusCode.ToString() != "OK")
            {
                respHttp.Close();
            }
            cookieJar = getHttp.CookieContainer;
            respHttp.Close();

            getHttp = (HttpWebRequest)HttpWebRequest.Create("http://kinect.co.nz/");
            getHttp.UserAgent = USER_AGENT;
            getHttp.AllowAutoRedirect = true;
            getHttp.CookieContainer = cookieJar;
            respHttp = (HttpWebResponse)getHttp.GetResponse();


        }
    }
}
