using System;
using System.Net;
using System.Text.RegularExpressions;

namespace COSMOS_Digital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Wind _win;
        private int _numOfIssues;

        public MainWindow(Wind window)
        {
            InitializeComponent();
            _win = window;
        }

        private void WindowContentRendered(object sender, EventArgs e)
        {
            try
            {
                var x = new WebClient();
                x.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:11.0) Gecko/20100101 Firefox/11.0");
                var source = x.DownloadString("http://cosmos.realviewdigital.com/");
                var title =
                    Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).
                        Groups["Title"].Value;
                title = title.Substring(15, 2);
                if (int.TryParse(title, out _numOfIssues) == false)
                {
                    _numOfIssues = 0;
                }
            }
            catch
            {
                _numOfIssues = 0;
            }
            _win.SetIssueNum(_numOfIssues);
            Close();
        }
    }
}