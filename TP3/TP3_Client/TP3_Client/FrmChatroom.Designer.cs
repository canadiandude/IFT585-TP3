namespace TP3_Client
{
    partial class FrmChatroom
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
            this.components = new System.ComponentModel.Container();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.lbRooms = new System.Windows.Forms.ListBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblRoomTitle = new System.Windows.Forms.Label();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblRooms = new System.Windows.Forms.Label();
            this.MenuMessage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.jaimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSend = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.ChatBox = new System.Windows.Forms.ListView();
            this.btnDesabonner = new System.Windows.Forms.Button();
            this.MenuMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(9, 23);
            this.lbUsers.Margin = new System.Windows.Forms.Padding(2);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(170, 199);
            this.lbUsers.TabIndex = 0;
            // 
            // lbRooms
            // 
            this.lbRooms.FormattingEnabled = true;
            this.lbRooms.Location = new System.Drawing.Point(9, 239);
            this.lbRooms.Margin = new System.Windows.Forms.Padding(2);
            this.lbRooms.Name = "lbRooms";
            this.lbRooms.Size = new System.Drawing.Size(170, 199);
            this.lbRooms.TabIndex = 1;
            this.lbRooms.SelectedIndexChanged += new System.EventHandler(this.lbRooms_SelectedIndexChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(9, 442);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(61, 25);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Créer";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(74, 441);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(73, 25);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Recherche";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblRoomTitle
            // 
            this.lblRoomTitle.AutoSize = true;
            this.lblRoomTitle.Location = new System.Drawing.Point(184, 10);
            this.lblRoomTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomTitle.Name = "lblRoomTitle";
            this.lblRoomTitle.Size = new System.Drawing.Size(28, 13);
            this.lblRoomTitle.TabIndex = 4;
            this.lblRoomTitle.Text = "Titre";
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(6, 8);
            this.lblUsers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(55, 13);
            this.lblUsers.TabIndex = 5;
            this.lblUsers.Text = "Usagers : ";
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.Location = new System.Drawing.Point(6, 224);
            this.lblRooms.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(104, 13);
            this.lblRooms.TabIndex = 6;
            this.lblRooms.Text = "Salles de discution : ";
            // 
            // MenuMessage
            // 
            this.MenuMessage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jaimeToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.MenuMessage.Name = "contextMenuStrip1";
            this.MenuMessage.Size = new System.Drawing.Size(130, 48);
            // 
            // jaimeToolStripMenuItem
            // 
            this.jaimeToolStripMenuItem.Name = "jaimeToolStripMenuItem";
            this.jaimeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.jaimeToolStripMenuItem.Text = "J\'aime";
            this.jaimeToolStripMenuItem.Click += new System.EventHandler(this.jaimeToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(517, 442);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(83, 25);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Envoyer";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(232, 442);
            this.txtSend.Margin = new System.Windows.Forms.Padding(2);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(281, 26);
            this.txtSend.TabIndex = 11;
            this.txtSend.Text = "";
            // 
            // ChatBox
            // 
            this.ChatBox.ContextMenuStrip = this.MenuMessage;
            this.ChatBox.FullRowSelect = true;
            this.ChatBox.Location = new System.Drawing.Point(187, 26);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(410, 411);
            this.ChatBox.TabIndex = 12;
            this.ChatBox.UseCompatibleStateImageBehavior = false;
            this.ChatBox.View = System.Windows.Forms.View.Details;
            this.ChatBox.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ChatBox_ColumnWidthChanging);
            this.ChatBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ChatBox_MouseUp);
            // 
            // btnDesabonner
            // 
            this.btnDesabonner.Location = new System.Drawing.Point(152, 441);
            this.btnDesabonner.Name = "btnDesabonner";
            this.btnDesabonner.Size = new System.Drawing.Size(75, 23);
            this.btnDesabonner.TabIndex = 13;
            this.btnDesabonner.Text = "Désabonner";
            this.btnDesabonner.UseVisualStyleBackColor = true;
            this.btnDesabonner.Click += new System.EventHandler(this.btnDesabonner_Click);
            // 
            // FrmChatroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 477);
            this.Controls.Add(this.btnDesabonner);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblRooms);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.lblRoomTitle);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lbRooms);
            this.Controls.Add(this.lbUsers);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmChatroom";
            this.Text = "ChatroomFever";
            this.MenuMessage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.ListBox lbRooms;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblRoomTitle;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblRooms;
        private System.Windows.Forms.ContextMenuStrip MenuMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.RichTextBox txtSend;
        private System.Windows.Forms.ListView ChatBox;
        private System.Windows.Forms.ToolStripMenuItem jaimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.Button btnDesabonner;
    }
}