using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace UsageMeter.Retreivers.Spark
{
    public class SparkCommon
    {
        public static CookieContainer SparkCookies = new CookieContainer();

        public static void PerformLogin(string username, string password)
        {
            const string url = "https://www.spark.co.nz/portal/site/digital-site/template.PAGE/action.process/menuitem.354c3e0302b1aa1994910bf3bc407ea0/?javax.portlet.action=true&javax.portlet.tpst=b85a693813b5760362a127b4bc407ea0&javax.portlet.begCacheTok=com.vignette.cachetoken&javax.portlet.endCacheTok=com.vignette.cachetoken";
            var postData = "loginSrc=ext&username=" + HttpUtility.UrlEncode(username) + "&password=" + HttpUtility.UrlEncode(password);
            var webRequest = CreateSparkWebRequest(url, postData);
            using (webRequest.GetResponse())
            {
                SparkCookies = webRequest.CookieContainer;
            }
        }

        public static void PerformLogout()
        {
            const string url = "https://www.spark.co.nz/portal/site/mytelecom-site/template.PAGE/action.process/menuitem.c26e41f6aeaa53d794910bf3bc407ea0/?javax.portlet.action=true&javax.portlet.tpst=01921f5d7965760362a127b4bc407ea0&javax.portlet.begCacheTok=com.vignette.cachetoken&javax.portlet.endCacheTok=com.vignette.cachetoken";
            var webRequest = CreateSparkWebRequest(url);
            using (webRequest.GetResponse()) { }
        }

        private const string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 UsageDataRetreiver/1.0 (like Firefox/13.1)";
        public static HttpWebRequest CreateSparkWebRequest(string url, string postData = "")
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.UserAgent = UserAgent;
            webRequest.AllowAutoRedirect = true;
            webRequest.CookieContainer = SparkCookies;
            webRequest.Referer = "https://www.spark.co.nz/home/";
            webRequest.AutomaticDecompression = DecompressionMethods.Deflate |
                                                DecompressionMethods.GZip |
                                                DecompressionMethods.None;
            if (!string.IsNullOrWhiteSpace(postData))
            {
                SetHttpPostData(ref webRequest, postData);
            }
            return webRequest;
        }

        private static void SetHttpPostData(ref HttpWebRequest webRequest, string postData)
        {
            webRequest.Method = "POST";
            var st = webRequest.GetRequestStream();
            var byteArray = Encoding.UTF8.GetBytes(postData);
            st.Write(byteArray, 0, byteArray.Length);
            st.Close();
            webRequest.ContentType = "application/x-www-form-urlencoded";
        }

        private static T GetObjectForStream<T>(ref Stream dataStream)
        {
            try
            {
                var ser = new DataContractJsonSerializer(typeof(T));
                return (T)ser.ReadObject((dataStream));
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static T PerformSparkWebRequest<T>(string url, string post = "")
        {
            var obj = default(T);
            try
            {
                var webRequest = CreateSparkWebRequest(url, post);
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    SparkCookies = webRequest.CookieContainer;
                    var stream = webResponse.GetResponseStream();
                    if (stream != null)
                    {
                        obj = GetObjectForStream<T>(ref stream);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error occured during WebRequest: " + e.Message);
                return default(T);
            }
            return obj;
        }
    }

    // ReSharper disable once InconsistentNaming
    [DataContract]
    public class RootObject<T, A>
    {
        [DataMember(Name = "phoneNumberForm")]
        public A PhoneNumberForm { get; set; }
        [DataMember(Name = "unbilledCallsForm")]
        protected A UnbilledCallsForm { get { return PhoneNumberForm; } set { PhoneNumberForm = value; } }
        [DataMember(Name = "actionResult")]
        public T ActionResult { get; set; }
    }

    [DataContract]
    public class PhoneNumberDetails
    {
        [DataMember(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }
        [DataMember(Name = "formattedPhoneNumber")]
        public string FormattedPhoneNumber { get; set; }
    }

    [DataContract]
    public class ActionResult
    {
        [DataMember(Name = "messages")]
        public InformationMessages Messages { get; set; }
        [DataMember(Name = "fieldNamesInError")]
        public object[] FieldNamesInError { get; set; }
        [DataMember(Name = "hidden")]
        public bool Hidden { get; set; }
        [DataMember(Name = "serviceNumber")]
        public string ServiceNumber { get; set; }
        [DataMember(Name = "successful")]
        public bool Successful { get; set; }
    }

    [DataContract]
    public class InformationMessages
    {
        [DataMember(Name = "messages")]
        public object[] Messages { get; set; }
        [DataMember(Name = "successMessages")]
        public object[] SuccessMessages { get; set; }
        [DataMember(Name = "errorMessages")]
        public object[] ErrorMessages { get; set; }
        [DataMember(Name = "infoMessages")]
        public object[] InfoMessages { get; set; }
    }
}
