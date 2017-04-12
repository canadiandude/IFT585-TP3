using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TP3_Client
{
    public class Client
    {
        public String Name { get; }
        private Socket socket;

        public static readonly int MAX_DATA_SIZE = 1000000;

        public Client(String name)
        {
            Name = name;
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

        public bool Connect(String ipAdress, int port, String name, String pwd)
        {
            socket.Connect(new IPEndPoint(IPAddress.Parse(ipAdress), port));
            return ValidateCredentials(name, pwd);
        }

        public void Disconnect()
        {
            Send("DISCONNECT");
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        public void SendMessage(int chatroomId, string contenu)
        {
            Send("MSG|" + chatroomId.ToString() + "|" + contenu);
        }

        private bool ValidateCredentials(String name, String pwd)
        {
            Send(String.Format("{0}|{1}", name, pwd));
            String response = Receive();
            if (response == "DENIED_INVALID_CREDENTIALS") MessageBox.Show("Nom d'usager et/ou mot de passe invalides");
            else if (response == "DENIED_ALREADY_CONNECTED") MessageBox.Show("Cet usager est déjà connecté");
            return response == "GRANTED";
        }
    }
}
