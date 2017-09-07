namespace Knowledge
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
            this.mnuList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEbook = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEbookRead = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEbookSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKnowledge = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKnowledgeRead = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKnowledgeSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccountList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAccountKnowledge = new System.Windows.Forms.ToolStripMenuItem();
            this.thuaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTermRead = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTermSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileMove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRules = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRulesRead = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRulesSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuList,
            this.mnuEbook,
            this.mnuKnowledge,
            this.tàiKhoảnToolStripMenuItem,
            this.thuaToolStripMenuItem,
            this.mnuTools,
            this.mnuRules});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(617, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuList
            // 
            this.mnuList.Name = "mnuList";
            this.mnuList.Size = new System.Drawing.Size(74, 20);
            this.mnuList.Text = "Danh Mục";
            this.mnuList.Click += new System.EventHandler(this.mnuList_Click);
            // 
            // mnuEbook
            // 
            this.mnuEbook.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEbookRead,
            this.mnuEbookSave});
            this.mnuEbook.Name = "mnuEbook";
            this.mnuEbook.Size = new System.Drawing.Size(44, 20);
            this.mnuEbook.Text = "Sách";
            // 
            // mnuEbookRead
            // 
            this.mnuEbookRead.Name = "mnuEbookRead";
            this.mnuEbookRead.Size = new System.Drawing.Size(95, 22);
            this.mnuEbookRead.Text = "Đọc";
            this.mnuEbookRead.Click += new System.EventHandler(this.mnuEbookRead_Click);
            // 
            // mnuEbookSave
            // 
            this.mnuEbookSave.Name = "mnuEbookSave";
            this.mnuEbookSave.Size = new System.Drawing.Size(95, 22);
            this.mnuEbookSave.Text = "Lưu";
            this.mnuEbookSave.Click += new System.EventHandler(this.mnuEbookSave_Click);
            // 
            // mnuKnowledge
            // 
            this.mnuKnowledge.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuKnowledgeRead,
            this.mnuKnowledgeSave});
            this.mnuKnowledge.Name = "mnuKnowledge";
            this.mnuKnowledge.Size = new System.Drawing.Size(72, 20);
            this.mnuKnowledge.Text = "Kiến Thức";
            // 
            // mnuKnowledgeRead
            // 
            this.mnuKnowledgeRead.Name = "mnuKnowledgeRead";
            this.mnuKnowledgeRead.Size = new System.Drawing.Size(152, 22);
            this.mnuKnowledgeRead.Text = "Đọc";
            this.mnuKnowledgeRead.Click += new System.EventHandler(this.mnuKnowledgeRead_Click);
            // 
            // mnuKnowledgeSave
            // 
            this.mnuKnowledgeSave.Name = "mnuKnowledgeSave";
            this.mnuKnowledgeSave.Size = new System.Drawing.Size(152, 22);
            this.mnuKnowledgeSave.Text = "Lưu";
            this.mnuKnowledgeSave.Click += new System.EventHandler(this.mnuKnowledgeSave_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAccountList,
            this.mnuAccountKnowledge});
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài Khoản";
            // 
            // mnuAccountList
            // 
            this.mnuAccountList.Name = "mnuAccountList";
            this.mnuAccountList.Size = new System.Drawing.Size(173, 22);
            this.mnuAccountList.Text = "Danh Sách";
            // 
            // mnuAccountKnowledge
            // 
            this.mnuAccountKnowledge.Name = "mnuAccountKnowledge";
            this.mnuAccountKnowledge.Size = new System.Drawing.Size(173, 22);
            this.mnuAccountKnowledge.Text = "Quản Lý Kiến Thức";
            // 
            // thuaToolStripMenuItem
            // 
            this.thuaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTermRead,
            this.mnuTermSave});
            this.thuaToolStripMenuItem.Name = "thuaToolStripMenuItem";
            this.thuaToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.thuaToolStripMenuItem.Text = "Thuật Ngữ";
            // 
            // mnuTermRead
            // 
            this.mnuTermRead.Name = "mnuTermRead";
            this.mnuTermRead.Size = new System.Drawing.Size(95, 22);
            this.mnuTermRead.Text = "Đọc";
            this.mnuTermRead.Click += new System.EventHandler(this.mnuTermRead_Click);
            // 
            // mnuTermSave
            // 
            this.mnuTermSave.Name = "mnuTermSave";
            this.mnuTermSave.Size = new System.Drawing.Size(95, 22);
            this.mnuTermSave.Text = "Lưu";
            this.mnuTermSave.Click += new System.EventHandler(this.mnuTermSave_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuFileMove});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(66, 20);
            this.mnuTools.Text = "Công Cụ";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(191, 22);
            this.mnuSettings.Text = "Cấu Hình";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuFileMove
            // 
            this.mnuFileMove.Name = "mnuFileMove";
            this.mnuFileMove.Size = new System.Drawing.Size(191, 22);
            this.mnuFileMove.Text = "Chuyển File Theo Loại";
            this.mnuFileMove.Click += new System.EventHandler(this.mnuFileMove_Click);
            // 
            // mnuRules
            // 
            this.mnuRules.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRulesRead,
            this.mnuRulesSave});
            this.mnuRules.Name = "mnuRules";
            this.mnuRules.Size = new System.Drawing.Size(47, 20);
            this.mnuRules.Text = "Rules";
            // 
            // mnuRulesRead
            // 
            this.mnuRulesRead.Name = "mnuRulesRead";
            this.mnuRulesRead.Size = new System.Drawing.Size(152, 22);
            this.mnuRulesRead.Text = "Đọc";
            this.mnuRulesRead.Click += new System.EventHandler(this.mnuRulesRead_Click);
            // 
            // mnuRulesSave
            // 
            this.mnuRulesSave.Name = "mnuRulesSave";
            this.mnuRulesSave.Size = new System.Drawing.Size(152, 22);
            this.mnuRulesSave.Text = "Lưu";
            this.mnuRulesSave.Click += new System.EventHandler(this.mnuRulesSave_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 319);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuList;
        private System.Windows.Forms.ToolStripMenuItem mnuEbook;
        private System.Windows.Forms.ToolStripMenuItem mnuKnowledge;
        private System.Windows.Forms.ToolStripMenuItem mnuEbookRead;
        private System.Windows.Forms.ToolStripMenuItem mnuEbookSave;
        private System.Windows.Forms.ToolStripMenuItem mnuKnowledgeRead;
        private System.Windows.Forms.ToolStripMenuItem mnuKnowledgeSave;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAccountList;
        private System.Windows.Forms.ToolStripMenuItem mnuAccountKnowledge;
        private System.Windows.Forms.ToolStripMenuItem thuaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTermRead;
        private System.Windows.Forms.ToolStripMenuItem mnuTermSave;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuFileMove;
        private System.Windows.Forms.ToolStripMenuItem mnuRules;
        private System.Windows.Forms.ToolStripMenuItem mnuRulesRead;
        private System.Windows.Forms.ToolStripMenuItem mnuRulesSave;
    }
}