using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace bruteBro.Class.Network
{
    public static class ConnHndlr
    {
        public static Socket ConnectToTrgt(IPAddress addr, int port)
        {
            if (addr == null)
                return null;
            IPEndPoint trgtnode = new IPEndPoint(addr, port);
            using (Socket socket = new Socket(addr.AddressFamily, SocketType.Stream, ProtocolType.IP))
            {
                socket.Connect(trgtnode);
                return socket;
            }

        }
    }
}
