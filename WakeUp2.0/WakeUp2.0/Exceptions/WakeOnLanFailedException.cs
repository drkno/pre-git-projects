using System;

namespace WakeUpServer.Exceptions
{
    public class WakeOnLanFailedException : Exception
    {
        public WakeOnLanFailedException(MacAddress macAddress, Exception exception) :
            base("Attempting to wake up \"" + macAddress + "\" failed.", exception)
        {
        }
    }
}