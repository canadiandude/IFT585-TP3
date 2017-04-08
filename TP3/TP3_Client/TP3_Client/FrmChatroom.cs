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
            chatrooms = new List<Chatroom>();
            FetchChatroom();
            InitChatBox();
        }

        public void FetchChatroom()
        {
            client.Send("FETCH_CHATROOMS");
            Thread.Sleep(100);
            string receive = client.Receive();
            MessageBox.Show(receive);
            Chatroom currentChatroom = null;
            string[] lineSplit = receive.Split('\n');
            try {
                for(int i = 0; i < lineSplit.Length; i++)
                {
                    string[] propsSplit = lineSplit[i].Split('|');
                    if (propsSplit[0] == "C")
                    {
                        if (currentChatroom != null)
                            chatrooms.Add(currentChatroom);
                        currentChatroom = new Chatroom();
                        currentChatroom.Id = int.Parse(propsSplit[1]);
                        currentChatroom.Titre = propsSplit[2];
                        currentChatroom.Desc = propsSplit[3];
                    }
                    if (propsSplit[0] == "M")
                    {
                        Message m = new Message();
                        m.Id = int.Parse(propsSplit[1]);
                        m.Likes = int.Parse(propsSplit[2]);
                        m.Username = propsSplit[3];
                        m.Date = Convert.ToDateTime(propsSplit[4].ToString());
                        m.Content = propsSplit[5];
                        currentChatroom.MessageList.Add(m);
                    }
                    if (lineSplit.Length-1 == i) {
                        if (chatrooms != null)
                            chatrooms.Add(currentChatroom);
                    }
                }
            } catch (ApplicationException ex) {
                client.Disconnect();
            }
            MessageBox.Show(chatrooms.ToString());
        }
        private void InitChatBox()
        {
            ChatBox.View = View.Details;
            // Add a column with width 20 and left alignment.
            ChatBox.Columns.Add("UserID", 0, HorizontalAlignment.Left);
            ChatBox.Columns.Add("MessageID", 0, HorizontalAlignment.Left);
            ChatBox.Columns[0].Width = 0;
            ChatBox.Columns[1].Width = 0;

            ChatBox.Columns.Add("Utilisateur", ChatBox.Size.Width * 20 / 100, HorizontalAlignment.Left);
            ChatBox.Columns.Add("Date", ChatBox.Size.Width * 15 / 100, HorizontalAlignment.Left);
            ChatBox.Columns.Add("Message", ChatBox.Size.Width * 55 / 100, HorizontalAlignment.Left);
            ChatBox.Columns.Add("Like", ChatBox.Size.Width * 10 / 100, HorizontalAlignment.Left);
            AddMessage("123", "456", "Alex", DateTime.Now, "test", 3);
        }
        public void AddMessage(String UserID, String MsgID, String User, DateTime time, String Message, int like)
        {
            string[] row = { UserID, MsgID, User, time.ToString(), Message, like.ToString() };
            var listViewItem = new ListViewItem(row);
            ChatBox.Items.Add(listViewItem);
            //ChatBox.Items.Add("test");
        }

        private void ChatBox_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            //This will try hiding the column at index 1
            //ColumnWidthChanging event handler of your ListView
            if (e.ColumnIndex == 1 || e.ColumnIndex == 0)
            {
                e.Cancel = true;
                e.NewWidth = 0;
            }
        }

        private void FrmChatroom_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Disconnect();
        }
    }
}
