using System;
using System.IO;
using System.Net;
using System.Text;

namespace MetServiceAPI.MetService
{
    class Common
    {
        public static string UserAgent = "WeatherGetter 1/0 (like Chrome, like Firefox, like Webkit, like KHTML, like Gecko)";
        public static string BaseUrl = "http://metservice.com";

        public static MemoryStream RetreiveData(string url)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.UserAgent = UserAgent;
            webRequest.AllowAutoRedirect = true;
            webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            MemoryStream stream;
            using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                var s = webResponse.GetResponseStream();
                if (s == null)
                {
                    throw new NullReferenceException("No data was returned from metservice.");
                }
                var reader = new StreamReader(s);
                var temp = reader.ReadToEnd();
                reader.Close();
                stream = new MemoryStream();
                stream.Write(Encoding.ASCII.GetBytes(temp), 0, temp.Length);
                stream.Position = 0;
            }
            return stream;
        }
    }
}
