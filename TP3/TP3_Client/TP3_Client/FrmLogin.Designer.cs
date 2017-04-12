namespace TP3_Client
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.TB_IpAdress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Port = new System.Windows.Forms.TextBox();
            this.TB_Username = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Connexion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TB_IpAdress
            // 
            this.TB_IpAdress.Location = new System.Drawing.Point(98, 6);
            this.TB_IpAdress.Name = "TB_IpAdress";
            this.TB_IpAdress.Size = new System.Drawing.Size(114, 20);
            this.TB_IpAdress.TabIndex = 1;
            this.TB_IpAdress.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Adresse IP : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port :";
            // 
            // TB_Port
            // 
            this.TB_Port.Location = new System.Drawing.Point(98, 32);
            this.TB_Port.Name = "TB_Port";
            this.TB_Port.Size = new System.Drawing.Size(114, 20);
            this.TB_Port.TabIndex = 2;
            this.TB_Port.Text = "42";
            // 
            // TB_Username
            // 
            this.TB_Username.Location = new System.Drawing.Point(98, 58);
            this.TB_Username.Name = "TB_Username";
            this.TB_Username.Size = new System.Drawing.Size(114, 20);
            this.TB_Username.TabIndex = 3;
            this.TB_Username.Text = "jack";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nom d\'usager :";
            // 
            // TB_Password
            // 
            this.TB_Password.Location = new System.Drawing.Point(98, 84);
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.Size = new System.Drawing.Size(114, 20);
            this.TB_Password.TabIndex = 4;
            this.TB_Password.Text = "a";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mot de passe : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 145);
            this.Controls.Add(this.TB_Password);
            this.Controls.Add(this.TB_Username);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_IpAdress);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Connexion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TB_IpAdress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Port;
        private System.Windows.Forms.TextBox TB_Username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Password;
        private System.Windows.Forms.Label label4;
    }
}

