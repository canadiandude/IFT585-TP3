using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3_Client
{
    public partial class FrmChatroom : Form
    {
        public FrmChatroom()
        {
            InitializeComponent();
            InitChatBox();
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
