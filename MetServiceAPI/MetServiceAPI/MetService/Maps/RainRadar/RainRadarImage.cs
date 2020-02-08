using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

// ReSharper disable InconsistentNaming

namespace MetServiceAPI.MetService.Maps.RainRadar
{
    public class RainRadarImage
    {
        private string _url;

        /// <summary>
        /// Interprets JSON to create a new array of RainRadarImage's
        /// </summary>
        /// <param name="jsonSource">Source of the JSON data</param>
        /// <returns>A new array of RainRadarImage's</returns>
        public static RainRadarImage[] GetRadarImages(Stream jsonSource)
        {
            try
            {
                var radarImagesSerialiser = new DataContractJsonSerializer(typeof(RainRadarImage[]));
                var images = (RainRadarImage[])radarImagesSerialiser.ReadObject(jsonSource);
                Debug.Assert(typeof(RainRadarImage[]) == images.GetType());
                Debug.Assert(images != null);
                return images;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Interprets JSON to create a new array of RainRadarImage's
        /// </summary>
        /// <param name="json">Source of the JSON data</param>
        /// <returns>A new array of RainRadarImage's</returns>
        public static RainRadarImage[] GetRadarImages(string json)
        {
            var memoryStream = new MemoryStream();
            memoryStream.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
            memoryStream.Position = 0;
            return GetRadarImages(memoryStream);
        }

        public string longDateTime { get; set; }
        public string shortDateTime { get; set; }

        public string url
        {
            get { return _url; }
            set { _url = Common.BaseUrl + value; }
        }

        public string validFrom { get; set; }

        public DateTime ValidFromDateTime
        {
            get { return DateTime.Parse(validFrom); }
        }
        public string validToex { get; set; }
        public DateTime ValidToDateTime
        {
            get { return DateTime.Parse(validToex); }
        }

        private Image _image;
        public Image GetImage()
        {
            if (_image != null) return _image;
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
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
