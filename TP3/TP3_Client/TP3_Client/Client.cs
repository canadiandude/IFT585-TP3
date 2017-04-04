using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace TP3_Client
{
    class Client
    {
        public String Name { get; }
        private Socket socket;

        public static readonly int MAX_DATA_SIZE = 256;

        public Client()
        {
            Name = Guid.NewGuid().ToString().Split('-')[0];
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public String Receive()
        {
            Byte[] data = new Byte[MAX_DATA_SIZE];
            int dataLength = socket.Receive(data, data.Length, 0);
            return Encoding.ASCII.GetString(data, 0, dataLength);
        }

        public void Send(String cmd)
        {
            Byte[] data = Encoding.ASCII.GetBytes(cmd);
            socket.Send(data, data.Length, 0);
        }

        public void Connect(String ipAdress, int port)
        {
            socket.Connect(new IPEndPoint(IPAddress.Parse(ipAdress), port));
            Send(Name);
        }

        public void Disconnect()
        {
            Send("DISCONNECT");
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        public void SendMessage(String msg)
        {
            Send("MSG:" + msg);
        }
    }
}
