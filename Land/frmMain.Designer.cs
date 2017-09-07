namespace Land
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
            this.mnuInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUrls = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCity = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDistrict = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLand = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInformation});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuInformation
            // 
            this.mnuInformation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUrls,
            this.mnuCity,
            this.mnuDistrict,
            this.mnuWard,
            this.mnuLand});
            this.mnuInformation.Name = "mnuInformation";
            this.mnuInformation.Size = new System.Drawing.Size(74, 20);
            this.mnuInformation.Text = "Thông Tin";
            // 
            // mnuUrls
            // 
            this.mnuUrls.Name = "mnuUrls";
            this.mnuUrls.Size = new System.Drawing.Size(132, 22);
            this.mnuUrls.Text = "Urls";
            this.mnuUrls.Click += new System.EventHandler(this.mnuUrls_Click);
            // 
            // mnuCity
            // 
            this.mnuCity.Name = "mnuCity";
            this.mnuCity.Size = new System.Drawing.Size(132, 22);
            this.mnuCity.Text = "Thành Phố";
            // 
            // mnuDistrict
            // 
            this.mnuDistrict.Name = "mnuDistrict";
            this.mnuDistrict.Size = new System.Drawing.Size(132, 22);
            this.mnuDistrict.Text = "Quận";
            // 
            // mnuWard
            // 
            this.mnuWard.Name = "mnuWard";
            this.mnuWard.Size = new System.Drawing.Size(132, 22);
            this.mnuWard.Text = "Phường";
            // 
            // mnuLand
            // 
            this.mnuLand.Name = "mnuLand";
            this.mnuLand.Size = new System.Drawing.Size(132, 22);
            this.mnuLand.Text = "Đất đai";
            this.mnuLand.Click += new System.EventHandler(this.mnuLand_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Land";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuInformation;
        private System.Windows.Forms.ToolStripMenuItem mnuUrls;
        private System.Windows.Forms.ToolStripMenuItem mnuCity;
        private System.Windows.Forms.ToolStripMenuItem mnuLand;
        private System.Windows.Forms.ToolStripMenuItem mnuDistrict;
        private System.Windows.Forms.ToolStripMenuItem mnuWard;
    }
}

