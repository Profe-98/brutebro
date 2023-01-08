using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;

namespace bruteBro.Class.Network
{
    public static class NetworkObjectManager
    {
        public static List<NetworkInterface> GetNetworkIntegratedCards()
        {
            List<NetworkInterface> responseNICs = new List<NetworkInterface>();
            List<NetworkInterface> nic = ObjectManager.GetNetworkIntegratedCards();
            for (int i = 0; i < nic.Count; i++)
            {
                responseNICs.Add(nic[i]);
            }
            return responseNICs;
        }

        public static List<IPAddress> GetNICAddresses(NetworkInterface nic,AddressFamily addrFamily = AddressFamily.InterNetwork)
        {
            List<IPAddress> responseAddresses = new List<IPAddress>();
            foreach (UnicastIPAddressInformation ip in nic.GetIPProperties().UnicastAddresses)
            {
                if (ip.Address.AddressFamily == addrFamily)
                {
                    responseAddresses.Add(ip.Address);
                }
            }
            return responseAddresses;
        }

        public static PingReply PingDestination(IPAddress destination,int maxHops = 30,int pingTimeout = 5000)
        {
            if (destination == null)
                return null;

            Ping ping = new Ping();
            PingReply pingResponse = null;
            try
            {
                PingOptions pingOptions = new PingOptions(maxHops, true);
                pingResponse = ping.Send(destination, pingTimeout, new byte[32], pingOptions);
                
            }
            catch (PingException ex)
            {

            }
            return pingResponse;
        }

        public static List<PingReply> TraceRoute(IPAddress destination,int maxHops = 30, int pingTimeout = 5000)
        {
            if (destination == null)
                return null;

            List<PingReply> responseHops = new List<PingReply>();
            Ping ping = new Ping();
            PingReply pingResponse = null;
            int hops = 0;
            while(pingResponse.Address != destination && hops <= maxHops)
            {
                hops++;
                PingOptions pingOptions = new PingOptions(hops, true);
                try
                {
                    pingResponse = ping.Send(destination, pingTimeout, new byte[32], pingOptions);

                    if (pingResponse != null)
                        responseHops.Add(pingResponse);
                }
                catch(PingException ex)
                {
                    responseHops.Add(pingResponse);
                }
            }
            return responseHops;
        }

        public static bool SendTCPSyn(IPAddress destination,int port)
        {
            bool response = false;
            if (destination == null)
                return response;

            if (port <= 0 || port >= 4096)
                return response;

            try
            {
                using (Socket sock = new Socket(SocketType.Raw,ProtocolType.Tcp))
                {
                    sock.Connect(destination, port);
                    int x = 0;
                    //hier noch herausfinden wie man dediziert ein syn packet sendet
                    sock.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.AcceptConnection, true);
                    sock.Send(new byte[32], SocketFlags.None);
                    
                }
            }
            catch(Exception ex)
            {

            }
            return response;
        }
    }
}
