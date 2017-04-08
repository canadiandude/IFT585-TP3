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

        public void FetChatroom()
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
    }
}
