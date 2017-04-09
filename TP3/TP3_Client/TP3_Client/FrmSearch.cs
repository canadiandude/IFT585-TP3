using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net.Sockets;

namespace TP3_Client
{
    public partial class FrmSearch : Form
    {

        public Client client;
        public String[] lineSplit;
        //public Array<int, String> idDescription;
        public FrmSearch()
        {
            
            InitializeComponent();
            ListChatrooms();
        }
        public void ListChatrooms()
        {
            //client.Send("LIST_CHATROOMS");
            // Thread.Sleep(100);
            String receive = "10|CharlieRoom|des affaire dememe pis dautre pas dememe\n20|dario|fuckyou\n";//client.Receive();
            lineSplit = receive.Split('\n');

            String []chatRoomInfo; 
            for (int i = 0; i < lineSplit.Length; i++)
            {
                if (lineSplit[i].Length!=0)
                {
                    chatRoomInfo = lineSplit[i].Split('|');
                    LB_Search.Items.Add(chatRoomInfo[1]);
                }           
            }
        }
        private void TB_Nom_TextChanged(object sender, EventArgs e)
        {
            int index;
            if (TB_Nom.TextLength != 0)
            {
                index = LB_Search.FindString(TB_Nom.Text);
                if (index != -1)
                {                    
                    LB_Search.SetSelected(index, true);
                }
            }               
        }

        private void LB_Search_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BT_Annuler_Click(object sender, EventArgs e)
        {      
             this.Close();  
        }
    }
}
