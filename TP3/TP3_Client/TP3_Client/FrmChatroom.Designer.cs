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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtSend = new System.Windows.Forms.RichTextBox();
            this.ChatBox = new System.Windows.Forms.ListView();
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
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(9, 442);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(98, 25);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(112, 442);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 25);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblRoomTitle
            // 
            this.lblRoomTitle.AutoSize = true;
            this.lblRoomTitle.Location = new System.Drawing.Point(184, 10);
            this.lblRoomTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomTitle.Name = "lblRoomTitle";
            this.lblRoomTitle.Size = new System.Drawing.Size(27, 13);
            this.lblRoomTitle.TabIndex = 4;
            this.lblRoomTitle.Text = "Title";
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(10, 9);
            this.lblUsers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(37, 13);
            this.lblUsers.TabIndex = 5;
            this.lblUsers.Text = "Users:";
            // 
            // lblRooms
            // 
            this.lblRooms.AutoSize = true;
            this.lblRooms.Location = new System.Drawing.Point(10, 223);
            this.lblRooms.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRooms.Name = "lblRooms";
            this.lblRooms.Size = new System.Drawing.Size(43, 13);
            this.lblRooms.TabIndex = 6;
            this.lblRooms.Text = "Rooms:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(517, 442);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(83, 25);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(214, 442);
            this.txtSend.Margin = new System.Windows.Forms.Padding(2);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(299, 26);
            this.txtSend.TabIndex = 11;
            this.txtSend.Text = "";
            // 
            // ChatBox
            // 
            this.ChatBox.ContextMenuStrip = this.contextMenuStrip1;
            this.ChatBox.Location = new System.Drawing.Point(187, 26);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(410, 411);
            this.ChatBox.TabIndex = 12;
            this.ChatBox.UseCompatibleStateImageBehavior = false;
            this.ChatBox.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ChatBox_ColumnWidthChanging);
            this.ChatBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChatBox_MouseClick);
            // 
            // FrmChatroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 477);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.RichTextBox txtSend;
        private System.Windows.Forms.ListView ChatBox;
    }
}