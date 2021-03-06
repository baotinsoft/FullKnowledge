namespace StockPredict
{
    partial class frmForecast
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
            this.btnForcast = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.cboStock = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkOver = new System.Windows.Forms.CheckBox();
            this.chkServey = new System.Windows.Forms.CheckBox();
            this.chkAnalysis = new System.Windows.Forms.CheckBox();
            this.btnResetMulti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(345, 44);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Thoát";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnForcast
            // 
            this.btnForcast.Location = new System.Drawing.Point(345, 10);
            this.btnForcast.Name = "btnForcast";
            this.btnForcast.Size = new System.Drawing.Size(75, 23);
            this.btnForcast.TabIndex = 6;
            this.btnForcast.Text = "Dự báo >";
            this.btnForcast.UseVisualStyleBackColor = true;
            this.btnForcast.Click += new System.EventHandler(this.btnForcast_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(143, 47);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(67, 20);
            this.txtNumber.TabIndex = 9;
            this.txtNumber.Text = "1";
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(3, 111);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProgress.Size = new System.Drawing.Size(421, 290);
            this.txtProgress.TabIndex = 12;
            // 
            // cboStock
            // 
            this.cboStock.FormattingEnabled = true;
            this.cboStock.Location = new System.Drawing.Point(143, 12);
            this.cboStock.Name = "cboStock";
            this.cboStock.Size = new System.Drawing.Size(114, 21);
            this.cboStock.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Chọn chứng khoán:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Số ngày dự báo tương lai:";
            // 
            // chkOver
            // 
            this.chkOver.AutoSize = true;
            this.chkOver.Location = new System.Drawing.Point(287, 88);
            this.chkOver.Name = "chkOver";
            this.chkOver.Size = new System.Drawing.Size(86, 17);
            this.chkOver.TabIndex = 16;
            this.chkOver.Text = "Dư mua/bán";
            this.chkOver.UseVisualStyleBackColor = true;
            // 
            // chkServey
            // 
            this.chkServey.AutoSize = true;
            this.chkServey.Location = new System.Drawing.Point(143, 88);
            this.chkServey.Name = "chkServey";
            this.chkServey.Size = new System.Drawing.Size(119, 17);
            this.chkServey.TabIndex = 17;
            this.chkServey.Text = "Thông tin từ Servey";
            this.chkServey.UseVisualStyleBackColor = true;
            // 
            // chkAnalysis
            // 
            this.chkAnalysis.AutoSize = true;
            this.chkAnalysis.Location = new System.Drawing.Point(15, 88);
            this.chkAnalysis.Name = "chkAnalysis";
            this.chkAnalysis.Size = new System.Drawing.Size(114, 17);
            this.chkAnalysis.TabIndex = 18;
            this.chkAnalysis.Text = "Phân tích kỹ thuật";
            this.chkAnalysis.UseVisualStyleBackColor = true;
            // 
            // btnResetMulti
            // 
            this.btnResetMulti.Location = new System.Drawing.Point(229, 44);
            this.btnResetMulti.Name = "btnResetMulti";
            this.btnResetMulti.Size = new System.Drawing.Size(101, 23);
            this.btnResetMulti.TabIndex = 19;
            this.btnResetMulti.Text = "Xóa dự báo cũ";
            this.btnResetMulti.UseVisualStyleBackColor = true;
            this.btnResetMulti.Click += new System.EventHandler(this.btnResetMulti_Click);
            // 
            // frmForecast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 406);
            this.Controls.Add(this.btnResetMulti);
            this.Controls.Add(this.chkAnalysis);
            this.Controls.Add(this.chkServey);
            this.Controls.Add(this.chkOver);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboStock);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.btnForcast);
            this.Controls.Add(this.btnQuit);
            this.MaximizeBox = false;
            this.Name = "frmForecast";
            this.Text = "Du Bao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnForcast;
        private System.Windows.Forms.TextBox txtNumber;
        public System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.ComboBox cboStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkOver;
        private System.Windows.Forms.CheckBox chkServey;
        private System.Windows.Forms.CheckBox chkAnalysis;
        private System.Windows.Forms.Button btnResetMulti;
    }
}

