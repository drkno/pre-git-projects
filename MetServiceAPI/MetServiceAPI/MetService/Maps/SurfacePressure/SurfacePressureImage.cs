using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MetServiceAPI.MetService.Maps.SurfacePressure
{
    [DataContract]
    public class SurfacePressureImage
    {
        private string _url;

        /// <summary>
        /// Interprets JSON to create a new array of SurfacePressureImage's
        /// </summary>
        /// <param name="jsonSource">Source of the JSON data</param>
        /// <returns>A new array of SurfacePressureImage's</returns>
        public static SurfacePressureImage[] GetSurfacePressureImages(Stream jsonSource)
        {
            try
            {
                var forecastImagesSerialiser = new DataContractJsonSerializer(typeof(SurfacePressureImage[]));
                var images = (SurfacePressureImage[])forecastImagesSerialiser.ReadObject(jsonSource);
                Debug.Assert(typeof(SurfacePressureImage[]) == images.GetType());
                Debug.Assert(images != null);
                return images;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Interprets JSON to create a new array of SurfacePressureImage's
        /// </summary>
        /// <param name="json">Source of the JSON data</param>
        /// <returns>A new array of SurfacePressureImage's</returns>
        public static SurfacePressureImage[] GetSurfacePressureImages(string json)
        {
            var memoryStream = new MemoryStream();
            memoryStream.Write(Encoding.ASCII.GetBytes(json), 0, json.Length);
            memoryStream.Position = 0;
            return GetSurfacePressureImages(memoryStream);
        }

        [DataContract]
        protected class JsonSurfacePressure
        {
            [DataMember(Name = "imageData")]
            public SurfacePressureImage[] ImageData { get; set; }
            [DataMember(Name = "selectedImageIndex")]
            public int SelectedImageIndex { get; set; }
        }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        public DateTime IssuedTime { get; protected set; }
        public DateTime ValidFromTime { get; protected set; }

        [DataMember(Name = "issuedTime")]
        protected string IssueTime {
            get { return IssuedTime.ToString(CultureInfo.InvariantCulture); }
            set { IssuedTime = DateTime.Parse(value); }
        }
        [DataMember(Name = "validFromTime")]
        protected string ValidTime
        {
            get { return ValidFromTime.ToString(CultureInfo.InvariantCulture); }
            set { ValidFromTime = DateTime.Parse(value); }
        }

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
