using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3_Client
{
    public partial class FrmChatroom : Form
    {
        private Client client;
        private List<Chatroom> chatrooms;
        public FrmChatroom(Client c)
        {
            InitializeComponent();
            client = c;
        }

        public void FetchChatroom()
        {
            client.Send("FETCH_CHATROOMS");
            Thread.Sleep(100);
            string receive = client.Receive();
            MessageBox.Show(receive);
            string[] lineSplit = receive.Split('\n');
            foreach (string obj in lineSplit)
            {
                string[] propsSplit = obj.Split('|');
                Chatroom currentChatroom = new Chatroom();
                for (int i = 0; i < propsSplit.Length; i++)
                {
                    
                }
            }
        }
        private void InitChatBox()
        {
            ChatBox.View = View.Details;
            // Add a column with width 20 and left alignment.
            ChatBox.Columns.Add("Utilisateur", ChatBox.Size.Width*20/100, HorizontalAlignment.Left);
            ChatBox.Columns.Add("Date", ChatBox.Size.Width*15/100, HorizontalAlignment.Left);
            ChatBox.Columns.Add("Message", ChatBox.Size.Width * 55 / 100, HorizontalAlignment.Left);
            ChatBox.Columns.Add("Like", ChatBox.Size.Width * 10 / 100, HorizontalAlignment.Left);
            AddMessage("Alex",DateTime.Now,"test",3);
        }
        public void AddMessage(String User,DateTime time,String Message,int like)
        {
            string[] row = { User, time.ToString() ,Message,like.ToString()};
            var listViewItem = new ListViewItem(row);
            ChatBox.Items.Add(listViewItem);
            //ChatBox.Items.Add("test");
        }

    }
}
