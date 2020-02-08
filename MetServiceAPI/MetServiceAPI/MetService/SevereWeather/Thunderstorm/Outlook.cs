using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetServiceAPI.MetService.SevereWeather.Thunderstorm
{
    class Outlook
    {
        // http://metservice.com/publicData/thunderstormOutlook

        [DataMember(Name = "issuedTime")]
        public string IssuedTime { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public string validToTime { get; set; }

    }
}
