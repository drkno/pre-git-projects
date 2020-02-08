using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

// ReSharper disable InconsistentNaming

namespace MetServiceAPI.MetService.Maps.SataliteImagery
{
    [DataContract]
    public class SataliteImage
    {
        private string _url;

        /// <summary>
        /// Interprets JSON to create a new array of SataliteImage's
        /// </summary>
        /// <param name="jsonSource">Source of the JSON data</param>
        /// <returns>A new array of SataliteImage's</returns>
        public static SataliteImage[] GetSataliteImages(Stream jsonSource)
        {
            try
            {
                var forecastImagesSerialiser = new DataContractJsonSerializer(typeof(SataliteImage[]));
                var images = (SataliteImage[])forecastImagesSerialiser.ReadObject(jsonSource);
                Debug.Assert(typeof(SataliteImage[]) == images.GetType());
                Debug.Assert(images != null);
                return images;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Interprets JSON to create a new array of SataliteImage's
        /// </summary>
        /// <param name="json">Source of the JSON data</param>
        /// <returns>A new array of SataliteImage's</returns>
        public static SataliteImage[] GetRainForecastImages(string json)
        {
            var memoryStream = new MemoryStream();
            memoryStream.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
            memoryStream.Position = 0;
            return GetSataliteImages(memoryStream);
        }
        [DataMember(Name = "shortDateTime")]
        protected string ShortDateTime { get; set; }
        [DataMember(Name = "longDateTime")]
        protected string LongDateTime
        {
            set { IssueTime = value; }
            get { return IssueTime; }
        }

        [DataMember(Name = "issuedTime")]
        protected string IssueTime {
            get { return IssuedTime.ToString(CultureInfo.InvariantCulture); }
            set { IssuedTime = DateTime.Parse(value); }
        }
        public DateTime IssuedTime { get; set; }

        [DataMember(Name = "validFromTime")]
        public string ValidFromTime { get; set; }
        [DataMember(Name = "url")]
        public string Url
        {
            get { return _url; }
            set { _url = Common.BaseUrl + value; }
        }

        private Image _image;
        public Image GetImage()
        {
            if (_image != null) return _image;
            var webRequest = (HttpWebRequest)WebRequest.Create(Url);
            webRequest.UserAgent = Common.UserAgent;
            webRequest.AllowAutoRedirect = true;
            webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None;
            using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                var s = webResponse.GetResponseStream();
                if (s == null)
                {
                    throw new NullReferenceException("No data was returned from metservice.");
                }
                _image = Image.FromStream(s);
            }
            return _image;
        }
    }
}
