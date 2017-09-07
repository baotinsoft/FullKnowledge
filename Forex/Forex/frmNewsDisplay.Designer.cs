namespace Forex
{
    partial class frmNewsDisplay
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
            this.webNews = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuStore = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webNews
            // 
            this.webNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webNews.Location = new System.Drawing.Point(0, 24);
            this.webNews.MinimumSize = new System.Drawing.Size(20, 20);
            this.webNews.Name = "webNews";
            this.webNews.ScriptErrorsSuppressed = true;
            this.webNews.Size = new System.Drawing.Size(851, 378);
            this.webNews.TabIndex = 0;
            this.webNews.Url = new System.Uri("http://cafef.vn", System.UriKind.Absolute);
            this.webNews.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webNews_Navigated);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStore});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(851, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuStore
            // 
            this.mnuStore.Name = "mnuStore";
            this.mnuStore.Size = new System.Drawing.Size(46, 20);
            this.mnuStore.Text = "Store";
            this.mnuStore.Click += new System.EventHandler(this.mnuStore_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(62, 0);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(777, 20);
            this.txtUrl.TabIndex = 2;
            this.txtUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUrl_KeyDown);
            // 
            // frmNewsDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 402);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.webNews);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmNewsDisplay";
            this.Text = "frmNewsDisplay";
            this.Load += new System.EventHandler(this.frmNewsDisplay_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webNews;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuStore;
        private System.Windows.Forms.TextBox txtUrl;
    }
}