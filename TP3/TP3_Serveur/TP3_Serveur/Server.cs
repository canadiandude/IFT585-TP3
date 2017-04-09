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
        private List<Chatroom> chatrooms;
        private Object connectionLock;

        public Server()
        {
            connectedClients = new List<ClientConnection>();
            database = new Database();
            connectionLock = new Object();
        }

        public void Start(String ipAdress, int port)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(ipAdress), port));
            serverSocket.Listen(10);
            Console.WriteLine("Server socket opened");

            connectionListener = new Thread(CheckForNewConnection);
            connectionListener.Start();
            Console.WriteLine("Connection listener started");

            database.TestConnection();
            LoadChatrooms();

            Console.WriteLine("---------- SERVER READY ----------");
        }

        private void CheckForNewConnection()
        {
            int userId = -1;
            while (true)
            {
                ClientConnection connection = new ClientConnection(serverSocket.Accept());
                String[] credentials = connection.Receive().Split('|');
                Console.WriteLine("new connection with credentials : {0}/{1}", credentials[0], credentials[1]);

                userId = database.GetUserId(credentials[0], credentials[1]);
                if (userId == -1)
                {
                    Console.WriteLine("DENIED - INVALID CREDENTIALS", connection.Name);
                    connection.Send("DENIED_INVALID_CREDENTIALS");
                    connection.Disconnect();
                }
                else if (UserAlreadyConnected(userId))
                {
                    Console.WriteLine("DENIED - ALREADY CONNECTED", connection.Name);
                    connection.Send("DENIED_ALREADY_CONNECTED");
                    connection.Disconnect();
                }
                else
                {
                    connection.Id = userId;
                    connection.Name = credentials[0];
                    lock (connectionLock)
                    {
                        connectedClients.Add(connection);
                    }
                    Console.WriteLine("GRANTED", connection.Name);
                    Console.WriteLine("{0} clients connected", connectedClients.Count);
                    connection.Send("GRANTED");
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
            ClientConnection[] copy;
            lock (connectionLock)
            {
                copy = connectedClients.ToArray();
            }
            foreach (ClientConnection client in copy)
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
            Console.WriteLine("{0} sent \"{1}\"", client.Name, cmd);
            String[] cmdParams = cmd.Split('|');

            switch (cmdParams[0])
            {
                case "MSG":
                    SendMessage(client, int.Parse(cmdParams[1]), String.Join("|", cmdParams.Skip(2)));
                    break;
                case "DISCONNECT":
                    DisconnectClient(client);
                    break;
                case "FETCH_CHATROOMS":
                    SendChatrooms(client);
                    break;
                case "FETCH_USERS":
                    SendOnlineUsers(client);
                    break;
                case "LIST_CHATROOMS":
                    ListChatrooms(client);
                    break;
                case "CREATE_CHATROOM":
                    CreateChatroom(client, cmdParams[1], cmdParams[2]);
                    break;
                default:
                    if (++client.Strikes == 5)
                    {
                        Console.WriteLine("{0} has lost connection", client.Name);
                        DisconnectClient(client);
                    }
                    break;
            }
        }

        private void DisconnectClient(ClientConnection client)
        {
            client.Disconnect();
            connectedClients.Remove(client);
            Console.WriteLine("{0} has disconnected", client.Name);
            Console.WriteLine("{0} clients connected", connectedClients.Count);
        }

        private void SendMessage(ClientConnection client, int chatroomId, String message)
        {
            database.CreateMessage(message, client.Id, chatroomId);
            chatrooms.Find(chatroom => chatroom.Id == chatroomId).Messages = database.LoadMessages(chatroomId);
        }

        private void LoadChatrooms()
        {
            Console.WriteLine("Loading chatrooms...");
            chatrooms = database.LoadChatrooms();
            Console.WriteLine("{0} chatrooms loaded", chatrooms.Count);
        }

        private void SendChatrooms(ClientConnection client)
        {
            List<int> chatroomsId = database.GetChatroomsForUser(client.Id);
            String payload = "";
            foreach (Chatroom room in chatrooms)
            {
                if (chatroomsId.Contains(room.Id))
                {
                    payload += room.ToString();
                }
            }
            if (String.IsNullOrEmpty(payload)) payload = "NONE";
            client.Send(payload);
            Console.WriteLine("{0} chatrooms sent to {1}", chatroomsId.Count, client.Name);
        }

        private void SendOnlineUsers(ClientConnection client)
        {
            List<String> allUsers = database.ListUsers();
            List<String> onlineUsers = new List<String>();
            foreach (ClientConnection c in connectedClients)
            {
                onlineUsers.Add(c.Name);
            }
            for (int i = 0; i < allUsers.Count; ++i)
            {
                allUsers[i] += onlineUsers.Contains(allUsers[i]) ? "|O" : "|N";
            }
            client.Send(String.Join("\n", allUsers));
            Console.WriteLine("User info sent to {0}", client.Name);
        }

        private bool UserAlreadyConnected(int userId)
        {
            foreach (ClientConnection c in connectedClients)
            {
                if (c.Id == userId)
                    return true;
            }
            return false;
        }

        private void ListChatrooms(ClientConnection client)
        {
            String payload = String.Join("\n", database.ListChatrooms());
            client.Send(payload);
            Console.WriteLine("Chatroom list sent to {0}", client.Name);
        }

        private void CreateChatroom(ClientConnection client, String title, String description)
        {
            int id = database.CreateChatroom(title, description);
            database.JoinChatroom(client.Id, id);
            Console.WriteLine("Chatroom \"{0}\" created", title);
            LoadChatrooms();
        }
    }
}
