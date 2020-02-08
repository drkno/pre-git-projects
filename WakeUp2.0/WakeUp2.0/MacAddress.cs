using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using WakeUpServer.Exceptions;

namespace WakeUpServer
{
    // ReSharper disable UnusedMember.Global
    /// <summary>
    /// Provides helper methods and functions around a MacAddress type.
    /// </summary>
    public class MacAddress
    {
        #region Properties
        /// <summary>
        /// The bytes that make up this MacAddress.
        /// </summary>
        public byte[] MacAddressBytes { get; }

        /// <summary>
        /// This MacAddress represented as a string.
        /// </summary>
        public string MacAddressString => BitConverter.ToString(MacAddressBytes);

        /// <summary>
        /// The length of a MacAddress (in bytes).
        /// </summary>
        public const int MacAddressLength = 6;
        #endregion

        #region ARP
        /// <summary>
        /// Sends an ARP request.
        /// </summary>
        /// <param name="destIp">The IP to send the request to.</param>
        /// <param name="srcIp">The IP to send the request from. Optional (set to 0 to ignore).</param>
        /// <param name="pMacAddr">The bytes of the found MacAddress.</param>
        /// <param name="phyAddrLen">The length of the pMacAddr buffer.</param>
        /// <returns>Status code, 0 if success.</returns>
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        private static extern int SendARP(int destIp, int srcIp, [Out] byte[] pMacAddr, ref int phyAddrLen);
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new MacAddress from an array of bytes.
        /// </summary>
        /// <param name="macAddress">Bytes to create MacAddress from. Must be 6 elements in length.</param>
        /// <exception cref="InvalidMacAddressException">When more or less than 6 elements are provided.</exception>
        public MacAddress(byte[] macAddress)
        {
            if (macAddress.Length != MacAddressLength)
            {
                throw new InvalidMacAddressException(macAddress, nameof(macAddress));
            }
            MacAddressBytes = macAddress;
        }

        /// <summary>
        /// Creates a new MacAddress from a string.
        /// </summary>
        /// <param name="macAddress">The string to create a MacAddress from.
        /// Must be in the form "A0-B1-C2-D3-E4-F6, A0:B1:C2:D3:E4:F6 or A0B1C2D3E4F6 (case insensitive).
        /// </param>
        /// <exception cref="InvalidMacAddressException">If an invalid MacAddress or format was provided.</exception>
        public MacAddress(string macAddress)
        {
            if (!Regex.IsMatch(macAddress, @"^[0-9a-f]{2}((-[0-9a-f]{2}){5})|((:[0-9a-f]{2}){5})|([0-9a-f]{10})$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase))
            {
                throw new InvalidMacAddressException(macAddress, nameof(macAddress));
            }

            if (macAddress.Length == 17)
            {
                macAddress = macAddress.Replace(":", "");
                macAddress = macAddress.Replace("-", "");
            }

            MacAddressBytes = new byte[MacAddressLength];
            for (var i = 0; i < macAddress.Length; i += 2)
            {
                MacAddressBytes[i / 2] = Convert.ToByte(macAddress.Substring(i, 2), 16);
            }
        }

        /// <summary>
        /// Creates a new MacAddress from an IP.
        /// </summary>
        /// <param name="ip">The IP to retreive the MacAddress from.
        /// Note that this NIC must be active and able to respond to ARP requests.</param>
        /// <exception cref="InvalidMacAddressException">If it was not possible to retreive the MacAddress.</exception>
        public MacAddress(IPAddress ip)
        {
            var bytes = new byte[MacAddressLength];
            var len = bytes.Length;
            var res = SendARP(BitConverter.ToInt32(ip.GetAddressBytes(), 0), 0, bytes, ref len);
            if (res != 0)
            {
                throw new InvalidMacAddressException(ip, nameof(ip));
            }
            MacAddressBytes = bytes;
        }
        #endregion

        /// <summary>
        /// Converts this MacAddress to a string representation.
        /// Has the same output as this.MacAddressString.
        /// </summary>
        /// <returns>The string representation of this MacAddress.</returns>
        public override string ToString()
        {
            return MacAddressString;
        }
    }
}
