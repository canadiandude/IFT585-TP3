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

namespace TP3_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = new Client();            
            if (client.Connect(TB_IpAdress.Text, Int32.Parse(TB_Port.Text), TB_Username.Text, TB_Password.Text))
            {
                MessageBox.Show("GRANTED");
                FrmChatroom frmChatroom = new FrmChatroom(client);
                this.Hide();
                frmChatroom.ShowDialog();
            }
            else
                MessageBox.Show("DENIED");
            Thread.Sleep(100);

            client.Disconnect();
        }
    }
}