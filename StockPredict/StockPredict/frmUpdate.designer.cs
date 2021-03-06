namespace StockPredict
{
    partial class frmUpdate
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
            this.btnQuit = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.cboStock = new System.Windows.Forms.ComboBox();
            this.btnLoop = new System.Windows.Forms.Button();
            this.cmdInc = new System.Windows.Forms.Button();
            this.odlgHisFile = new System.Windows.Forms.OpenFileDialog();
            this.btnUpdateAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(465, 13);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(123, 13);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(67, 20);
            this.txtNumber.TabIndex = 9;
            this.txtNumber.Text = "10";
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(3, 41);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProgress.Size = new System.Drawing.Size(537, 220);
            this.txtProgress.TabIndex = 12;
            // 
            // cboStock
            // 
            this.cboStock.FormattingEnabled = true;
            this.cboStock.Location = new System.Drawing.Point(3, 12);
            this.cboStock.Name = "cboStock";
            this.cboStock.Size = new System.Drawing.Size(114, 21);
            this.cboStock.TabIndex = 13;
            // 
            // btnLoop
            // 
            this.btnLoop.Enabled = false;
            this.btnLoop.Location = new System.Drawing.Point(196, 13);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(75, 23);
            this.btnLoop.TabIndex = 14;
            this.btnLoop.Text = "Xử lý lặp";
            this.btnLoop.UseVisualStyleBackColor = true;
            this.btnLoop.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmdInc
            // 
            this.cmdInc.Location = new System.Drawing.Point(277, 13);
            this.cmdInc.Name = "cmdInc";
            this.cmdInc.Size = new System.Drawing.Size(75, 23);
            this.cmdInc.TabIndex = 15;
            this.cmdInc.Text = "Cập nhật";
            this.cmdInc.UseVisualStyleBackColor = true;
            this.cmdInc.Click += new System.EventHandler(this.cmdInc_Click);
            // 
            // odlgHisFile
            // 
            this.odlgHisFile.FileName = "openFileDialog1";
            // 
            // btnUpdateAll
            // 
            this.btnUpdateAll.Location = new System.Drawing.Point(358, 13);
            this.btnUpdateAll.Name = "btnUpdateAll";
            this.btnUpdateAll.Size = new System.Drawing.Size(101, 23);
            this.btnUpdateAll.TabIndex = 16;
            this.btnUpdateAll.Text = "Cập nhật tất cả";
            this.btnUpdateAll.UseVisualStyleBackColor = true;
            this.btnUpdateAll.Click += new System.EventHandler(this.btnUpdateAll_Click);
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 273);
            this.Controls.Add(this.btnUpdateAll);
            this.Controls.Add(this.cmdInc);
            this.Controls.Add(this.btnLoop);
            this.Controls.Add(this.cboStock);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.btnQuit);
            this.Name = "frmUpdate";
            this.Text = "Cap Nhat Model";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TextBox txtNumber;
        public System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.ComboBox cboStock;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.Button cmdInc;
        private System.Windows.Forms.OpenFileDialog odlgHisFile;
        private System.Windows.Forms.Button btnUpdateAll;
    }
}

