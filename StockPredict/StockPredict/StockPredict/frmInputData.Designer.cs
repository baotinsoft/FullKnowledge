namespace StockPredict
{
    partial class frmInputData
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
            this.odlgDataFile = new System.Windows.Forms.OpenFileDialog();
            this.btnBSC = new System.Windows.Forms.Button();
            this.btnHSX = new System.Windows.Forms.Button();
            this.btnHSC = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnFinanceTVSI = new System.Windows.Forms.Button();
            this.btnHCM = new System.Windows.Forms.Button();
            this.btnHN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnInputTVSI = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLiveHCM = new System.Windows.Forms.Button();
            this.btniStock = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGoolge = new System.Windows.Forms.Button();
            this.btnCafef = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDays = new InputControl.ctrlInputControl();
            this.lblLastDate = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePrice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFinance = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMarket = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPriceHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMonitorStock = new System.Windows.Forms.ToolStripMenuItem();
            this.priceHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPortfofio = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.mnuStockHolder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // odlgDataFile
            // 
            this.odlgDataFile.FileName = "openFileDialog1";
            // 
            // btnBSC
            // 
            this.btnBSC.Enabled = false;
            this.btnBSC.Location = new System.Drawing.Point(500, 151);
            this.btnBSC.Name = "btnBSC";
            this.btnBSC.Size = new System.Drawing.Size(245, 23);
            this.btnBSC.TabIndex = 0;
            this.btnBSC.Text = "Tập tin dat của bsc.com.vn";
            this.btnBSC.UseVisualStyleBackColor = true;
            this.btnBSC.Click += new System.EventHandler(this.btnBSC_Click);
            // 
            // btnHSX
            // 
            this.btnHSX.Location = new System.Drawing.Point(500, 209);
            this.btnHSX.Name = "btnHSX";
            this.btnHSX.Size = new System.Drawing.Size(245, 23);
            this.btnHSX.TabIndex = 1;
            this.btnHSX.Text = "Các tập tin htm của hsx.vn";
            this.btnHSX.UseVisualStyleBackColor = true;
            this.btnHSX.Click += new System.EventHandler(this.btnHSX_Click);
            // 
            // btnHSC
            // 
            this.btnHSC.Location = new System.Drawing.Point(500, 296);
            this.btnHSC.Name = "btnHSC";
            this.btnHSC.Size = new System.Drawing.Size(245, 23);
            this.btnHSC.TabIndex = 2;
            this.btnHSC.Text = "Các tập tin htm của hsc.com.vn";
            this.btnHSC.UseVisualStyleBackColor = true;
            this.btnHSC.Click += new System.EventHandler(this.btnHSC_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(476, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập dữ liệu giá chứng khoán từ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(476, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nhập dữ liệu dư mua và dư bán từ:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(12, 98);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComment.Size = new System.Drawing.Size(455, 337);
            this.txtComment.TabIndex = 5;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(12, 40);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(216, 23);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "Lấy dữ liệu hiện hành";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnFinanceTVSI
            // 
            this.btnFinanceTVSI.Location = new System.Drawing.Point(234, 37);
            this.btnFinanceTVSI.Name = "btnFinanceTVSI";
            this.btnFinanceTVSI.Size = new System.Drawing.Size(216, 23);
            this.btnFinanceTVSI.TabIndex = 7;
            this.btnFinanceTVSI.Text = "Lấy chỉ số tài chính từ tvsi.com.vn";
            this.btnFinanceTVSI.UseVisualStyleBackColor = true;
            this.btnFinanceTVSI.Click += new System.EventHandler(this.btnFinanceTVSI_Click);
            // 
            // btnHCM
            // 
            this.btnHCM.Location = new System.Drawing.Point(500, 69);
            this.btnHCM.Name = "btnHCM";
            this.btnHCM.Size = new System.Drawing.Size(242, 23);
            this.btnHCM.TabIndex = 8;
            this.btnHCM.Text = "Các chứng khoán HCM từ hsx.vn";
            this.btnHCM.UseVisualStyleBackColor = true;
            this.btnHCM.Click += new System.EventHandler(this.btnHCM_Click);
            // 
            // btnHN
            // 
            this.btnHN.Location = new System.Drawing.Point(500, 98);
            this.btnHN.Name = "btnHN";
            this.btnHN.Size = new System.Drawing.Size(242, 23);
            this.btnHN.TabIndex = 9;
            this.btnHN.Text = "Các chứng khoán HN từ hastc.org.vn";
            this.btnHN.UseVisualStyleBackColor = true;
            this.btnHN.Click += new System.EventHandler(this.btnHN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(476, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nhập thông tin chứng khoán";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 331);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nhập dữ liệu tài chính từ:";
            // 
            // btnInputTVSI
            // 
            this.btnInputTVSI.Location = new System.Drawing.Point(500, 347);
            this.btnInputTVSI.Name = "btnInputTVSI";
            this.btnInputTVSI.Size = new System.Drawing.Size(242, 23);
            this.btnInputTVSI.TabIndex = 12;
            this.btnInputTVSI.Text = "Các tập tin htm của tvsi.com.vn";
            this.btnInputTVSI.UseVisualStyleBackColor = true;
            this.btnInputTVSI.Click += new System.EventHandler(this.btnInputTVSI_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nhập dữ liệu giá CK vào Live:";
            // 
            // btnLiveHCM
            // 
            this.btnLiveHCM.Location = new System.Drawing.Point(500, 404);
            this.btnLiveHCM.Name = "btnLiveHCM";
            this.btnLiveHCM.Size = new System.Drawing.Size(245, 23);
            this.btnLiveHCM.TabIndex = 14;
            this.btnLiveHCM.Text = "HCM/HN vào Live";
            this.btnLiveHCM.UseVisualStyleBackColor = true;
            this.btnLiveHCM.Click += new System.EventHandler(this.btnLiveHCM_Click);
            // 
            // btniStock
            // 
            this.btniStock.Location = new System.Drawing.Point(500, 180);
            this.btniStock.Name = "btniStock";
            this.btniStock.Size = new System.Drawing.Size(245, 23);
            this.btniStock.TabIndex = 15;
            this.btniStock.Text = "Tập tin text của iStock";
            this.btniStock.UseVisualStyleBackColor = true;
            this.btniStock.Click += new System.EventHandler(this.btniStock_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(500, 441);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(242, 23);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Xóa sạch dữ liệu giá";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGoolge
            // 
            this.btnGoolge.Location = new System.Drawing.Point(12, 441);
            this.btnGoolge.Name = "btnGoolge";
            this.btnGoolge.Size = new System.Drawing.Size(75, 23);
            this.btnGoolge.TabIndex = 17;
            this.btnGoolge.Text = "Goolge";
            this.btnGoolge.UseVisualStyleBackColor = true;
            this.btnGoolge.Click += new System.EventHandler(this.btnGoolge_Click);
            // 
            // btnCafef
            // 
            this.btnCafef.Location = new System.Drawing.Point(500, 238);
            this.btnCafef.Name = "btnCafef";
            this.btnCafef.Size = new System.Drawing.Size(245, 23);
            this.btnCafef.TabIndex = 18;
            this.btnCafef.Text = "Các tập tin zip của cafef.vn";
            this.btnCafef.UseVisualStyleBackColor = true;
            this.btnCafef.Click += new System.EventHandler(this.btnCafef_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(12, 75);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(58, 17);
            this.chkAll.TabIndex = 19;
            this.chkAll.Text = "Tất Cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Số ngày:";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(128, 69);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(82, 23);
            this.txtDays.TabIndex = 22;
            this.txtDays.PressEnter += new InputControl.ctrlInputControl.delPressEnter(this.txtDays_PressEnter);
            // 
            // lblLastDate
            // 
            this.lblLastDate.AutoSize = true;
            this.lblLastDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLastDate.Location = new System.Drawing.Point(226, 75);
            this.lblLastDate.Name = "lblLastDate";
            this.lblLastDate.Size = new System.Drawing.Size(2, 15);
            this.lblLastDate.TabIndex = 23;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuView,
            this.mnuPriceHistory});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(755, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChangePrice,
            this.mnuFinance,
            this.mnuMarket});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(49, 20);
            this.mnuView.Text = "Views";
            // 
            // mnuChangePrice
            // 
            this.mnuChangePrice.Name = "mnuChangePrice";
            this.mnuChangePrice.Size = new System.Drawing.Size(144, 22);
            this.mnuChangePrice.Text = "Change Price";
            this.mnuChangePrice.Click += new System.EventHandler(this.mnuChangePrice_Click);
            // 
            // mnuFinance
            // 
            this.mnuFinance.Name = "mnuFinance";
            this.mnuFinance.Size = new System.Drawing.Size(144, 22);
            this.mnuFinance.Text = "Finance";
            this.mnuFinance.Click += new System.EventHandler(this.mnuFinance_Click);
            // 
            // mnuMarket
            // 
            this.mnuMarket.Name = "mnuMarket";
            this.mnuMarket.Size = new System.Drawing.Size(144, 22);
            this.mnuMarket.Text = "Market";
            this.mnuMarket.Click += new System.EventHandler(this.mnuMarket_Click);
            // 
            // mnuPriceHistory
            // 
            this.mnuPriceHistory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMonitorStock,
            this.priceHistoryToolStripMenuItem,
            this.mnuPortfofio,
            this.mnuStockHolder});
            this.mnuPriceHistory.Name = "mnuPriceHistory";
            this.mnuPriceHistory.Size = new System.Drawing.Size(62, 20);
            this.mnuPriceHistory.Text = "Monitor";
            // 
            // mnuMonitorStock
            // 
            this.mnuMonitorStock.Name = "mnuMonitorStock";
            this.mnuMonitorStock.Size = new System.Drawing.Size(152, 22);
            this.mnuMonitorStock.Text = "Stock";
            this.mnuMonitorStock.Click += new System.EventHandler(this.mnuMonitorStock_Click);
            // 
            // priceHistoryToolStripMenuItem
            // 
            this.priceHistoryToolStripMenuItem.Name = "priceHistoryToolStripMenuItem";
            this.priceHistoryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.priceHistoryToolStripMenuItem.Text = "Price History";
            this.priceHistoryToolStripMenuItem.Click += new System.EventHandler(this.priceHistoryToolStripMenuItem_Click);
            // 
            // mnuPortfofio
            // 
            this.mnuPortfofio.Name = "mnuPortfofio";
            this.mnuPortfofio.Size = new System.Drawing.Size(152, 22);
            this.mnuPortfofio.Text = "Portfofio";
            this.mnuPortfofio.Click += new System.EventHandler(this.mnuPortfofio_Click);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFromDate.Location = new System.Drawing.Point(392, 75);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(2, 15);
            this.lblFromDate.TabIndex = 25;
            // 
            // mnuStockHolder
            // 
            this.mnuStockHolder.Name = "mnuStockHolder";
            this.mnuStockHolder.Size = new System.Drawing.Size(152, 22);
            this.mnuStockHolder.Text = "Stock Holder";
            this.mnuStockHolder.Click += new System.EventHandler(this.mnuStockHolder_Click);
            // 
            // frmInputData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 475);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.lblLastDate);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnCafef);
            this.Controls.Add(this.btnGoolge);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btniStock);
            this.Controls.Add(this.btnLiveHCM);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnInputTVSI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHN);
            this.Controls.Add(this.btnHCM);
            this.Controls.Add(this.btnFinanceTVSI);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHSC);
            this.Controls.Add(this.btnHSX);
            this.Controls.Add(this.btnBSC);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmInputData";
            this.Text = "Nhap Du Lieu";
            this.Load += new System.EventHandler(this.frmInputData_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog odlgDataFile;
        private System.Windows.Forms.Button btnBSC;
        private System.Windows.Forms.Button btnHSX;
        private System.Windows.Forms.Button btnHSC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnFinanceTVSI;
        private System.Windows.Forms.Button btnHCM;
        private System.Windows.Forms.Button btnHN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnInputTVSI;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLiveHCM;
        private System.Windows.Forms.Button btniStock;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnGoolge;
        private System.Windows.Forms.Button btnCafef;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label6;
        private InputControl.ctrlInputControl txtDays;
        private System.Windows.Forms.Label lblLastDate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePrice;
        private System.Windows.Forms.ToolStripMenuItem mnuFinance;
        private System.Windows.Forms.ToolStripMenuItem mnuMarket;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.ToolStripMenuItem mnuPriceHistory;
        private System.Windows.Forms.ToolStripMenuItem mnuMonitorStock;
        private System.Windows.Forms.ToolStripMenuItem priceHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPortfofio;
        private System.Windows.Forms.ToolStripMenuItem mnuStockHolder;
    }
}