using System;
using System.Net;

namespace MetServiceAPI.MetService.Maps.SurfacePressure
{
    public enum SurfacePressureCharts
    {
        TasmanSeaCombined = 0,
        SouthWestPacificCombined = 1,
        SouthWestPacificLowBandwidth = 2
    }

    class SurfacePressure
    {
        private static string SurfacePressureChartToCode(SurfacePressureCharts chart)
        {
            switch (chart)
            {
                case SurfacePressureCharts.TasmanSeaCombined:
                    return "tasmanSeaCombinedCharts";
                case SurfacePressureCharts.SouthWestPacificCombined:
                    return "swPacificChartsCombined";
                case SurfacePressureCharts.SouthWestPacificLowBandwidth:
                    return "swPacificCharts_LowBandwidth";
                default:
                    goto case SurfacePressureCharts.SouthWestPacificLowBandwidth;
            }
        }

        private static string GenerateUrl(SurfacePressureCharts chart)
        {
            return Common.BaseUrl + "/publicData/" + SurfacePressureChartToCode(chart);
        }

        public static SurfacePressureImage[] GetSurfacePressureImages(SurfacePressureCharts chart)
        {
            try
            {
                var webRequest = (HttpWebRequest) WebRequest.Create(GenerateUrl(chart));
                webRequest.UserAgent = Common.UserAgent;
                webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                webRequest.AllowAutoRedirect = true;
                SurfacePressureImage[] images;
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var stream = webResponse.GetResponseStream();
                    images = SurfacePressureImage.GetSurfacePressureImages(stream);
                }
                return images;
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof (WebException))
                    throw new Exception("An error occured while retreiving the requested surface pressure images.", e);
                var webE = (WebException) e;
                if (((HttpWebResponse) webE.Response).StatusCode == HttpStatusCode.NotImplemented)
                {
                    throw new Exception("The requested surface pressure format does not exist.", e);
                }
                throw new Exception("An error occured while retreiving the requested surface pressure images.",e);
            }
        }
    }
}
