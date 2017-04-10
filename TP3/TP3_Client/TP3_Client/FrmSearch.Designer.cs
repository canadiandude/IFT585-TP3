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
            this.RTB_Description = new System.Windows.Forms.RichTextBox();
            this.description = new System.Windows.Forms.Label();
            this.BT_Selectionner = new System.Windows.Forms.Button();
            this.BT_Annuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LB_Search
            // 
            this.LB_Search.FormattingEnabled = true;
            this.LB_Search.Location = new System.Drawing.Point(73, 23);
            this.LB_Search.Name = "LB_Search";
            this.LB_Search.Size = new System.Drawing.Size(212, 121);
            this.LB_Search.TabIndex = 0;
            this.LB_Search.SelectedIndexChanged += new System.EventHandler(this.LB_Search_SelectedIndexChanged);
            // 
            // RTB_Description
            // 
            this.RTB_Description.Location = new System.Drawing.Point(73, 173);
            this.RTB_Description.Name = "RTB_Description";
            this.RTB_Description.ReadOnly = true;
            this.RTB_Description.Size = new System.Drawing.Size(212, 133);
            this.RTB_Description.TabIndex = 3;
            this.RTB_Description.Text = "";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(6, 176);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(61, 13);
            this.description.TabIndex = 4;
            this.description.Text = "description:";
            // 
            // BT_Selectionner
            // 
            this.BT_Selectionner.Location = new System.Drawing.Point(129, 323);
            this.BT_Selectionner.Name = "BT_Selectionner";
            this.BT_Selectionner.Size = new System.Drawing.Size(75, 23);
            this.BT_Selectionner.TabIndex = 5;
            this.BT_Selectionner.Text = "Sélectionner";
            this.BT_Selectionner.UseVisualStyleBackColor = true;
            this.BT_Selectionner.Click += new System.EventHandler(this.BT_Selectionner_Click);
            // 
            // BT_Annuler
            // 
            this.BT_Annuler.Location = new System.Drawing.Point(210, 323);
            this.BT_Annuler.Name = "BT_Annuler";
            this.BT_Annuler.Size = new System.Drawing.Size(75, 23);
            this.BT_Annuler.TabIndex = 6;
            this.BT_Annuler.Text = "Annuler";
            this.BT_Annuler.UseVisualStyleBackColor = true;
            this.BT_Annuler.Click += new System.EventHandler(this.BT_Annuler_Click);
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 349);
            this.Controls.Add(this.BT_Annuler);
            this.Controls.Add(this.BT_Selectionner);
            this.Controls.Add(this.description);
            this.Controls.Add(this.RTB_Description);
            this.Controls.Add(this.LB_Search);
            this.Name = "FrmSearch";
            this.Text = "FrmSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_Search;
        private System.Windows.Forms.RichTextBox RTB_Description;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Button BT_Selectionner;
        private System.Windows.Forms.Button BT_Annuler;
    }
}