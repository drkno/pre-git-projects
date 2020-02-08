using System;
using System.Net;

namespace MetServiceAPI.MetService.Maps.SataliteImagery
{
    public enum SataliteImageryTypes
    {
        TasmanSeaInfrared = 0,
        TasmanSeaVisible = 1,
        AustraliaInfraredColour = 2
    }

    class Satalite
    {
        private static string ImageryTypesToCode(SataliteImageryTypes sat)
        {
            switch (sat)
            {
                case SataliteImageryTypes.TasmanSeaInfrared:
                    return "tasmanSeaInfraredSatelliteSeries";
                case SataliteImageryTypes.TasmanSeaVisible:
                    return "nzVisibleSatellite2Series";
                case SataliteImageryTypes.AustraliaInfraredColour:
                    return "australiaInfraredColourPlayer";
                default:
                    goto case SataliteImageryTypes.TasmanSeaVisible;
            }
        }

        private static string GenerateUrl(SataliteImageryTypes sat)
        {
            return Common.BaseUrl + "/publicData/" + ImageryTypesToCode(sat);
        }

        public static SataliteImage[] GetSataliteImages(SataliteImageryTypes sat)
        {
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create(GenerateUrl(sat));
                webRequest.UserAgent = Common.UserAgent;
                webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                webRequest.AllowAutoRedirect = true;
                SataliteImage[] images;
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var stream = webResponse.GetResponseStream();
                    images = SataliteImage.GetSataliteImages(stream);
                }
                return images;
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof (WebException))
                    throw new Exception("An error occured while retreiving the requested satalite imagery.", e);
                var webE = (WebException) e;
                if (((HttpWebResponse) webE.Response).StatusCode == HttpStatusCode.NotImplemented)
                {
                    throw new Exception("The requested satalite imagery does not exist.", e);
                }
                throw new Exception("An error occured while retreiving the requested satalite imagery.", e);
            }
        }
    }
}
