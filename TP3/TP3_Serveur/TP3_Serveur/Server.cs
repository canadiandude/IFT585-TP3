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
        private Database database;

        public Server(String ipAdress, int port)
        {
            connectedClients = new List<ClientConnection>();

            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ipAdress), port));
            serverSocket.Listen(10);
            Console.WriteLine("Server socket opened");

            connectionListener = new Thread(CheckForNewConnection);
            connectionListener.Start();
            Console.WriteLine("Connection listener started");

            database = new Database();
            database.TestConnection();
            Console.WriteLine("---------- SERVER READY ----------");
        }

        private void CheckForNewConnection()
        {
            while (true)
            {
                ClientConnection connection = new ClientConnection(serverSocket.Accept());
                String[] credentials = connection.Receive().Split(':');
                Console.WriteLine("SERVER   | new connection with credentials : {0}/{1}", credentials[0], credentials[1]);

                if (Authenticate(credentials[0], credentials[1]))
                {
                    connection.Name = credentials[0];
                    connectedClients.Add(connection);
                    Console.WriteLine("SERVER   | GRANTED", connection.Name);
                    Console.WriteLine("SERVER   | {0} clients connected", connectedClients.Count);
                    connection.Send("GRANTED");
                }
                else
                {
                    Console.WriteLine("SERVER   | DENIED", connection.Name);
                    connection.Send("DENIED");
                    connection.Disconnect();
                }

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

        private bool Authenticate(String name, String pwd)
        {
            return database.IsValidCredentials(name, pwd);
        }
    }
}
