using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using UsageMeter.Retreivers.Spark.Internet;
using UsageMeter.Retreivers.Spark.Phone;

namespace UsageMeter.Retreivers.Spark
{
    class Spark : IInternetAndPhoneData
    {
        #region Login
        private readonly SparkLogin _login = new SparkLogin();
        public ILogin GetLogin { get { return _login; } }
        #endregion

        public Spark()
        {
            if (File.Exists("Spark.ini"))
            {
                try
                {
                    var reader = new StreamReader("Spark.ini");
                    _login.Username = reader.ReadLine();
                    _login.Password = reader.ReadLine();
                    _login.LoginRequired = false;
                    reader.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error reading Spark.ini: " + e.Message);
                    _login.LoginRequired = true;
                }
            }
            else
            {
                _login.LoginRequired = true;
            }
        }

        private List<PhoneCall> _phoneCalls;
        public void GetData()
        {
            SparkCommon.PerformLogin(_login.Username, _login.Password);
            _login.LoginRequired = false;

            const string urlPhone = "https://www.spark.co.nz/portal/site/mytelecom-site/template.BINARYPORTLET/menuitem.c26e41f6aeaa53d794910bf3bc407ea0/resource.process/?javax.portlet.tpst=3b7cbd058d222b6e85cdc707d5107ea0&javax.portlet.rid_3b7cbd058d222b6e85cdc707d5107ea0=ajaxGetUnbilledCallsDetailUsage&javax.portlet.rcl_3b7cbd058d222b6e85cdc707d5107ea0=cacheLevelPage&javax.portlet.begCacheTok=com.vignette.cachetoken&javax.portlet.endCacheTok=com.vignette.cachetoken";
            const string postPhone = "currentPage=0&requestedPage=0&phoneNumber=all";

            _phoneCalls = SparkCommon.PerformSparkWebRequest<PhoneCallParser.UnbilledCallsForm>(urlPhone, postPhone);
            
            /*var webRequestPhone = SparkCommon.CreateSparkWebRequest(urlPhone, postPhone);
            using (var webResponse = (HttpWebResponse)webRequestPhone.GetResponse())
            {
                var stream = webResponse.GetResponseStream();
                _phoneCalls = new PhoneCallParser(ref stream).GetCalls();
            }*/

            var postData = "phoneNumber=33418962"; // TODO: FIX THIS SHIT
            if(_phoneCalls.Count > 0) postData = "phoneNumber=" + _phoneCalls[0].From.Replace(" ", "").Substring(1);

            const string urlData =
                "https://www.spark.co.nz/portal/site/mytelecom-site/template.BINARYPORTLET/menuitem.c26e41f6aeaa53d794910bf3bc407ea0/resource.process/?javax.portlet.tpst=9252c8781852ea6e85cdc707d5107ea0&javax.portlet.rid_9252c8781852ea6e85cdc707d5107ea0=ajaxGetDataUsage&javax.portlet.rcl_9252c8781852ea6e85cdc707d5107ea0=cacheLevelPage&javax.portlet.begCacheTok=com.vignette.cachetoken&javax.portlet.endCacheTok=com.vignette.cachetoken";
            //var webRequestData = SparkCommon.CreateSparkWebRequest(urlData, postData);
            _usageData = SparkCommon.PerformSparkWebRequest<UsageDataParser.SummaryUsageData>(urlData, postData);
            
            /*using (var webResponse = (HttpWebResponse)webRequestData.GetResponse())
            {
                var stream = webResponse.GetResponseStream();
                _usageData = new UsageDataParser(ref stream).GetUsageData();
            }*/

            SparkCommon.PerformLogout();
            _login.LoginRequired = true;
        }

        public IEnumerable<PhoneCall> GetPhoneCalls()
        {
            var phoneCalls = new List<PhoneCall>();
            foreach (var phoneCall in _phoneCalls)
            {

                
                var dur = phoneCall.Duration.Split(':');
                var duration = UInt64.Parse(dur[0]) * 3600 + UInt64.Parse(dur[1]) * 60 + UInt64.Parse(dur[2]);
                DateTime dt;
                DateTime.TryParse(phoneCall.Time + " " + phoneCall.Date, out dt);
                double discount;
                double.TryParse(phoneCall.Discount.Replace("$", ""), out discount);
                double cost;
                double.TryParse(phoneCall.Cost.Replace("$", ""), out cost);
                PhoneCallType type;
                Enum.TryParse(phoneCall.Calltype, true, out type);
                var call = new PhoneCall(dt, duration, type, phoneCall.From, phoneCall.To, cost, discount,
                    uint.Parse(phoneCall.Rawnumbercalled));
                phoneCalls.Add(call);
            }
            return phoneCalls;
        }

        public void GetPhoneTotals(out int calls, out double cost, out double discount, out ulong duration)
        {
            cost = 0;
            discount = 0;
            duration = 0;
            calls = _phoneCalls.Count;
            foreach (var phoneCall in _phoneCalls)
            {
                cost += double.Parse(phoneCall.Cost.Substring(1));
                discount += double.Parse(phoneCall.Discount.Substring(1));
                var dur = phoneCall.Duration.Split(':');
                duration += (ulong)(int.Parse(dur[0])*3600 + int.Parse(dur[1])*60 + int.Parse(dur[2]));
            }
        }

        public OwnerDetail LookupPhoneOwner(PhoneCall call)
        {
            return SparkPhoneOwnerLookup.SparkLookup(call);
        }

        private UsageDataParser.SummaryUsageData _usageData;

        public IEnumerable<DayOfInternetUsage> GetDaysOfUsage()
        {
            return _usageData.DailyUsageDatas.Select(usageDay => new DayOfInternetUsage
                                                                 {
                                                                     Date = usageDay.SummaryFrom, TotalAllowed = usageDay.DataCap, TotalDownload = usageDay.DownloadDataUsed, TotalUpload = usageDay.UploadDataUsed, TotalUsed = usageDay.DataUsed
                                                                 }).ToList();
        }

        public void GetInternetTotals(out double download, out double upload, out double overall, out double totalAllowed)
        {
            download = _usageData.TotalDownloads;
            upload = _usageData.TotalUploads;
            overall = _usageData.TotalUsage;
            totalAllowed = _usageData.MonthlyDataAllowance;
        }

        public int DaysLeftInMonth()
        {
            var days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            return days - _usageData.DailyUsageDatas.Count;
        }

        public int DaysPastInMonth()
        {
            var days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            return days - DaysLeftInMonth();
        }

        public DateTime StartOfMonth()
        {
            return DateTime.Now.AddDays(-1*DaysPastInMonth());
        }
    }
}
