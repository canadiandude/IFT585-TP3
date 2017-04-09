namespace TP3_Client
{
    partial class FrmSearch
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
            this.LB_Search = new System.Windows.Forms.ListBox();
            this.TB_Nom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RTB_Description = new System.Windows.Forms.RichTextBox();
            this.description = new System.Windows.Forms.Label();
            this.BT_Selectionner = new System.Windows.Forms.Button();
            this.BT_Annuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LB_Search
            // 
            this.LB_Search.FormattingEnabled = true;
            this.LB_Search.ItemHeight = 16;
            this.LB_Search.Location = new System.Drawing.Point(108, 70);
            this.LB_Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LB_Search.Name = "LB_Search";
            this.LB_Search.Size = new System.Drawing.Size(281, 148);
            this.LB_Search.TabIndex = 0;
            this.LB_Search.SelectedIndexChanged += new System.EventHandler(this.LB_Search_SelectedIndexChanged);
            // 
            // TB_Nom
            // 
            this.TB_Nom.Location = new System.Drawing.Point(108, 22);
            this.TB_Nom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TB_Nom.Name = "TB_Nom";
            this.TB_Nom.Size = new System.Drawing.Size(281, 22);
            this.TB_Nom.TabIndex = 1;
            this.TB_Nom.TextChanged += new System.EventHandler(this.TB_Nom_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "nom:";
            // 
            // RTB_Description
            // 
            this.RTB_Description.Location = new System.Drawing.Point(108, 255);
            this.RTB_Description.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RTB_Description.Name = "RTB_Description";
            this.RTB_Description.ReadOnly = true;
            this.RTB_Description.Size = new System.Drawing.Size(281, 163);
            this.RTB_Description.TabIndex = 3;
            this.RTB_Description.Text = "";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(19, 258);
            this.description.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(81, 17);
            this.description.TabIndex = 4;
            this.description.Text = "description:";
            // 
            // BT_Selectionner
            // 
            this.BT_Selectionner.Location = new System.Drawing.Point(183, 439);
            this.BT_Selectionner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BT_Selectionner.Name = "BT_Selectionner";
            this.BT_Selectionner.Size = new System.Drawing.Size(100, 28);
            this.BT_Selectionner.TabIndex = 5;
            this.BT_Selectionner.Text = "Sélectionner";
            this.BT_Selectionner.UseVisualStyleBackColor = true;
            // 
            // BT_Annuler
            // 
            this.BT_Annuler.Location = new System.Drawing.Point(291, 439);
            this.BT_Annuler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BT_Annuler.Name = "BT_Annuler";
            this.BT_Annuler.Size = new System.Drawing.Size(100, 28);
            this.BT_Annuler.TabIndex = 6;
            this.BT_Annuler.Text = "Annuler";
            this.BT_Annuler.UseVisualStyleBackColor = true;
            this.BT_Annuler.Click += new System.EventHandler(this.BT_Annuler_Click);
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 482);
            this.Controls.Add(this.BT_Annuler);
            this.Controls.Add(this.BT_Selectionner);
            this.Controls.Add(this.description);
            this.Controls.Add(this.RTB_Description);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_Nom);
            this.Controls.Add(this.LB_Search);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmSearch";
            this.Text = "FrmSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Search;
        private System.Windows.Forms.TextBox TB_Nom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox RTB_Description;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Button BT_Selectionner;
        private System.Windows.Forms.Button BT_Annuler;
    }
}