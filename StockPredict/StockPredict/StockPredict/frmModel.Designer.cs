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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnData = new System.Windows.Forms.Button();
            this.chkAllData = new System.Windows.Forms.CheckBox();
            this.odlgStock = new System.Windows.Forms.OpenFileDialog();
            this.btnUpdateTrain = new System.Windows.Forms.Button();
            this.btnCompress = new System.Windows.Forms.Button();
            this.chkMulti = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(739, 10);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(94, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "1. Kết nối";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(839, 10);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(67, 84);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Thoát";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // txtConnectStr
            // 
            this.txtConnectStr.Location = new System.Drawing.Point(3, 12);
            this.txtConnectStr.Name = "txtConnectStr";
            this.txtConnectStr.Size = new System.Drawing.Size(712, 20);
            this.txtConnectStr.TabIndex = 2;
            this.txtConnectStr.Text = "Provider=SQLNCLI.1;Integrated Security=SSPI;Persist Security Info=False;Initial C" +
                "atalog=StockPredict;Data Source=localhost";
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(103, 48);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(84, 20);
            this.txtStockCode.TabIndex = 3;
            this.txtStockCode.Text = "PMS";
            // 
            // btnMiningModel
            // 
            this.btnMiningModel.Enabled = false;
            this.btnMiningModel.Location = new System.Drawing.Point(739, 41);
            this.btnMiningModel.Name = "btnMiningModel";
            this.btnMiningModel.Size = new System.Drawing.Size(94, 23);
            this.btnMiningModel.TabIndex = 4;
            this.btnMiningModel.Text = "2. Tạo mô hình";
            this.btnMiningModel.UseVisualStyleBackColor = true;
            this.btnMiningModel.Click += new System.EventHandler(this.btnMiningModel_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Enabled = false;
            this.btnProcess.Location = new System.Drawing.Point(739, 71);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(93, 23);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "3. Xử lý";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(3, 100);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProgress.Size = new System.Drawing.Size(907, 188);
            this.txtProgress.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mã chứng khoán:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(271, 73);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(185, 20);
            this.dtpFrom.TabIndex = 14;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(528, 72);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(187, 20);
            this.dtpTo.TabIndex = 15;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(127, 75);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(83, 17);
            this.chkAll.TabIndex = 16;
            this.chkAll.Text = "Tất cả ngày";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Đến ngày:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Từ ngày:";
            // 
            // btnData
            // 
            this.btnData.Location = new System.Drawing.Point(312, 46);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(87, 23);
            this.btnData.TabIndex = 19;
            this.btnData.Text = "Tạo dữ liệu";
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Visible = false;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // chkAllData
            // 
            this.chkAllData.AutoSize = true;
            this.chkAllData.Location = new System.Drawing.Point(201, 49);
            this.chkAllData.Name = "chkAllData";
            this.chkAllData.Size = new System.Drawing.Size(74, 17);
            this.chkAllData.TabIndex = 20;
            this.chkAllData.Text = "Tất cả mã";
            this.chkAllData.UseVisualStyleBackColor = true;
            // 
            // odlgStock
            // 
            this.odlgStock.FileName = "openFileDialog1";
            // 
            // btnUpdateTrain
            // 
            this.btnUpdateTrain.Enabled = false;
            this.btnUpdateTrain.Location = new System.Drawing.Point(555, 44);
            this.btnUpdateTrain.Name = "btnUpdateTrain";
            this.btnUpdateTrain.Size = new System.Drawing.Size(160, 22);
            this.btnUpdateTrain.TabIndex = 21;
            this.btnUpdateTrain.Text = "Cập nhật dữ liệu huấn luyện";
            this.btnUpdateTrain.UseVisualStyleBackColor = true;
            this.btnUpdateTrain.Visible = false;
            this.btnUpdateTrain.Click += new System.EventHandler(this.btnUpdateTrain_Click);
            // 
            // btnCompress
            // 
            this.btnCompress.Location = new System.Drawing.Point(438, 46);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(84, 22);
            this.btnCompress.TabIndex = 22;
            this.btnCompress.Text = "Nén dữ liệu";
            this.btnCompress.UseVisualStyleBackColor = true;
            this.btnCompress.Visible = false;
            this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
            // 
            // chkMulti
            // 
            this.chkMulti.AutoSize = true;
            this.chkMulti.Location = new System.Drawing.Point(9, 74);
            this.chkMulti.Name = "chkMulti";
            this.chkMulti.Size = new System.Drawing.Size(116, 17);
            this.chkMulti.TabIndex = 23;
            this.chkMulti.Text = "Dự báo nhiều ngày";
            this.chkMulti.UseVisualStyleBackColor = true;
            // 
            // frmModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 290);
            this.Controls.Add(this.chkMulti);
            this.Controls.Add(this.btnCompress);
            this.Controls.Add(this.btnUpdateTrain);
            this.Controls.Add(this.chkAllData);
            this.Controls.Add(this.btnData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnMiningModel);
            this.Controls.Add(this.txtStockCode);
            this.Controls.Add(this.txtConnectStr);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnConnect);
            this.MaximizeBox = false;
            this.Name = "frmModel";
            this.Text = "Tao Mo Hinh";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.CheckBox chkAllData;
        private System.Windows.Forms.OpenFileDialog odlgStock;
        private System.Windows.Forms.Button btnUpdateTrain;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.CheckBox chkMulti;
    }
}

