namespace StockPredict
{
    partial class frmModel
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.txtConnectStr = new System.Windows.Forms.TextBox();
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.btnMiningModel = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.odlgHisFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(3, 48);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(96, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "1. Kết nối";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(455, 45);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // txtConnectStr
            // 
            this.txtConnectStr.Location = new System.Drawing.Point(3, 12);
            this.txtConnectStr.Name = "txtConnectStr";
            this.txtConnectStr.Size = new System.Drawing.Size(527, 20);
            this.txtConnectStr.TabIndex = 2;
            this.txtConnectStr.Text = "Provider=SQLNCLI.1;Integrated Security=SSPI;Persist Security Info=False;Initial C" +
                "atalog=StockPredict;Data Source=localhost";
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(114, 48);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(114, 20);
            this.txtStockCode.TabIndex = 3;
            this.txtStockCode.Text = "ABT";
            // 
            // btnMiningModel
            // 
            this.btnMiningModel.Enabled = false;
            this.btnMiningModel.Location = new System.Drawing.Point(244, 45);
            this.btnMiningModel.Name = "btnMiningModel";
            this.btnMiningModel.Size = new System.Drawing.Size(97, 23);
            this.btnMiningModel.TabIndex = 4;
            this.btnMiningModel.Text = "2. Tạo mô hình học cho mã mới";
            this.btnMiningModel.UseVisualStyleBackColor = true;
            this.btnMiningModel.Click += new System.EventHandler(this.btnMiningModel_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(361, 46);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "3. Xử lý";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(3, 88);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProgress.Size = new System.Drawing.Size(527, 153);
            this.txtProgress.TabIndex = 12;
            // 
            // odlgHisFile
            // 
            this.odlgHisFile.FileName = "openFileDialog1";
            // 
            // frmModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 249);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnMiningModel);
            this.Controls.Add(this.txtStockCode);
            this.Controls.Add(this.txtConnectStr);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnConnect);
            this.Name = "frmModel";
            this.Text = "Tao Mo Hinh";
            this.Load += new System.EventHandler(this.frmDM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.TextBox txtConnectStr;
        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.Button btnMiningModel;
        private System.Windows.Forms.Button btnProcess;
        public System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.OpenFileDialog odlgHisFile;
    }
}

