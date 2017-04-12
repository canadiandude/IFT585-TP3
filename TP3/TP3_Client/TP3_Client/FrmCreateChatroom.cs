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
    public partial class FrmCreateChatroom : Form
    {
        private Client client;
        public FrmCreateChatroom(Client c)
        {
            client = c;
            InitializeComponent();
        }

        private void BT_Creer_Click(object sender, EventArgs e)
        {
            if (TB_Chatroom_Name.TextLength == 0 || RTB_Description.TextLength == 0)
                MessageBox.Show("Veuillez remplir tout les champs");
            else {
                client.Send("CREATE_CHATROOM|" + TB_Chatroom_Name.Text.Replace("|", "") + "|" + RTB_Description.Text.Replace("|", ""));
                Close();
            }
        }

        private void BT_Annuler_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
