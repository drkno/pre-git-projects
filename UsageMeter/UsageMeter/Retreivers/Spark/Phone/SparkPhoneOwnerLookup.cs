using System;
using System.Runtime.Serialization;

namespace UsageMeter.Retreivers.Spark.Phone
{
    public static class SparkPhoneOwnerLookup
    {
        public static OwnerDetail SparkLookup(PhoneCall call)
        {
            try
            {
                const string url =
                "https://www.spark.co.nz/portal/site/mytelecom-site/template.BINARYPORTLET/menuitem.c26e41f6aeaa53d794910bf3bc407ea0/resource.process/?javax.portlet.tpst=3b7cbd058d222b6e85cdc707d5107ea0&javax.portlet.rid_3b7cbd058d222b6e85cdc707d5107ea0=ajaxQueryParty&javax.portlet.rcl_3b7cbd058d222b6e85cdc707d5107ea0=cacheLevelPage&javax.portlet.begCacheTok=com.vignette.cachetoken&javax.portlet.endCacheTok=com.vignette.cachetoken";
                var request = SparkCommon.PerformSparkWebRequest<RootObject<PhoneNumberDetails, ActionResult>>(url,
                    "phoneNumber=" + call.RawNumber + "&formattedPhoneNumber=" + call.NumberCalled);
                return new OwnerDetail(uint.Parse(request.ActionResult.PhoneNumber), request.PhoneNumberForm.NumberOwner, request.ActionResult.FormattedPhoneNumber);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [DataContract]
        internal class ActionResult : Retreivers.Spark.ActionResult
        {
            [DataMember(Name = "numberOwner")]
            public string NumberOwner { get; set; }
        }
    }
}
