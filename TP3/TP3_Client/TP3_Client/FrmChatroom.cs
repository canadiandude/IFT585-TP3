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
        private Thread listenner;
        private ListView.SelectedIndexCollection SelectedIndice;
        private int Indice = -1;
        public FrmChatroom(Client c)
        {
            InitializeComponent();
            client = c;
            lbRooms.SelectionMode = SelectionMode.One;
            lbRooms.DisplayMember = "Value";
            lbUsers.SelectionMode = SelectionMode.None;
            InitChatBox();
            listenner = new Thread(Fetch);
            listenner.Start();
        }
        public FrmChatroom()
        {
            InitializeComponent();
            InitChatBox();
        }
        public void Fetch()
        {
            while (true)
            {
                FetchChatroom();
                FetchUsers();
                Thread.Sleep(2000);
            }
        }

        public void FetchChatroom()
        {
            chatrooms = new List<Chatroom>();
            client.Send("FETCH_CHATROOMS");
            Thread.Sleep(100);
            string receive = client.Receive();
            if (receive != "NONE")
            {
                Chatroom currentChatroom = null;
                string[] lineSplit = receive.Split('\n');
                try
                {
                    for (int i = 0; i < lineSplit.Length; i++)
                    {
                        string[] propsSplit = lineSplit[i].Split('|');
                        if (propsSplit[0] == "C")
                        {
                            if (propsSplit.Length == 4)
                            {
                                if (currentChatroom != null)
                                    chatrooms.Add(currentChatroom);
                                currentChatroom = new Chatroom();
                                currentChatroom.Id = int.Parse(propsSplit[1]);
                                currentChatroom.Titre = propsSplit[2];
                                currentChatroom.Desc = propsSplit[3];
                            }
                        }
                        if (propsSplit[0] == "M")
                        {
                            if (propsSplit.Length == 6)
                            {
                                Message m = new Message();
                                m.Id = int.Parse(propsSplit[1]);
                                m.Likes = int.Parse(propsSplit[2]);
                                m.Username = propsSplit[3];
                                m.Date = Convert.ToDateTime(propsSplit[4].ToString());
                                m.Content = propsSplit[5];
                                currentChatroom.MessageList.Add(m);
                            }
                        }
                        if (lineSplit.Length - 1 == i)
                        {
                            if (chatrooms != null)
                                chatrooms.Add(currentChatroom);
                        }
                    }
                    FillListBoxes();
                }
                catch (ApplicationException ex)
                {
                    client.Disconnect();
                }
            }
        }

        public void FetchUsers()
        {
            lbUsers.Items.Clear();
            client.Send("FETCH_USERS");
            Thread.Sleep(100);
            string receive = client.Receive();
            string[] lineSplit = receive.Split('\n');
            for (int i = 0; i < lineSplit.Length; i++)
            {
                string[] propsSplit = lineSplit[i].Split('|');
                string state = "";
                if (propsSplit[1] == "O")
                    state = " [ONLINE]";
                lbUsers.Items.Add(propsSplit[0] + state);
            }
        }

        private void FillListBoxes()
        {
            int selected = -1;
            if (GetSelectedChatroom() != null)
                selected = GetSelectedChatroom().Id;
            lbRooms.Items.Clear();
            foreach (Chatroom c in chatrooms)
            {
                lbRooms.Items.Add(new KeyValuePair<Object, String>(c, c.Titre));
                if (selected >= 0 && c.Id == selected)
                    lbRooms.SelectedIndex = lbRooms.Items.Count - 1;
            }

        }

        private void LoadSelectedListboxMessages()
        {
            Chatroom c = GetSelectedChatroom();
            if (c != null)
            {
                lblRoomTitle.Text = c.Titre;
                foreach (Message m in c.MessageList)
                {
                    AddMessage(0.ToString(), m.Id.ToString(), m.Username, m.Date, m.Content, m.Likes);
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
            AddMessage("123", "456", "Alex", DateTime.Now, "test", 3);
            AddMessage("246", "357", "john", DateTime.Now, "t fife", 3);
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
            listenner.Abort();
            client.Disconnect();
        }

        private void lbRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChatBox.Items.Clear();
            LoadSelectedListboxMessages();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtSend.TextLength != 0)
            {
                client.SendMessage(GetSelectedChatroom().Id, txtSend.Text);
                txtSend.Text = "";
            }
        }

        private Chatroom GetSelectedChatroom()
        {
            if (lbRooms.SelectedItem != null)
            {
                KeyValuePair<Object, String> selected = (KeyValuePair<Object, String>)lbRooms.SelectedItem;
                Chatroom c = (Chatroom)selected.Key;
                return c;
            }
            return null;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FrmCreateChatroom frmCreateChatroom = new FrmCreateChatroom(client);
            frmCreateChatroom.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FrmSearch frmSearch = new FrmSearch(client);
            frmSearch.Show();
        }




        private void ChatBox_MouseUp(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;

            if (e.Button == MouseButtons.Right)
            {
                SelectedIndice = listView.SelectedIndices;
                if (SelectedIndice != null && SelectedIndice.Count != 0)
                {
                    Indice = SelectedIndice[0];
                    //  ChatBox.ContextMenu.Show(MenuMessage, new Point(e.X, e.Y));
                }
            }
        }

        private void jaimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChatBox.Items.Count != 0)
            {
                if (Indice != -1)
                {
                    var SelectedRow = ChatBox.Items[Indice].SubItems;
                    if (SelectedRow != null)
                    {
                        /* string[] row = new string[6];
                         for (int i = 0; i < SelectedRow.Count; ++i)
                         {
                             row[i] = SelectedRow[i].Text.ToString(); // declare numbers as an int array of any size
                         }
                         int x = Convert.ToInt32(row[5]);
                         ++x;
                         row[5] = x.ToString();
                         var listViewItem = new ListViewItem(row);
                         ChatBox.Items[Indice] = listViewItem;
                         Indice = -1;
                         client.Send("LIKE|" + row[1].ToString());
                         */
                        Indice = -1;
                        client.Send("LIKE|" + SelectedRow[1].Text.ToString());

                    }
                }
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChatBox.Items.Count != 0)
            {
                if (Indice != -1)
                {
                    var SelectedRow = ChatBox.Items[Indice].SubItems;
                    if (SelectedRow != null)
                    {
                        ChatBox.Items.RemoveAt(Indice);
                        Indice = -1;
                        MessageBox.Show(String.Format("Client : {0} | Selected : {1}", client.Name, SelectedRow[2].Text.ToString()));
                        if (client.Name == SelectedRow[2].Text.ToString())
                            client.Send("DELETE|" + SelectedRow[1].Text.ToString());
                    }

                }
            }
        }


    }
}
