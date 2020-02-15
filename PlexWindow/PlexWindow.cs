using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;

namespace PlexWindow
{
    public partial class PlexWindow : Form
    {
        private Size size;
        private Point location;

        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);

        const int URLMON_OPTION_USERAGENT = 0x10000001;
        const int URLMON_OPTION_USERAGENT_REFRESH = 0x10000002;

        private void ChangeUserAgent()
        {
            const string ua = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:1.0) KnoxWindow/2.0 (like Mozilla, KHTML, Gecko, Webkit, Blink, Trident)";

            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT_REFRESH, null, 0, 0);
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, ua, ua.Length, 0);
        }

        public PlexWindow()
        {
            ChangeUserAgent();
            InitializeComponent();
            size = Size;
            location = Location;
            Activated += PlexWindow_Activated;
            Deactivate += PlexWindow_Deactivate;
            webBrowserControl.Navigate(new Uri("https://app.plex.tv/web"));
        }

        private void PlexWindow_Deactivate(object sender, EventArgs e)
        {
            size = Size;
            location = Location;
            FormBorderStyle = FormBorderStyle.None;
            Size = size;
        }

        private void PlexWindow_Activated(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            Size = size;
            Location = location;
        }

        private void WebBrowserControl_ContainsFullScreenElementChanged(object sender, object e)
        {
//            webBrowserControl.ful
        }

        private void WebBrowserControl_NavigationCompleted(object sender, WebViewControlNavigationCompletedEventArgs e)
        {
            Text = webBrowserControl.DocumentTitle;
        }
    }
}
