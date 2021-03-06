﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Net.Sockets;

namespace TP3_Client
{
    public partial class FrmSearch : Form
    {

        public Client client;
        public String[] lineSplit;
        

        public FrmSearch(Client c)
        {
            client = c;
            InitializeComponent();
            ListChatrooms();
        }
        public void ListChatrooms()
        {
            client.Send("LIST_CHATROOMS");
            Thread.Sleep(100);
            String receive = client.Receive();
            if(receive != "NONE")
            {
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
           
        }
     
        private void LB_Search_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[] chatRoomInfo;
            for (int i = 0; i < lineSplit.Length; i++)
            {
                if (lineSplit[i].Length != 0)
                {
                    chatRoomInfo = lineSplit[i].Split('|');
                    if (chatRoomInfo[1] == LB_Search.SelectedItem.ToString())
                    {
                        RTB_Description.Text = chatRoomInfo[2];
                    }
                }                
            }
        }

        private void BT_Annuler_Click(object sender, EventArgs e)
        {      
             this.Close();  
        }

        private void BT_Selectionner_Click(object sender, EventArgs e)
        {
            if (LB_Search.SelectedIndex != -1)
            {
                String[] chatRoomInfo;
                for (int i = 0; i < lineSplit.Length; i++)
                {
                    chatRoomInfo = lineSplit[i].Split('|');
                    if(chatRoomInfo[1] == LB_Search.SelectedItem.ToString())
                    {
                        client.Send("JOIN|" + chatRoomInfo[0]);
                        this.Close();
                    }
                }
            }
        }
    }
}
