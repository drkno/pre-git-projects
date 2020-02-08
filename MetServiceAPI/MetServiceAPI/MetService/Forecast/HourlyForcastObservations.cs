using System;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace MetServiceAPI.MetService.Forecast
{
    [DataContract]
    class HourlyForecastObservations
    {
        public static HourlyForecastObservations GetHourlyForecastObservations(string location)
        {
            try
            {
                location = location.Trim().ToLower().Replace(' ','_');
                var webRequest = (HttpWebRequest)WebRequest.Create(Common.BaseUrl + "/publicData/hourlyObsAndForecast_" + location);
                webRequest.UserAgent = Common.UserAgent;
                webRequest.AllowAutoRedirect = true;
                webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip | DecompressionMethods.None;
                HourlyForecastObservations forecast;
                using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    var s = webResponse.GetResponseStream();
                    if (s == null)
                    {
                        throw new NullReferenceException("No data was returned from metservice.");
                    }
                    var ser = new DataContractJsonSerializer(typeof(HourlyForecastObservations));
                    forecast = (HourlyForecastObservations) ser.ReadObject(s);
                }
                return forecast;
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof (WebException))
                    throw new Exception("An error occured while retreiving the requested hourly forecast.", e);
                var webE = (WebException) e;
                if (((HttpWebResponse) webE.Response).StatusCode == HttpStatusCode.NotImplemented)
                {
                    throw new Exception("The requested hourly forecast does not exist.", e);
                }
                throw new Exception("An error occured while retreiving the requested hourly forecast.", e);
            }
        }

        [DataMember(Name = "actualData")]
        public HourlyObsForecastData[] ActualData { get; set; }
        [DataMember(Name = "dataPointCount")]
        public int DataPointCount { get; set; }
        [DataMember(Name = "forecastAws")]
        public string ForecastAws { get; set; }
        [DataMember(Name = "forecastData")]
        public HourlyObsForecastData[] ForecastData { get; set; }
        [DataMember(Name = "latestIssuedDate")]
        public string LatestIssuedDate { get; set; }
        [DataMember(Name = "localObsAws")]
        public string LocalObsAws { get; set; }
        [DataMember(Name = "location")]
        public string Location { get; set; }
        [DataMember(Name = "locationName")]
        public string LocationName { get; set; }
        [DataMember(Name = "oneMinuteObsAws")]
        public string OneMinuteObsAws { get; set; }
        [DataMember(Name = "rainfallTotalForecast")]
        public float RainfallTotalForecast { get; set; }
        [DataMember(Name = "rainfallTotalObserved")]
        public float RainfallTotalObserved { get; set; }
        [DataMember(Name = "today")]
        public string Today { get; set; }

        [DataContract]
        public class HourlyObsForecastData
        {
            [DataMember(Name = "date")]
            public string Date { get; set; }
            [DataMember(Name = "offset")]
            public int Offset { get; set; }
            [DataMember(Name = "rainFall")]
            public string Rainfall { get; set; }
            [DataMember(Name = "temperature")]
            public string Temperature { get; set; }
            [DataMember(Name = "timeFrom")]
            public string TimeFrom { get; set; }
            [DataMember(Name = "windDir")]
            public string WindDirection { get; set; }
            [DataMember(Name = "windSpeed")]
            public string WindSpeed { get; set; }
        }

    }
}
