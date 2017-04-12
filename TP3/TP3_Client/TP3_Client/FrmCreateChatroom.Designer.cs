namespace TP3_Client
{
    partial class FrmCreateChatroom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TB_Chatroom_Name = new System.Windows.Forms.TextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BT_Annuler = new System.Windows.Forms.Button();
            this.BT_Creer = new System.Windows.Forms.Button();
            this.RTB_Description = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TB_Chatroom_Name
            // 
            this.TB_Chatroom_Name.Location = new System.Drawing.Point(84, 17);
            this.TB_Chatroom_Name.Name = "TB_Chatroom_Name";
            this.TB_Chatroom_Name.Size = new System.Drawing.Size(181, 20);
            this.TB_Chatroom_Name.TabIndex = 0;
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(35, 20);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(35, 13);
            this.lblNom.TabIndex = 1;
            this.lblNom.Text = "Nom: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // BT_Annuler
            // 
            this.BT_Annuler.Location = new System.Drawing.Point(190, 195);
            this.BT_Annuler.Name = "BT_Annuler";
            this.BT_Annuler.Size = new System.Drawing.Size(75, 23);
            this.BT_Annuler.TabIndex = 3;
            this.BT_Annuler.Text = "Annuler";
            this.BT_Annuler.UseVisualStyleBackColor = true;
            this.BT_Annuler.Click += new System.EventHandler(this.BT_Annuler_Click);
            // 
            // BT_Creer
            // 
            this.BT_Creer.Location = new System.Drawing.Point(109, 195);
            this.BT_Creer.Name = "BT_Creer";
            this.BT_Creer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BT_Creer.Size = new System.Drawing.Size(75, 23);
            this.BT_Creer.TabIndex = 4;
            this.BT_Creer.Text = "Créer";
            this.BT_Creer.UseVisualStyleBackColor = true;
            this.BT_Creer.Click += new System.EventHandler(this.BT_Creer_Click);
            // 
            // RTB_Description
            // 
            this.RTB_Description.Location = new System.Drawing.Point(85, 56);
            this.RTB_Description.Name = "RTB_Description";
            this.RTB_Description.Size = new System.Drawing.Size(181, 120);
            this.RTB_Description.TabIndex = 5;
            this.RTB_Description.Text = "";
            // 
            // FrmCreateChatroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 226);
            this.Controls.Add(this.RTB_Description);
            this.Controls.Add(this.BT_Creer);
            this.Controls.Add(this.BT_Annuler);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.TB_Chatroom_Name);
            this.Name = "FrmCreateChatroom";
            this.Text = "Création de salle de discution";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Chatroom_Name;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_Annuler;
        private System.Windows.Forms.Button BT_Creer;
        private System.Windows.Forms.RichTextBox RTB_Description;
    }
}