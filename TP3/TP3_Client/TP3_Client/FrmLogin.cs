﻿using System;
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
    public partial class Form1 : Form
    {
        Client client;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                client = new Client(TB_Username.Text);
                bool connect = client.Connect(TB_IpAdress.Text, Int32.Parse(TB_Port.Text), TB_Username.Text, TB_Password.Text);
                if (connect)
                {
                    FrmChatroom frmChatroom = new FrmChatroom(client);
                    this.Hide();
                    frmChatroom.ShowDialog();
                    this.Close();
                }
                else
                {
                    Thread.Sleep(100);
                    client.Disconnect();
                }
            }
            catch (SocketException)
            {
                MessageBox.Show(String.Format("Serveur inaccessible à l'adresse '{0}:{1}'", TB_IpAdress.Text, TB_Port.Text));
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                client.Disconnect();
            }
            catch (Exception)
            {
            }
        }
    }
}