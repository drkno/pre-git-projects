using System;
using System.Net;

namespace WakeUpServer.Exceptions
{
    public class InvalidMacAddressException : ArgumentException
    {
        private const string ManualMessageSuffix = " is not a valid mac address.";
        private const string FindMessagePrefix = "Could not find the mac address from IP \"";
        public InvalidMacAddressException(byte[] macAddress, string argumentName) :
            this(BitConverter.ToString(macAddress), argumentName)
        {
        }

        public InvalidMacAddressException(string macAddress, string argumentName) :
            base("\"" + macAddress + "\"" + ManualMessageSuffix, argumentName)
        {
        }

        public InvalidMacAddressException(IPAddress ipAddress, string argumentName) :
            base(FindMessagePrefix + ipAddress + "\"", argumentName)
        {
        }
    }
}