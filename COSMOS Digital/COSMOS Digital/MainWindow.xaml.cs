using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using Microsoft.Win32;

namespace COSMOS_Digital
{
    /// <summary>
    /// Interaction logic for Wind.xaml
    /// </summary>
    /// 
    internal struct CosmosInfo
    {
        public CookieContainer CosmosCookies;

        public string FullAccountName;
        public bool LoggedIn;
        public string Password;
        public double Random;
        public string Username;
    }

    public partial class Wind
    {
        private const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
        private static CosmosInfo _userInformation;
        private int _numOfIssues;

        public Wind()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var splash = new MainWindow(this);
            splash.ShowDialog();
        }

        public void SetIssueNum(int num)
        {
            _numOfIssues = num;
        }

        private void ButtonExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSaveClick(object sender, RoutedEventArgs e)
        {
            tabController.SelectedValue = 2;
            tabItemSave.Focus();
        }

        private void ButtonGenerateClick(object sender, RoutedEventArgs e)
        {
            tabController.SelectedValue = 3;
            tabItemGen.Focus();
            textBoxIssueNum.Focus();
        }

        private void ButtonGenerateLinksClick(object sender, RoutedEventArgs e)
        {
            int issueNum, numPages;
            if (int.TryParse(textBoxIssueNum.Text, out issueNum) && int.TryParse(textBoxTotPages.Text, out numPages))
            {
                if (issueNum < 0 || (issueNum > _numOfIssues && _numOfIssues != 0))
                {
                    MessageBox.Show("Issues below 0 and above " + _numOfIssues + " do not exist.", "A Problem Occured",
                                    MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                textBoxLinks.Text = String.Empty;
                for (int i = 2; i <= numPages; i++)
                {
                    textBoxLinks.Text +=
                        "http://images.cosmos.realviewdigital.com/rvimageserver/Luna%20Media/Cosmos/Issue%20";
                    textBoxLinks.Text += issueNum;
                    if (i < 10)
                    {
                        textBoxLinks.Text += "/page000000";
                    }
                    else if (i < 100)
                    {
                        textBoxLinks.Text += "/page00000";
                    }
                    else
                    {
                        textBoxLinks.Text += "/page0000";
                    } // if
                    textBoxLinks.Text += i + ".jpg" + Environment.NewLine;
                } // for
            }
            else
            {
                MessageBox.Show("Please enter correct values.", "A Problem Occured", MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
        }

        private void ButtonDownloadClick(object sender, RoutedEventArgs e)
        {
            progressBar.Value = 0;
            _userInformation.Username = textBoxUsername.Text;
            _userInformation.Password = textBoxPassword.Password;
            _userInformation.Random = new Random().NextDouble();
            if (_userInformation.LoggedIn != true)
            {
                _userInformation.LoggedIn = false;
            }
            _userInformation.FullAccountName = "";

            int pages, issue;
            if ((int.TryParse(textBoxTotalPages.Text, out pages) == false && checkBoxAuto.IsChecked == false) ||
                int.TryParse(textBoxIssueNo.Text, out issue) == false)
            {
                MessageBox.Show("Please enter a valid number of pages and a valid issue number.", "Invalid Number(s)",
                                MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (_numOfIssues != 0 && (issue > _numOfIssues || issue < 1))
            {
                MessageBox.Show("Please enter a valid issue number.", "Invalid Number(s)", MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
                return;
            }

            if (checkBoxAuto.IsChecked == true)
            {
                pages = 400;
            }

            if (_numOfIssues == 0)
            {
                switch (
                    MessageBox.Show(
                        "On stating this application it was detected that you have no connection to the internet. Do you wish to continue?",
                        "Internet Required", MessageBoxButton.YesNo, MessageBoxImage.Question))
                {
                    case MessageBoxResult.Yes:
                        break;
                    case MessageBoxResult.No:
                        return;
                }
            }

            if (AuthenticateWithCosmos() == false)
            {
                return;
            }
            labelLoggedInAs.Content = "Logged in as " + _userInformation.FullAccountName;
            labelLoggedInAs.Refresh();
            var a = new List<string>();

            for (int i = 2; i <= pages; i++)
            {
                a.Add("http://images.cosmos.realviewdigital.com/rvimageserver/Luna%20Media/Cosmos/Issue%20");
                a[(i - 2)] += issue.ToString(CultureInfo.InvariantCulture);
                if (i < 10)
                {
                    a[(i - 2)] += "/page000000";
                }
                else if (i < 100)
                {
                    a[(i - 2)] += "/page00000";
                }
                else
                {
                    a[(i - 2)] += "/page0000";
                } // if
                a[(i - 2)] += i + ".jpg";
            } // for

            try
            {
                if (!Directory.Exists(textBoxLocation.Text))
                {
                    Directory.CreateDirectory(textBoxLocation.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was something wrong with the file path provided.", "Error", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                Console.WriteLine("Creating or verifing folder location failed.\n\nRAW ERROR:\n" + ex.Message);
                return;
            }

            if (DownloadImages(a.ToArray(), textBoxLocation.Text)) return;
            MessageBox.Show("Something failed I think...", "Error 40-something", MessageBoxButton.OK,
                            MessageBoxImage.Error);
            Console.WriteLine("Downloading Images Failed");
        }

        private bool AuthenticateWithCosmos()
        {
            if (_userInformation.LoggedIn)
            {
                return true;
            }

            try
            {
                var authRequest = (HttpWebRequest) WebRequest.Create("http://cosmos.realviewdigital.com/?iid=38263");
                authRequest.UserAgent = UserAgent;
                authRequest.AllowAutoRedirect = true;
                authRequest.CookieContainer = new CookieContainer();
                var authResponse = (HttpWebResponse) authRequest.GetResponse();

                if (authResponse.StatusCode.ToString() != "OK")
                {
                    authResponse.Close();
                    Console.WriteLine(authResponse.StatusCode.ToString() + ": " + authResponse.StatusDescription);
                    MessageBox.Show("Login Failed", "Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return false;
                }
                _userInformation.CosmosCookies = authRequest.CookieContainer;
                authResponse.Close();

                authRequest =
                    (HttpWebRequest)
                    WebRequest.Create(
                        "http://cosmos.realviewdigital.com/login.secure?publicationid=424&issueid=38500&user=" +
                        _userInformation.Username + "&password=" + _userInformation.Password + "&remme=false&rnd=" +
                        _userInformation.Random.ToString(CultureInfo.InvariantCulture));
                authRequest.UserAgent = UserAgent;
                authRequest.AllowAutoRedirect = true;
                authRequest.CookieContainer = _userInformation.CosmosCookies;
                authResponse = (HttpWebResponse) authRequest.GetResponse();

                using (var s = authResponse.GetResponseStream())
                {
                    if (s != null)
                    {
                        var sr = new StreamReader(s);
                        var input = "";
                        while (!sr.EndOfStream)
                        {
                            input += sr.ReadLine();
                        }
                        if (input.Contains("<AccessMessage>OK</AccessMessage>"))
                        {
                            _userInformation.LoggedIn = true;
                            var startindex = input.IndexOf("<FullName><![CDATA[", StringComparison.Ordinal) + 19;
                            var leng = input.IndexOf("]]></FullName>", StringComparison.Ordinal) - startindex;
                            _userInformation.FullAccountName = input.Substring(startindex, leng);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something failed I think...", "Error 40-something", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static int NumConnections = 4;

        private bool DownloadImages(IList<string> images, string outputDir)
        {
            try
            {
                if (_userInformation.LoggedIn == false)
                {
                    return false;
                }

                UpdateProgressBarDelegate updatePbDelegate = progressBar.SetValue;
                var step = 100/images.Count;
                labelTotal.Content = checkBoxAuto.IsChecked == true ? "Auto" : images.Count.ToString(CultureInfo.InvariantCulture);
                labelTotal.Refresh();

                for (var i = 0; i < images.Count; i++)
                {
                    labelCurrentNum.Content = (i + 1).ToString(CultureInfo.InvariantCulture);
                    labelCurrentNum.Refresh();

                    var thread = new Thread(DownloadImage);
                    thread.Start(new[]{images[i],outputDir});
                    while (NumConnections==0){}

                    /*
                    var httpWebRequest = (HttpWebRequest) WebRequest.Create(images[i]);
                    httpWebRequest.CookieContainer = _userInformation.CosmosCookies;
                    httpWebRequest.AllowWriteStreamBuffering = true;
                    httpWebRequest.UserAgent = UserAgent;
                    httpWebRequest.Timeout = 60000;
                    WebResponse webResponse = httpWebRequest.GetResponse();
                    Stream webStream = webResponse.GetResponseStream();
                    if (webStream != null)
                    {
                        Image imageStream = Image.FromStream(webStream);
                        webResponse.Close();

                        Console.WriteLine(Properties.Resources.Saving + images[i]);
                        imageStream.Save(outputDir + "\\" + images[i].Substring(images[i].LastIndexOf("/", StringComparison.Ordinal)));
                    }*/
                    Dispatcher.Invoke(updatePbDelegate, DispatcherPriority.Background,
                                      new object[] {RangeBase.ValueProperty, (progressBar.Value + step)});
                }
                progressBar.Value = 100;
                return true;
            }
            catch (Exception ex)
            {
                switch (checkBoxAuto.IsChecked)
                {
                    case true:
                        progressBar.Value = 100;
                        return true;
                    default:
                        MessageBox.Show("Something failed I think...", "Error 40-something", MessageBoxButton.OK,
                                        MessageBoxImage.Error);
                        Console.WriteLine(ex.Message);
                        return false;
                }
            }
        }

        private void DownloadImage(object data)
        {
            NumConnections--;
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(((string[])data)[0]);
                httpWebRequest.CookieContainer = _userInformation.CosmosCookies;
                httpWebRequest.AllowWriteStreamBuffering = true;
                httpWebRequest.UserAgent = UserAgent;
                httpWebRequest.Timeout = 60000;
                var webResponse = httpWebRequest.GetResponse();
                var webStream = webResponse.GetResponseStream();
                if (webStream != null)
                {
                    var imageStream = Image.FromStream(webStream);
                    webResponse.Close();
                    imageStream.Save(((string[])data)[1] + "\\" + ((string[])data)[0].Substring(((string[])data)[0].LastIndexOf("/", StringComparison.Ordinal)));
                }
            }
            catch (Exception)
            {
                NumConnections++;
                return;
            }
            NumConnections++;
        }

        private void ButtonBrowseForLocationClick(object sender, RoutedEventArgs e)
        {
            var saveFolder = new SaveFileDialog {Filter = "Folder Location|*.*"};
            if (saveFolder.ShowDialog() == true)
            {
                string file = saveFolder.FileName;
                file = file.Replace("\\", "/");
                if (file.Substring(file.Length - 1) != "/")
                {
                    file += "/";
                }

                textBoxLocation.Text = file;
            }
        }

        private void CheckBoxAutoChecked(object sender, RoutedEventArgs e)
        {
            if (checkBoxAuto.IsChecked == true)
            {
                textBoxTotalPages.Text = "Auto";
                textBoxTotalPages.IsReadOnly = true;
            }
            else
            {
                textBoxTotalPages.Text = "0";
                textBoxTotalPages.IsReadOnly = false;
            }
        }

        #region Nested type: UpdateProgressBarDelegate

        private delegate void UpdateProgressBarDelegate(DependencyProperty dp, Object value);

        #endregion
    }

    public static class ExtensionMethods
    {
        private static readonly Action EmptyDelegate = delegate { };

        public static void Refresh(this UIElement uiElement)
        {
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}