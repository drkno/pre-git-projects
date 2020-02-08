using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UsageMeter.Retreivers
{
    public interface IInternetAndPhoneData : IInternetData
    {
        IEnumerable<PhoneCall> GetPhoneCalls();
        void GetPhoneTotals(out int calls, out double cost, out double discount, out UInt64 duration);
        OwnerDetail LookupPhoneOwner(PhoneCall call);
    }

    public enum PhoneCallType
    {
        Local,
        National,
        International,
        Mobile,
        Other
    }

    [DataContract]
    public class PhoneCall
    {
        [DataMember(Name = "dateTime")]
        public DateTime DateTime { get; protected set; }
        [DataMember(Name = "duration")]
        public UInt64 Duration { get; protected set; }
        [DataMember(Name = "callType")]
        public PhoneCallType CallType { get; protected set; }
        [DataMember(Name = "fromNumber")]
        public string FromNumber { get; protected set; }
        [DataMember(Name = "numberCalled")]
        public string NumberCalled { get; protected set; }
        [DataMember(Name = "cost")]
        public double Cost { get; protected set; }
        [DataMember(Name = "discount")]
        public double Discount { get; protected set; }
        public uint RawNumber { get; protected set; }

        public PhoneCall(DateTime dateTime, UInt64 duration, PhoneCallType phoneCallType,
            string fromNumber, string numberCalled, double cost, double discount, uint rawNumber)
        {
            DateTime = dateTime;
            Duration = duration;
            CallType = phoneCallType;
            FromNumber = fromNumber;
            NumberCalled = numberCalled;
            Cost = cost;
            Discount = discount;
            RawNumber = rawNumber;
        }

        protected PhoneCall() { }
    }

    [DataContract]
    public class OwnerDetail
    {
        [DataMember(Name = "rawNumber")]
        public uint RawNumber { get; protected set; }
        [DataMember(Name = "resisteredOwner")]
        public string ResisteredOwner { get; protected set; }
        [DataMember(Name = "formattedNumber")]
        public string FormattedNumber { get; protected set; }

        public OwnerDetail(uint rawNumber, string regOwner, string formattedNumber)
        {
            RawNumber = rawNumber;
            ResisteredOwner = regOwner;
            FormattedNumber = formattedNumber;
        }

        protected OwnerDetail() { }
    }
}
