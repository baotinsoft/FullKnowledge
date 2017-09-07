namespace FullKnowledge
{
    partial class frmMain
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDBSync = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKnowledge = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuForex = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLand = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStock = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(807, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDBSync,
            this.mnuKnowledge,
            this.mnuForex,
            this.mnuLand,
            this.mnuStock});
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.applicationsToolStripMenuItem.Text = "Applications";
            // 
            // mnuDBSync
            // 
            this.mnuDBSync.Name = "mnuDBSync";
            this.mnuDBSync.Size = new System.Drawing.Size(152, 22);
            this.mnuDBSync.Text = "DB Sync";
            this.mnuDBSync.Click += new System.EventHandler(this.mnuDBSync_Click);
            // 
            // mnuKnowledge
            // 
            this.mnuKnowledge.Name = "mnuKnowledge";
            this.mnuKnowledge.Size = new System.Drawing.Size(152, 22);
            this.mnuKnowledge.Text = "Knowledge";
            this.mnuKnowledge.Click += new System.EventHandler(this.mnuKnowledge_Click);
            // 
            // mnuForex
            // 
            this.mnuForex.Name = "mnuForex";
            this.mnuForex.Size = new System.Drawing.Size(152, 22);
            this.mnuForex.Text = "Forex";
            this.mnuForex.Click += new System.EventHandler(this.mnuForex_Click);
            // 
            // mnuLand
            // 
            this.mnuLand.Name = "mnuLand";
            this.mnuLand.Size = new System.Drawing.Size(152, 22);
            this.mnuLand.Text = "Land";
            this.mnuLand.Click += new System.EventHandler(this.mnuLand_Click);
            // 
            // mnuStock
            // 
            this.mnuStock.Name = "mnuStock";
            this.mnuStock.Size = new System.Drawing.Size(152, 22);
            this.mnuStock.Text = "Stock";
            this.mnuStock.Click += new System.EventHandler(this.mnuStock_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 532);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "Full Knowledge App";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDBSync;
        private System.Windows.Forms.ToolStripMenuItem mnuKnowledge;
        private System.Windows.Forms.ToolStripMenuItem mnuForex;
        private System.Windows.Forms.ToolStripMenuItem mnuLand;
        private System.Windows.Forms.ToolStripMenuItem mnuStock;
    }
}

