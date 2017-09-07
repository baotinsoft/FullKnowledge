namespace StockKnowledge
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuKnowledge = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTerms = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNews = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDefinition = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPortfolio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewsAffected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEventAffected = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBranchStock = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKnowledge,
            this.mnuAnalysis});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(461, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuKnowledge
            // 
            this.mnuKnowledge.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTerms,
            this.mnuNews,
            this.mnuEvents,
            this.mnuDefinition,
            this.mnuPortfolio,
            this.mnuBranchStock});
            this.mnuKnowledge.Name = "mnuKnowledge";
            this.mnuKnowledge.Size = new System.Drawing.Size(78, 20);
            this.mnuKnowledge.Text = "Knowledge";
            // 
            // mnuTerms
            // 
            this.mnuTerms.Name = "mnuTerms";
            this.mnuTerms.Size = new System.Drawing.Size(152, 22);
            this.mnuTerms.Text = "Terms";
            this.mnuTerms.Click += new System.EventHandler(this.mnuTerms_Click);
            // 
            // mnuNews
            // 
            this.mnuNews.Name = "mnuNews";
            this.mnuNews.Size = new System.Drawing.Size(152, 22);
            this.mnuNews.Text = "News";
            this.mnuNews.Click += new System.EventHandler(this.mnuNews_Click);
            // 
            // mnuEvents
            // 
            this.mnuEvents.Name = "mnuEvents";
            this.mnuEvents.Size = new System.Drawing.Size(152, 22);
            this.mnuEvents.Text = "Events";
            this.mnuEvents.Click += new System.EventHandler(this.mnuEvents_Click);
            // 
            // mnuDefinition
            // 
            this.mnuDefinition.Name = "mnuDefinition";
            this.mnuDefinition.Size = new System.Drawing.Size(152, 22);
            this.mnuDefinition.Text = "Definition";
            this.mnuDefinition.Click += new System.EventHandler(this.mnuDefinition_Click);
            // 
            // mnuPortfolio
            // 
            this.mnuPortfolio.Name = "mnuPortfolio";
            this.mnuPortfolio.Size = new System.Drawing.Size(152, 22);
            this.mnuPortfolio.Text = "Portfolio";
            this.mnuPortfolio.Click += new System.EventHandler(this.mnuPortfolio_Click);
            // 
            // mnuAnalysis
            // 
            this.mnuAnalysis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewsAffected,
            this.mnuEventAffected});
            this.mnuAnalysis.Name = "mnuAnalysis";
            this.mnuAnalysis.Size = new System.Drawing.Size(62, 20);
            this.mnuAnalysis.Text = "Analysis";
            // 
            // mnuNewsAffected
            // 
            this.mnuNewsAffected.Name = "mnuNewsAffected";
            this.mnuNewsAffected.Size = new System.Drawing.Size(151, 22);
            this.mnuNewsAffected.Text = "News Affected";
            // 
            // mnuEventAffected
            // 
            this.mnuEventAffected.Name = "mnuEventAffected";
            this.mnuEventAffected.Size = new System.Drawing.Size(151, 22);
            this.mnuEventAffected.Text = "Event Affected";
            // 
            // mnuBranchStock
            // 
            this.mnuBranchStock.Name = "mnuBranchStock";
            this.mnuBranchStock.Size = new System.Drawing.Size(152, 22);
            this.mnuBranchStock.Text = "Branch Stock";
            this.mnuBranchStock.Click += new System.EventHandler(this.mnuBranchStock_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 273);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Stock Knowledge";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuKnowledge;
        private System.Windows.Forms.ToolStripMenuItem mnuTerms;
        private System.Windows.Forms.ToolStripMenuItem mnuNews;
        private System.Windows.Forms.ToolStripMenuItem mnuEvents;
        private System.Windows.Forms.ToolStripMenuItem mnuAnalysis;
        private System.Windows.Forms.ToolStripMenuItem mnuNewsAffected;
        private System.Windows.Forms.ToolStripMenuItem mnuEventAffected;
        private System.Windows.Forms.ToolStripMenuItem mnuDefinition;
        private System.Windows.Forms.ToolStripMenuItem mnuPortfolio;
        private System.Windows.Forms.ToolStripMenuItem mnuBranchStock;
    }
}

