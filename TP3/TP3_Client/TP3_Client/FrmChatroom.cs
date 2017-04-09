﻿using System;
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
            lbRooms.SelectionMode = SelectionMode.One;
            lbRooms.DisplayMember = "Value";
            InitChatBox();
            FetchChatroom();
            FillListBoxes();
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
        }

        private void FillListBoxes() {
            foreach (Chatroom c in chatrooms)
            {
                lbRooms.Items.Add(new KeyValuePair<Object, String>(c, c.Titre));
            }
            lbRooms.SetSelected(0, true);
        }

        private void LoadSelectedListboxMessages() {
            for (int i = 0; i < lbRooms.Items.Count; i++)
            {
                if (lbRooms.GetSelected(i))
                {
                    KeyValuePair<Object, String> selected = (KeyValuePair<Object,String>) lbRooms.Items[i];
                    Chatroom c = (Chatroom) selected.Key;
                    foreach (Message m in c.MessageList)
                    {
                        AddMessage(0.ToString(), m.Id.ToString(), m.Username, m.Date, m.Content, m.Likes);
                    }
                }
            }
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
        }

        public void AddMessage(String UserID, String MsgID, String User, DateTime time, String Message, int like)
        {
            string[] row = { UserID, MsgID, User, time.ToString(), Message, like.ToString() };
            var listViewItem = new ListViewItem(row);
            ChatBox.Items.Add(listViewItem);
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

        private void lbRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChatBox.Items.Clear();
            LoadSelectedListboxMessages();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtSend.TextLength != 0) {
                client.SendMessage(txtSend.Text);
            }
        }
    }
}
