using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace UsageMeter.Retreivers.Spark.Internet
{
    public class UsageDataParser
    {
        private readonly UsageDataD _usageDataD;
        public UsageDataParser(string location)
        {
            var stream = new FileStream(location, FileMode.Open);
            var ser = new DataContractJsonSerializer(typeof(UsageDataD));
            _usageDataD = (UsageDataD)ser.ReadObject((stream));
            stream.Close();
        }

        public UsageDataParser(string json,bool d)
        {
            var stream = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(json));
            var ser = new DataContractJsonSerializer(typeof(UsageDataD));
            _usageDataD = (UsageDataD)ser.ReadObject((stream));
            stream.Close();
        }

        public UsageDataParser(ref Stream dataStream)
        {
            var ser = new DataContractJsonSerializer(typeof(UsageDataD));
            _usageDataD = (UsageDataD)ser.ReadObject((dataStream));
        }

        public SummaryUsageData GetUsageData()
        {
            var summaryUsage = new SummaryUsageData
                                   {
                                       MonthlyDataAllowance = _usageDataD.actionResult.monthlyDataAllowance,
                                       SummaryFrom = UnixTimeStampToDateTime(_usageDataD.actionResult.summaryFrom),
                                       SummaryTo = UnixTimeStampToDateTime(_usageDataD.actionResult.summaryTo),
                                       TotalUploads = _usageDataD.actionResult.totalUploads,
                                       TotalDownloads = _usageDataD.actionResult.totalDownloads,
                                       TotalUsage = _usageDataD.actionResult.totalUsage,
                                       DailyUsageDatas = new List<DailyUsageData>()
                                   };

            foreach (var dailyUsageData in _usageDataD.actionResult.summaryList.Select(usg => new DailyUsageData
                                                                                                  {
                                                                                                      DataCap = usg.dataCap,
                                                                                                      DataUsed = usg.dataUsed,
                                                                                                      DownloadDataUsed = usg.downloadDataUsed,
                                                                                                      SummaryFrom = UnixTimeStampToDateTime(usg.summaryFrom),
                                                                                                      SummaryTo = UnixTimeStampToDateTime(usg.summaryTo),
                                                                                                      UploadDataUsed = usg.uploadDataUsed
                                                                                                  }))
            {
                summaryUsage.DailyUsageDatas.Add(dailyUsageData);
            }

            return summaryUsage;
        }

        public struct SummaryUsageData
        {
            public Int64 TotalDownloads, TotalUploads, TotalUsage, MonthlyDataAllowance;
            public DateTime SummaryFrom, SummaryTo;
            public List<DailyUsageData> DailyUsageDatas;
        }

        public struct DailyUsageData
        {
            public Int64 DataCap, DataUsed, UploadDataUsed, DownloadDataUsed;
            public DateTime SummaryFrom, SummaryTo;
        }

        public static DateTime UnixTimeStampToDateTime(Int64 unixTimeStamp)
        {
            unixTimeStamp /= 1000; unixTimeStamp -= 1262304000;
            var dtDateTime = new DateTime(2010, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        // REQUIRED MEMBERS
        // ReSharper disable InconsistentNaming

        [DataContract]
        internal class UsageDataD
        {
            [DataMember]
            public PhoneNumberForm phoneNumberForm;
            [DataMember]
            public ActionResult actionResult;
        }

        [DataContract]
        internal class PhoneNumberForm
        {
            [DataMember]
            public string phoneNumber, formattedPhoneNumber;
        }

        [DataContract]
        internal class ActionResult
        {
            [DataMember]
            public Messages messages;
            [DataMember]
            public SummaryList[] summaryList;
            [DataMember]
            public object[] fieldNamesInError;
            [DataMember]
            public bool hidden, successful;
            [DataMember]
            public string planName;
            [DataMember]
            public Int64 totalDownloads, totalUploads, totalUsage, summaryFrom, summaryTo, monthlyDataAllowance;
            [DataMember]
            public string changePlanUrl;
        }

        [DataContract]
        internal class Messages
        {
            [DataMember]
            public object[] messages, successMessages, errorMessages, infoMessages;
        }

        [DataContract]
        internal class SummaryList
        {
            [DataMember]
            public Int64 serviceNumber, summaryFrom, summaryTo, dataCap, dataUsed, uploadDataUsed, downloadDataUsed;
        }
        // ReSharper restore InconsistentNaming
    }
}
