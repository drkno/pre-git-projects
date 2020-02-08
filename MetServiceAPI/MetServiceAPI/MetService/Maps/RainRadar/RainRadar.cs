using System;
using System.Net;

namespace MetServiceAPI.MetService.Maps.RainRadar
{
    public enum RainRadarLocations
    {
        AllNewZealand = 0,
        BayOfPlenty = 1,
        Auckland = 2,
        HawkesBay = 3,
        NewPlymouth = 4,
        Wellington = 5,
        Canterbury = 6,
        Westland = 7,
        Southland = 8
    }

    public enum RainRadarTimes
    {
        TwoHoursEvery7Mins = 0,
        EightHoursHourly = 1
    }

    public enum RainRadarDistance
    {
        Kilometers120 = 0,
        Kilometers300 = 1
    }
    class RainRadar
    {
        private static string LocationToCode(RainRadarLocations location)
        {
            switch (location)
            {
                case RainRadarLocations.AllNewZealand:
                    return "rainRadarNZ";
                case RainRadarLocations.BayOfPlenty:
                    return "rainRadarBOP";
                case RainRadarLocations.Auckland:
                    return "rainRadarAuckland";
                case RainRadarLocations.HawkesBay:
                    return "rainRadarMahia";
                case RainRadarLocations.NewPlymouth:
                    return "rainRadarNew-plymouth";
                case RainRadarLocations.Wellington:
                    return "rainRadarWellington";
                case RainRadarLocations.Canterbury:
                    return "rainRadarChristchurch";
                case RainRadarLocations.Westland:
                    return "rainRadarWestland";
                case RainRadarLocations.Southland:
                    return "rainRadarInvercargill";
                default:
                    goto case RainRadarLocations.AllNewZealand;
            }
        }

        private static string TimeToCode(RainRadarTimes time)
        {
            switch (time)
            {
                case RainRadarTimes.TwoHoursEvery7Mins:
                    return "2h_7min";
                case RainRadarTimes.EightHoursHourly:
                    return "8h_hourly";
                default: goto case RainRadarTimes.TwoHoursEvery7Mins;
            }
        }

        private static string DistanceToCode(RainRadarDistance distance)
        {
            switch (distance)
            {
                case RainRadarDistance.Kilometers120:
                    return "120K";
                case RainRadarDistance.Kilometers300:
                    return "300K";
                default: goto case RainRadarDistance.Kilometers120;
            }
        }

        private static string GenerateUrl(RainRadarLocations location, RainRadarTimes times, RainRadarDistance distance)
        {
            return Common.BaseUrl + "/publicData/" + LocationToCode(location) + "_" + TimeToCode(times) + "_" + DistanceToCode(distance);
        }

        public static RainRadarImage[] GetRadarImages(RainRadarLocations location, RainRadarTimes time, RainRadarDistance distance)
        {
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create(GenerateUrl(location, time, distance));
                webRequest.UserAgent = Common.UserAgent;
                webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                webRequest.AllowAutoRedirect = true;
                RainRadarImage[] images;
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var stream = webResponse.GetResponseStream();
                    images = RainRadarImage.GetRadarImages(stream);
                }
                return images;
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof (WebException))
                    throw new Exception("An error occured while retreiving the requested rain radar.", e);
                var webE = (WebException) e;
                if (((HttpWebResponse) webE.Response).StatusCode == HttpStatusCode.NotImplemented)
                {
                    throw new Exception("The requested rain radar format does not exist.", e);
                }
                throw new Exception("An error occured while retreiving the requested rain radar.",e);
            }
        }
    }
}
