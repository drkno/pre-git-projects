using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

// ReSharper disable InconsistentNaming

namespace MetServiceAPI.MetService.Maps.RainForecast
{
    [DataContract]
    public class RainForecastImage
    {
        private string _url;

        /// <summary>
        /// Interprets JSON to create a new array of RainForecastImage's
        /// </summary>
        /// <param name="jsonSource">Source of the JSON data</param>
        /// <returns>A new array of RainForecastImage's</returns>
        public static RainForecastImage[] GetRainForecastImages(Stream jsonSource)
        {
            try
            {
                var forecastImagesSerialiser = new DataContractJsonSerializer(typeof(RainForecastImage[]));
                var images = (RainForecastImage[])forecastImagesSerialiser.ReadObject(jsonSource);
                Debug.Assert(typeof(RainForecastImage[]) == images.GetType());
                Debug.Assert(images != null);
                return images;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Interprets JSON to create a new array of RainForecastImage's
        /// </summary>
        /// <param name="json">Source of the JSON data</param>
        /// <returns>A new array of RainForecastImage's</returns>
        public static RainForecastImage[] GetRainForecastImages(string json)
        {
            var memoryStream = new MemoryStream();
            memoryStream.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
            memoryStream.Position = 0;
            return GetRainForecastImages(memoryStream);
        }
        [DataMember(Name = "src")]
        public string Source { get; set; }
        [DataMember(Name = "issuedTime")]
        public string IssuedTime { get; set; }
        [DataMember(Name = "longDateTime")]
        public string LongDateTime { get; set; }
        [DataMember(Name = "shortDateTime")]
        public string ShortDateTime { get; set; }
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
