using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace TP3_Serveur
{
    class Server
    {
        private List<ClientConnection> connectedClients;
        private Socket serverSocket;
        private Thread connectionListener;

        public Server(String ipAdress, int port)
        {
            connectedClients = new List<ClientConnection>();

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ipAdress), port));
            serverSocket.Listen(10);

            connectionListener = new Thread(CheckForNewConnection);
            connectionListener.Start();
        }

        private void CheckForNewConnection()
        {
            while (true)
            {
                ClientConnection connection = new ClientConnection(serverSocket.Accept());
                connectedClients.Add(connection);
                Console.WriteLine("SERVER   | {0} has connected", connection.Name);
                Console.WriteLine("SERVER   | {0} clients connected", connectedClients.Count);
            }
        }

        public void Close()
        {
            Environment.Exit(0);
        }

        public void ReceiveFromClients()
        {
            // Faire une copie de la liste pour eviter les problemes quand on 
            // enleve une connexion de la liste
            // Solution alternative : iterer a l'envers
            foreach (ClientConnection client in connectedClients.ToArray())
            {
                try
                {
                    String cmd = client.Receive();
                    HandleCommand(client, cmd);
                }
                catch (SocketException se)
                {
                    // Client timeout
                    continue;
                }
            }
        }

        private void HandleCommand(ClientConnection client, String cmd)
        {
            Console.WriteLine("SERVER   | {0} sent \"{1}\"", client.Name, cmd);
            String[] cmdParams = cmd.Split(':');

            switch (cmdParams[0])
            {
                case "MSG":
                    SendMessage(client.Name + " : " + String.Join(":", cmdParams.Skip(1)));
                    break;
                case "DISCONNECT":
                    DisconnectClient(client);
                    break;
                default:
                    client.Send("ACK");
                    break;
            }
        }

        private void DisconnectClient(ClientConnection client)
        {
            client.Disconnect();
            connectedClients.Remove(client);
            Console.WriteLine("SERVER   | {0} has disconnected", client.Name);
            Console.WriteLine("SERVER   | {0} clients connected", connectedClients.Count);
        }

        private void SendMessage(String msg)
        {
            foreach (ClientConnection client in connectedClients)
            {
                client.Send(msg);
            }
        }
    }
}
