using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace UsageMeter
{
    public partial class UsageForm : Form
    {
        private const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/13.1";
        private const string Error =
            "Usage Meter failed (crashed) somewhere, I don't know what, how, who, why, whether or whence this happened but it did.\n\nIt's all your fault.\n\nThe technical crap of the problem to pass onto Matthew (mmakereti@gmail.com):\n";

        private double _allowance, _barGreenYellow;
        private int _connectnum = 2;
        private double _cost;
        private bool _gigabyte;
        private double _usagePercent, _used;
        private string _allowDisp = "";
        private int _barHeight, _barWidth, _barX, _barY;

        public UsageForm()
        {
            InitializeComponent();
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
            _barX = 5;
            _barHeight = 27;
            _barY = Height - _barHeight - _barX;
            _barWidth = Width - 2*_barX;

            var bgnd = new Random();
            BackColor = Color.FromArgb(bgnd.Next(0, 255), bgnd.Next(0, 255), bgnd.Next(0, 255));
            Invalidate();
            _background = new Thread(GetInfo);
            _background.Start();
            
        }

        private Thread _background;

        private void GetInfo()
        {
            Invoke(new MethodInvoker(delegate
            {
                Cursor = Cursors.WaitCursor;
                statusLabel.Text = "Loading Data...";
            }));
            

            switch (_connectnum)
            {
                    //*
                case 1:
                    _gigabyte = false;
                    _cost = 80.0;
                    GetTelecomInfo();
                    break;
                case 2:
                    _gigabyte = true;
                    _cost = 10.0;
                    GetKinectInfo();
                    break;

                    //*/ case 2:
                    // _gigabyte = true;
                    // _cost = 50.0;
                    // _allowance = 1024;
                    // _used = 512;
                    // break;
                default:
                    MessageBox.Show(Error + "Invalid connection number.", "Oh, Fiddlesticks!", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;
            }
            Invoke(new MethodInvoker(delegate
            {
                Cursor = Cursors.Default;
            }));
            _background.Abort();
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
                MessageBox.Show(Error + ex.Message, "Oh, Fiddlesticks!", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void WebsiteLinkClicked(object sender, EventArgs e)
        {
            try
            {
                switch (_connectnum)
                {
                    case 1:
                        Process.Start("http://www.telecom.co.nz");
                        break;
                    case 2:
                        Process.Start("http://www.kinect.co.nz");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Error + ex.Message, "Oh, Fiddlesticks!", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void GetTelecomInfo()
        {
            try
            {
                var getHttp =
                    (HttpWebRequest)
                    WebRequest.Create("https://www.telecom.co.nz/mbbmeter2?accountnum=247070176&refnum=247068058");
                getHttp.UserAgent = UserAgent;
                var respHttp = (HttpWebResponse) getHttp.GetResponse();
// ReSharper disable AssignNullToNotNullAttribute
                var streamHttp = new StreamReader(respHttp.GetResponseStream());
// ReSharper restore AssignNullToNotNullAttribute
                while (!streamHttp.EndOfStream)
                {
                    var inputline = streamHttp.ReadLine();
                    if (inputline != null && inputline.Contains("<div id='usage'>"))
                    {
                        inputline = inputline.Substring(
                            inputline.IndexOf("<div id='usage'>", StringComparison.Ordinal) + 16,
                            inputline.IndexOf("</div>", StringComparison.Ordinal) -
                            (inputline.IndexOf("<div id='usage'>", StringComparison.Ordinal) + 16));
                        _used = double.Parse(inputline.Substring(0, inputline.IndexOf(" ", StringComparison.Ordinal)));
                    }
                    else if (inputline != null && inputline.Contains("<center><b>"))
                    {
                        inputline = inputline.Substring(inputline.IndexOf("<center><b>", StringComparison.Ordinal) + 11,
                                                        inputline.IndexOf("</b></center>", StringComparison.Ordinal) -
                                                        (inputline.IndexOf("<center><b>", StringComparison.Ordinal) + 11));
                        _allowance =
                            double.Parse(inputline.Substring(0, inputline.IndexOf(" ", StringComparison.Ordinal)));
                    }
                    else if (inputline != null && inputline.Contains("<b>Last recorded activity:</b></td><td>"))
                    {
                        inputline =
                            inputline.Substring(
                                inputline.IndexOf("<b>Last recorded activity:</b></td><td>", StringComparison.Ordinal) +
                                39,
                                inputline.IndexOf("</td></tr></table>", StringComparison.Ordinal) -
                                (inputline.IndexOf("<b>Last recorded activity:</b></td><td>", StringComparison.Ordinal) +
                                 39));
                        Invoke(new MethodInvoker(delegate
                        {
                            statusLabel.Text = "Usage Data as at " + inputline;
                        }));
                    }
                }

                DisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Error + ex.Message, "Oh, Fiddlesticks!", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void DisplayData()
        {
            Invoke(new MethodInvoker(delegate
            {
                _allowDisp = _allowance.ToString(CultureInfo.InvariantCulture) + ((_gigabyte) ? " GB" : " MB");
                remainLabel.Text = "Remaining: " + (_allowance - _used).ToString(CultureInfo.InvariantCulture) +
                                   ((_gigabyte) ? " GB" : " MB") + ", " +
                                   (((_allowance - _used) / _allowance) * 100).ToString("0.00") + "%";
                usedLabel.Text = _used.ToString(CultureInfo.InvariantCulture) + ((_gigabyte) ? " GB" : " MB") + "\r\n" +
                                 ((_used / _allowance) * 100).ToString("0.00") + "%";
                UsageBarCalc();
                Warning();
                Invalidate();
                Refresh();
            }));
        }

        private void GetKinectInfo()
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create("http://membercentre.kinect.co.nz/");
                webRequest.CookieContainer = new CookieContainer();
                webRequest.UserAgent = UserAgent;
                webRequest.Referer = "http://membercentre.kinect.co.nz/";
                webRequest.Method = "POST";
                var st = webRequest.GetRequestStream();
                var byteArray = Encoding.UTF8.GetBytes("__EVENTTARGET=ctl00%24LogonContent%24ucLogin1%24cmdLogin&__EVENTARGUMENT=&__VIEWSTATE=%2FwEPDwUKLTI5Njg5Nzg2NGRkdCcTC%2BEJO%2BiLh85mKk4Je34n8EI%3D&__EVENTVALIDATION=%2FwEWBQKut8%2FmDgLatIGsCAKak%2BuzCQKel9S8AwL657DoA4ZfFwyFRupdrm%2BVmpDpY4qehzCq&ctl00%24LogonContent%24ucLogin1%24txtUserName=godfrey.m&ctl00%24LogonContent%24ucLogin1%24txtPassword=");
                st.Write(byteArray, 0, byteArray.Length);
                st.Close();
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.GetResponse();
                var cookieJar = webRequest.CookieContainer;

                webRequest = (HttpWebRequest)WebRequest.Create("https://ips.kinect.co.nz/Service/ExternalViewUsage/2271");
                webRequest.AllowAutoRedirect = true;
                webRequest.UserAgent = UserAgent;
                webRequest.CookieContainer = cookieJar;
                webRequest.Referer = "http://membercentre.kinect.co.nz/SelfService.aspx";

                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                var stream = webResponse.GetResponseStream();
                if (stream == null) throw new Exception("Response unable to be phrased.");
                var streamReader = new StreamReader(stream);
                var next = false;
                _used = 0;
                while (!streamReader.EndOfStream)
                {
                    var str = streamReader.ReadLine();
                    if (str != null && next)
                    {
                        str = Regex.Replace(str, "[^0-9.]", "");
                        if (_used.Equals(0))
                        {
                            _used = double.Parse(str);
                        }
                        else
                        {
                            _allowance = double.Parse(str);
                            break;
                        }
                        next = false;
                        continue;
                    }

                    if (str != null && (str.Contains("<label for=\"UsageDetail_Usage\">Usage:</label>") || str.Contains("<label for=\"UsageDetail_Allowance\">Allowance:</label>")))
                    {
                        next = true;
                    }
                }
                streamReader.Close();

                Invoke(new MethodInvoker(delegate
                {
                    statusLabel.Text = "Usage as at " + DateTime.Now.ToString(CultureInfo.InvariantCulture);
                }));
                DisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Error + ex.Message, "Oh, Fiddlesticks!", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void Warning()
        {
            if (_usagePercent >= 90 && _usagePercent < 100)
            {
                MessageBox.Show("You have exceeded 90% of your internet allowance.","WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (_usagePercent >= 100)
            {
                MessageBox.Show(
                    "You have now been charged another " + _cost.ToString("c") + " for another " + _allowDisp +
                    ". If you do this again you could be charged at an exorbatant rate per MB.", "Usage Meter",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (statusLabel.Text.Contains("Loading"))
            {
                statusLabel.Text = "For this usage month you have used no data.";
            }
        }

        private void ButtonNextClick(object sender, EventArgs e)
        {
            _connectnum = (_connectnum == 1) ? 2 : 1;
            CreateGraphics().Clear(Color.Blue);
            _background = new Thread(GetInfo);
            _background.Start();
        }

        private void ButtonMouseEnter(object sender, EventArgs e)
        {
            ((Label) sender).ForeColor = Color.Yellow;
        }

        private void ButtonMouseLeave(object sender, EventArgs e)
        {
            ((Label) sender).ForeColor = Color.White;
        }

        private void ButtonMouseDown(object sender, MouseEventArgs e)
        {
            ((Label) sender).ForeColor = Color.Red;
        }

        private void ButtonMouseUp(object sender, MouseEventArgs e)
        {
            ((Label) sender).ForeColor = Color.Yellow;
        }

        private void UsageBarCalc()
        {
            _usagePercent = (_used/_allowance)*100;
            _barGreenYellow = (_usagePercent < 100) ? (_usagePercent/100) : 0;

            usedLabel.Location =
                new Point((int) (_barWidth*((_usagePercent < 100) ? _barGreenYellow : 1)) + _barX - usedLabel.Width/2,
                          _barY - 2 - 10 - usedLabel.Height);
            if (usedLabel.Location.X >= Width - usedLabel.Width)
            {
                usedLabel.TextAlign = ContentAlignment.MiddleRight;
                usedLabel.Location = new Point(Width - usedLabel.Width, usedLabel.Location.Y);
            }
            else if (usedLabel.Location.X <= 0)
            {
                usedLabel.TextAlign = ContentAlignment.MiddleLeft;
                usedLabel.Location = new Point(0, usedLabel.Location.Y);
            }
            else
            {
                usedLabel.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void UsageFormPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), _barX, _barY, _barWidth, _barHeight);
            e.Graphics.FillRectangle(
                new SolidBrush(((_usagePercent >= 80) ? Color.Yellow : Color.LawnGreen)), _barX, _barY,
                (int) (_barWidth*_barGreenYellow), _barHeight);
            if (_usagePercent >= 100)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), _barX, _barY, _barWidth, _barHeight);
            }
            e.Graphics.DrawRectangle(new Pen(Color.Gray, 2), _barX, _barY, _barWidth, _barHeight);
            var size = e.Graphics.MeasureString(_allowDisp, Font);
            e.Graphics.DrawString(_allowDisp, Font, new SolidBrush(Color.Black), (Width - size.Width) / 2,
                                   ((_barY + (_barHeight/2)) - size.Height/2));

            Point[] points =
                {
                    new Point((int) (_barWidth*((_usagePercent < 100) ? _barGreenYellow : 1)) + _barX - 4,
                              _barY - 2 - 10),
                    new Point((int) (_barWidth*((_usagePercent < 100) ? _barGreenYellow : 1)) + _barX + 4,
                              _barY - 2 - 10),
                    new Point((int) (_barWidth*((_usagePercent < 100) ? _barGreenYellow : 1)) + _barX,
                              _barY - 2)
                };
            e.Graphics.DrawPolygon(new Pen(Color.Gray, 2), points);
            e.Graphics.FillPolygon(new SolidBrush(Color.White), points);
        }
    }
}
