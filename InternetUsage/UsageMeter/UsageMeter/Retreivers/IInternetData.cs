using System;
using System.Collections.Generic;

namespace UsageMeter.Retreivers
{
    public interface IInternetData
    {
        ILogin GetLogin { get; }
        void GetData();
        IEnumerable<DayOfInternetUsage> GetDaysOfUsage();
        void GetInternetTotals(out double download, out double upload, out double overall, out double totalAllowed);
        int DaysLeftInMonth();
        int DaysPastInMonth();
        DateTime StartOfMonth();
    }

    public class DayOfInternetUsage
    {
        public double TotalUsed { get; set; }
        public double TotalDownload { get; set; }
        public double TotalUpload { get; set; }
        public double TotalAllowed { get; set; }
        public DateTime Date { get; set; }
    }
}
