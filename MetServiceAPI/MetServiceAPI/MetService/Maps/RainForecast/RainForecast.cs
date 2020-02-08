using System;
using System.Net;

namespace MetServiceAPI.MetService.Maps.RainForecast
{
    public enum RainForecastDays
    {
        ThreeDays = 0,
        SevenDays = 1
    }

    class RainForecast
    {
        private static string DaysToCode(RainForecastDays day)
        {
            switch (day)
            {
                case RainForecastDays.ThreeDays:
                    return "3Day";
                case RainForecastDays.SevenDays:
                    return "37Day";
                default:
                    goto case RainForecastDays.ThreeDays;
            }
        }

        private static string GenerateUrl(RainForecastDays day)
        {
            return Common.BaseUrl + "/publicData/rainForecast" + DaysToCode(day);
        }

        public static RainForecastImage[] GetRainForecastImages(RainForecastDays day)
        {
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create(GenerateUrl(day));
                webRequest.UserAgent = Common.UserAgent;
                webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                webRequest.AllowAutoRedirect = true;
                RainForecastImage[] images;
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var stream = webResponse.GetResponseStream();
                    images = RainForecastImage.GetRainForecastImages(stream);
                }
                return images;
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof (WebException))
                    throw new Exception("An error occured while retreiving the requested rain forecast.", e);
                var webE = (WebException) e;
                if (((HttpWebResponse) webE.Response).StatusCode == HttpStatusCode.NotImplemented)
                {
                    throw new Exception("The requested rain forecast format does not exist.", e);
                }
                throw new Exception("An error occured while retreiving the requested rain forecast.",e);
            }
        }
    }
}
