﻿using System;
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
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+path+"TP3DB.mdf;Integrated Security=True;Connect Timeout=30";
            connection = null;
        }

        private void Connect()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
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

        public bool IsValidCredentials(String name, String pwd)
        {
            bool isValid = false;
            String query = String.Format("SELECT Id,Name FROM Users WHERE Name='{0}' AND Password='{1}'", name, pwd);
            ExecuteQuery(query, reader => {
                isValid = reader.HasRows;
            });
            return isValid;
        }
    }
}
