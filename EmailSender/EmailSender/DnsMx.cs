using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EmailSender
{
    public class DnsMx
    {
        [DllImport("dnsapi", EntryPoint = "DnsQuery_W", CharSet = CharSet.Unicode, SetLastError = true,
            ExactSpelling = true)]
        private static extern int DnsQuery([MarshalAs(UnmanagedType.VBByRefStr)] ref string pszName, QueryTypes wType,
            QueryOptions options, int aipServers, ref IntPtr ppQueryResults,
            int pReserved);

        [DllImport("dnsapi", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void DnsRecordListFree(IntPtr pRecordList, int freeType);

        public static string[] GetMxRecords(string domain)
        {
            var ptr1 = IntPtr.Zero;
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                throw new NotSupportedException();
            }
            var list1 = new ArrayList();
            try
            {
                var num1 = DnsQuery(ref domain, QueryTypes.DnsTypeMx, QueryOptions.DnsQueryBypassCache, 0, ref ptr1,
                    0);
                if (num1 != 0)
                {
                    if (num1 == 9003)
                    {
                        list1.Add("DNS record does not exist");
                    }
                    else
                    {
                        throw new Win32Exception(num1);
                    }
                }
                IntPtr ptr2;
                MxRecord recMx;
                for (ptr2 = ptr1; !ptr2.Equals(IntPtr.Zero); ptr2 = recMx.pNext)
                {
                    recMx = (MxRecord) Marshal.PtrToStructure(ptr2, typeof (MxRecord));
                    if (recMx.wType != 15) continue;
                    string text1 = Marshal.PtrToStringAuto(recMx.pNameExchange);
                    Debug.Assert(text1 != null, "text1 != null");
                    list1.Add(text1);
                }
            }
            finally
            {
                DnsRecordListFree(ptr1, 0);
            }
            return (string[]) list1.ToArray(typeof (string));
        }

        #region Nested type: MxRecord

        [StructLayout(LayoutKind.Sequential)]
        private struct MxRecord
        {
            public readonly IntPtr pNext;
            private readonly string pName;
            public readonly short wType;
            private readonly short wDataLength;
            private readonly int flags;
            private readonly int dwTtl;
            private readonly int dwReserved;
            public readonly IntPtr pNameExchange;
            private readonly short wPreference;
            private readonly short Pad;
        }

        #endregion

        #region Nested type: QueryOptions

        private enum QueryOptions
        {
            DnsQueryBypassCache = 8
        }

        #endregion

        #region Nested type: QueryTypes

        private enum QueryTypes
        {
            DnsTypeMx = 15
        }

        #endregion
    }
}