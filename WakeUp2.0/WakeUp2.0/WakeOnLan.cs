using System;
using System.Net;
using System.Net.Sockets;
using WakeUpServer.Exceptions;

namespace WakeUpServer
{
    /// <summary>
    /// Provides helper methods for performing WakeOnLan actions.
    /// </summary>
    public static class WakeOnLan
    {
        /// <summary>
        /// Default port for a WakeOnLan packet.
        /// </summary>
        private const int WakeOnLanPort = 9;

        /// <summary>
        /// Size of a WakeOnLan packet.
        /// </summary>
        private const int WakeOnLanPacketSize = 102;

        /// <summary>
        /// Wakes the computer with a given MacAddress.
        /// </summary>
        /// <param name="macAddress">The computer to wake up.</param>
        /// <param name="port">The port to send the packet on. Defaults to UDP 9.</param>
        public static void WakeUp(MacAddress macAddress, int port = WakeOnLanPort)
        {
            try
            {
                var packet = ConstructPacket(macAddress);
                var client = new UdpClient();
                client.Connect(IPAddress.Broadcast, port);
                client.Send(packet, packet.Length);
            }
            catch (Exception e)
            {
                throw new WakeOnLanFailedException(macAddress, e);
            }
        }

        /// <summary>
        /// Constructs a WakeOnLan magic packet.
        /// </summary>
        /// <param name="macAddress">MacAddress to construct the packet from.</param>
        /// <returns>A byte[] representing the magic packet.</returns>
        private static byte[] ConstructPacket(MacAddress macAddress)
        {
            if (macAddress == null)
            {
                throw new ArgumentNullException(nameof(macAddress), "A MacAddress must be provided.");
            }

            var packet = new byte[WakeOnLanPacketSize];
            for (var i = 0; i < MacAddress.MacAddressLength; i++)
            {
                packet[i] = 0xFF;   // packet header
            }
            // packet body
            for (var i = 1; i < 17; i++)
            {
                Array.Copy(macAddress.MacAddressBytes, 0, packet, i * MacAddress.MacAddressLength, MacAddress.MacAddressLength);
            }
            return packet;
        }
    }
}
