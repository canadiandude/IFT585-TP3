using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace TP3_Serveur
{
    class ClientConnection
    {
        public int Id;
        public String Name;
        private Socket socket;
        public int Strikes;

        public static readonly int MAX_DATA_SIZE = 256;

        public ClientConnection(Socket s)
        {
            socket = s;
            s.ReceiveTimeout = 100;
            Strikes = 0;
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

        public void Disconnect()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
