using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TP3_Serveur
{
    class Database
    {
        private String connectionString;
        private SqlConnection connection;

        public Database()
        {
            String path = Environment.CurrentDirectory.Replace("bin\\Debug", "");
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "TP3DB.mdf;Integrated Security=True;Connect Timeout=30";
            connection = null;
        }

        private void Connect()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
        }

        private void Disconnect()
        {
            if (connection != null && connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        private void ExecuteNonQuery(String cmd)
        {
            Connect();
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            sqlCmd.ExecuteNonQuery();
            Disconnect();
        }

        private void ExecuteQuery(String cmd, Action<SqlDataReader> callback)
        {
            Connect();
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            SqlDataReader reader = sqlCmd.ExecuteReader();
            callback(reader);
            reader.Close();
            Disconnect();
        }

        public void TestConnection()
        {
            Connect();
            Console.WriteLine("Connection to database OK");
            Disconnect();
        }

        public void CreateUser(String name, String pwd)
        {
            ExecuteNonQuery(String.Format("INSERT INTO Users (Name, Password) VALUES ('{0}','{1}');", name, pwd));
        }

        public void CreateChatroom(String title, String description)
        {
            ExecuteNonQuery(String.Format("INSERT INTO Chatrooms (Title, Description) VALUES ('{0}','{1}');", title, description));
        }

        public void JoinChatroom(int userId, int chatroomId)
        {
            ExecuteNonQuery(String.Format("INSERT INTO UsersChatrooms (UserId, ChatroomId) VALUES ({0},{1});", userId, chatroomId));
        }

        public void CreateMessage(String message, int userId, int chatroomId)
        {
            ExecuteNonQuery(
                String.Format("INSERT INTO Messages (Message, UserId, ChatroomId, Timestamp) VALUES ('{0}',{1},{2},'{3}');",
                message, userId, chatroomId, DateTime.Now)
           );
        }

        public int GetUserId(String name, String pwd)
        {
            int userID = -1;
            String query = String.Format("SELECT Id FROM Users WHERE Name='{0}' AND Password='{1}'", name, pwd);
            ExecuteQuery(query, reader =>
            {
                if (reader.Read())
                {
                    userID = reader.GetInt32(0);
                }
            });
            return userID;
        }

        public List<Chatroom> LoadChatrooms()
        {
            List<Chatroom> chatrooms = new List<Chatroom>();

            String query = "SELECT * FROM Chatrooms";
            ExecuteQuery(query, reader =>
            {
                while (reader.Read())
                {
                    chatrooms.Add(new Chatroom(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
            });

            foreach (Chatroom room in chatrooms)
            {
                room.Messages = LoadMessages(room.Id);
            }

            return chatrooms;
        }

        private List<String> LoadMessages(int chatroomId)
        {
            List<String> messages = new List<String>();

            String query = @"SELECT Message, UserID, Name, Timestamp, Messages.Id FROM Messages
                            INNER JOIN Users ON Users.Id=Messages.UserId 
                            WHERE ChatroomId={0}";
            query = String.Format(query, chatroomId);
            ExecuteQuery(query, reader =>
            {
                while (reader.Read())
                {
                    String message = reader.GetString(0);
                    int userId = reader.GetInt32(1);
                    String user = reader.GetString(2);
                    String timestamp = reader.GetDateTime(3).ToString();
                    int messageId = reader.GetInt32(4);
                    messages.Add(String.Join("|", "M", messageId, 0, user, timestamp, message));
                }
            });

            return messages;
        }

        public List<int> GetChatroomsForUser(int userId)
        {
            List<int> chatroomsId = new List<int>();
            String query = String.Format("SELECT ChatroomId FROM UsersChatrooms WHERE UserId={0}", userId);
            ExecuteQuery(query, reader =>
            {
                while (reader.Read())
                {
                    chatroomsId.Add(reader.GetInt32(0));
                }
            });

            return chatroomsId;
        }

        public List<String> ListUsers()
        {
            List<String> users = new List<String>();
            ExecuteQuery("SELECT Name FROM Users", reader =>
            {
                while (reader.Read())
                {
                    users.Add(reader.GetString(0));
                }
            });

            return users;
        }

        public void DeleteMessage(int messageId)
        {
            ExecuteNonQuery(String.Format("DELETE FROM Messages WHERE Id={0}", messageId));
        }

        public List<String> ListChatrooms()
        {
            List<String> chatrooms = new List<string>();

            ExecuteQuery("SELECT Id, Title, Description FROM Chatrooms", reader =>
            {
                while (reader.Read())
                {
                    chatrooms.Add(String.Join("|", reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
            });

            return chatrooms;
        }
    }
}
