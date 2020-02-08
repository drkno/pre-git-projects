using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace UsageMeter.Retreivers.Spark.Phone
{
    public class SparkPhoneCallParser
    {
        private const string UrlPhone = "https://www.spark.co.nz/portal/site/mytelecom-site/template.BINARYPORTLET/menuitem.c26e41f6aeaa53d794910bf3bc407ea0/resource.process/?javax.portlet.tpst=3b7cbd058d222b6e85cdc707d5107ea0&javax.portlet.rid_3b7cbd058d222b6e85cdc707d5107ea0=ajaxGetUnbilledCallsDetailUsage&javax.portlet.rcl_3b7cbd058d222b6e85cdc707d5107ea0=cacheLevelPage&javax.portlet.begCacheTok=com.vignette.cachetoken&javax.portlet.endCacheTok=com.vignette.cachetoken";
        private const string PostPhone = "currentPage=0&requestedPage=0&phoneNumber=all";
        private readonly UnbilledCalls _calls;
        public SparkPhoneCallParser()
        {
            _calls = SparkCommon.PerformSparkWebRequest<UnbilledCalls>(UrlPhone, PostPhone);
        }

        public List<PhoneCall> GetPhoneCalls()
        {
            foreach (var call in _calls.actionResult.usageDetails)
            {
                var pcall = new PhoneCall(call.date, call.duration, call.callType, call.fromNumber, call.numberCalled, call.cost, call.discount, call.rawNumberCalled);
            }
            /*var phoneCalls = _unbilledCalls.actionResult.usageDetails.Select(usagedetail => new PhoneCall
            {
                Date = usagedetail.date,
                Cost = usagedetail.cost,
                Discount = usagedetail.discount,
                Duration = usagedetail.duration,
                Rawnumbercalled = usagedetail.rawNumberCalled,
                From = usagedetail.fromNumber,
                To = usagedetail.numberCalled,
                Time = usagedetail.time,
                Calltype = usagedetail.callType
            }).ToList();

            return phoneCalls;*/
        }

        [DataContract]
        internal class UnbilledCalls
        {
            [DataMember]
            public UnbilledCallsForm unbilledCallsForm;

            [DataMember]
            public ActionResult actionResult;
        }

        [DataContract]
        internal class UnbilledCallsForm
        {
            [DataMember]
            public string phoneNumber;
            [DataMember]
            public string formattedPhoneNumber;
            [DataMember]
            public int requestedPage;
        }

        [DataContract]
        internal class ActionResult
        {
            [DataMember]
            public string localCalls, nationalCalls, internationalCalls, mobileCalls, totalCalls, serviceNumber;
            [DataMember]
            public int currentPage;
            [DataMember]
            public bool hidden, last, successful;
            [DataMember]
            public Messages messages;
            [DataMember]
            public object[] fieldNamesInError;
            [DataMember]
            public UsageDetails[] usageDetails;
        }

        [DataContract]
        internal class Messages
        {
            [DataMember]
            public object[] messages, successMessages, errorMessages, infoMessages;
        }

        [DataContract]
        internal class UsageDetails
        {
            [DataMember]
            public string date, time, duration, callType, fromNumber, numberCalled, cost, discount, rawNumberCalled;
        }
    }

    public class PhoneCallParser
    {
        private readonly SparkPhoneCallParser.UnbilledCalls _unbilledCalls;
        public PhoneCallParser(ref Stream dataStream)
        {
            var ser = new DataContractJsonSerializer(typeof(SparkPhoneCallParser.UnbilledCalls));
            _unbilledCalls = (SparkPhoneCallParser.UnbilledCalls)ser.ReadObject((dataStream));
        }

        public List<PhoneCall> GetCalls()
        {
            var phoneCalls = _unbilledCalls.actionResult.usageDetails.Select(usagedetail => new PhoneCall
            {
                Date = usagedetail.date,
                Cost = usagedetail.cost,
                Discount = usagedetail.discount,
                Duration = usagedetail.duration,
                Rawnumbercalled = usagedetail.rawNumberCalled,
                From = usagedetail.fromNumber,
                To = usagedetail.numberCalled,
                Time = usagedetail.time,
                Calltype = usagedetail.callType
            }).ToList();

            return phoneCalls;
        }

        [DataContract]
        internal class UnbilledCallsForm : PhoneNumberDetails
        {
            [DataMember(Name = "requestedPage")]
            public int RequestedPage;
        }

        [DataContract]
        internal class ActionResult : Retreivers.Spark.ActionResult
        {
            [DataMember(Name = "localCalls")]
            public string LocalCalls;
            [DataMember(Name = "nationalCalls")]
            public string NationalCalls;
            [DataMember(Name = "internationalCalls")]
            public string InternationalCalls;
            [DataMember(Name = "mobileCalls")]
            public string MobileCalls;
            [DataMember(Name = "totalCalls")]
            public string TotalCalls;
            [DataMember(Name = "currentPage")]
            public int CurrentPage;
            [DataMember(Name = "last")]
            public bool Last;
            [DataMember(Name = "usageDetails")]
            public UsageDetail[] UsageDetails;
        }

        [DataContract]
        internal class UsageDetail : PhoneCall
        {
            [DataMember(Name = "date")]
            protected string DateIn
            {
                set
                {
                    var date = DateTime.Parse(value);
                    if (DateTime == default(DateTime))
                    {
                        DateTime = date;
                    }
                    else
                    {
                        DateTime = DateTime.AddYears(date.Year - DateTime.Year);
                        DateTime = DateTime.AddMonths(date.Month - DateTime.Month);
                        DateTime = DateTime.AddDays(date.Day - DateTime.Day);
                    }
                }
            }

            [DataMember(Name = "time")]
            protected string TimeIn
            {
                set
                {
                    var time = DateTime.Parse(value);
                    if (DateTime == default(DateTime))
                    {
                        DateTime = time;
                    }
                    else
                    {
                        DateTime = DateTime.AddHours(time.Hour - DateTime.Hour);
                        DateTime = DateTime.AddMinutes(time.Minute - DateTime.Minute);
                        DateTime = DateTime.AddSeconds(time.Second - DateTime.Second);
                        DateTime = DateTime.AddMilliseconds(time.Millisecond - DateTime.Millisecond);
                    }
                }
            }

            [DataMember(Name = "duration")]
            protected string DurationIn
            {
                set
                {
                    var s = value.Split(':');
                    ulong val = 0;
                    val += ulong.Parse(s[2]);
                    val += ulong.Parse(s[1])*60;
                    val += ulong.Parse(s[0])*3600;
                    Duration = val;
                }
            }

            [DataMember(Name = "callType")] 
            public string CallType ;
            [DataMember(Name = "fromNumber")] 
            public string FromNumber ;
            [DataMember(Name = "numberCalled")] 
            public string NumberCalled ;
            [DataMember(Name = "cost")] 
            public string Cost ;
            [DataMember(Name = "discount")] 
            public string Discount ;
            [DataMember(Name = "rawNumberCalled")] 
            public string RawNumberCalled;
        }
    }
}
