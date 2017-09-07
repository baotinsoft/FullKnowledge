namespace StockPredict
{
    partial class frmViewInfo_ChangePrice
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
            this.cboStockFrom = new System.Windows.Forms.ComboBox();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.txtSub = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStockTo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvPriceASC = new System.Windows.Forms.DataGridView();
            this.btnView = new System.Windows.Forms.Button();
            this.chkAllStock = new System.Windows.Forms.CheckBox();
            this.dgvPriceDESC = new System.Windows.Forms.DataGridView();
            this.dgvCheckedPriceASC = new System.Windows.Forms.DataGridView();
            this.dgvCheckedPriceDESC = new System.Windows.Forms.DataGridView();
            this.lstStock = new System.Windows.Forms.ListBox();
            this.btnView2 = new System.Windows.Forms.Button();
            this.btnViewBoth = new System.Windows.Forms.Button();
            this.txtChangePricePercent = new System.Windows.Forms.TextBox();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAllMarket = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnAddMonitor = new System.Windows.Forms.Button();
            this.txtAsc = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkPriceHistory = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMinPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboFiveBasicElement = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceASC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceDESC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckedPriceASC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckedPriceDESC)).BeginInit();
            this.SuspendLayout();
            // 
            // cboStockFrom
            // 
            this.cboStockFrom.FormattingEnabled = true;
            this.cboStockFrom.Location = new System.Drawing.Point(162, 6);
            this.cboStockFrom.Name = "cboStockFrom";
            this.cboStockFrom.Size = new System.Drawing.Size(118, 21);
            this.cboStockFrom.TabIndex = 0;
            this.cboStockFrom.SelectedIndexChanged += new System.EventHandler(this.cboStockFrom_SelectedIndexChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(555, 5);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 20);
            this.dtFrom.TabIndex = 1;
            // 
            // txtSub
            // 
            this.txtSub.Location = new System.Drawing.Point(782, 5);
            this.txtSub.Name = "txtSub";
            this.txtSub.Size = new System.Drawing.Size(38, 20);
            this.txtSub.TabIndex = 2;
            this.txtSub.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Stock From:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Stock To:";
            // 
            // cboStockTo
            // 
            this.cboStockTo.FormattingEnabled = true;
            this.cboStockTo.Location = new System.Drawing.Point(365, 6);
            this.cboStockTo.Name = "cboStockTo";
            this.cboStockTo.Size = new System.Drawing.Size(118, 21);
            this.cboStockTo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date From:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(761, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "-";
            // 
            // dgvPriceASC
            // 
            this.dgvPriceASC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceASC.Location = new System.Drawing.Point(5, 55);
            this.dgvPriceASC.Name = "dgvPriceASC";
            this.dgvPriceASC.Size = new System.Drawing.Size(617, 226);
            this.dgvPriceASC.TabIndex = 8;
            this.dgvPriceASC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPriceASC_CellClick);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(894, 3);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 9;
            this.btnView.Text = "View 1";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // chkAllStock
            // 
            this.chkAllStock.AutoSize = true;
            this.chkAllStock.Location = new System.Drawing.Point(5, 9);
            this.chkAllStock.Name = "chkAllStock";
            this.chkAllStock.Size = new System.Drawing.Size(73, 17);
            this.chkAllStock.TabIndex = 10;
            this.chkAllStock.Text = "All Stocks";
            this.chkAllStock.UseVisualStyleBackColor = true;
            this.chkAllStock.CheckedChanged += new System.EventHandler(this.chkAllStock_CheckedChanged);
            // 
            // dgvPriceDESC
            // 
            this.dgvPriceDESC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceDESC.Location = new System.Drawing.Point(628, 55);
            this.dgvPriceDESC.Name = "dgvPriceDESC";
            this.dgvPriceDESC.Size = new System.Drawing.Size(617, 226);
            this.dgvPriceDESC.TabIndex = 14;
            this.dgvPriceDESC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPriceDESC_CellClick);
            // 
            // dgvCheckedPriceASC
            // 
            this.dgvCheckedPriceASC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckedPriceASC.Location = new System.Drawing.Point(5, 453);
            this.dgvCheckedPriceASC.Name = "dgvCheckedPriceASC";
            this.dgvCheckedPriceASC.Size = new System.Drawing.Size(617, 237);
            this.dgvCheckedPriceASC.TabIndex = 15;
            // 
            // dgvCheckedPriceDESC
            // 
            this.dgvCheckedPriceDESC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCheckedPriceDESC.Location = new System.Drawing.Point(628, 453);
            this.dgvCheckedPriceDESC.Name = "dgvCheckedPriceDESC";
            this.dgvCheckedPriceDESC.Size = new System.Drawing.Size(617, 237);
            this.dgvCheckedPriceDESC.TabIndex = 16;
            // 
            // lstStock
            // 
            this.lstStock.FormattingEnabled = true;
            this.lstStock.Location = new System.Drawing.Point(5, 287);
            this.lstStock.MultiColumn = true;
            this.lstStock.Name = "lstStock";
            this.lstStock.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstStock.Size = new System.Drawing.Size(1240, 160);
            this.lstStock.TabIndex = 17;
            // 
            // btnView2
            // 
            this.btnView2.Location = new System.Drawing.Point(975, 3);
            this.btnView2.Name = "btnView2";
            this.btnView2.Size = new System.Drawing.Size(75, 23);
            this.btnView2.TabIndex = 18;
            this.btnView2.Text = "View 2";
            this.btnView2.UseVisualStyleBackColor = true;
            this.btnView2.Click += new System.EventHandler(this.btnView2_Click);
            // 
            // btnViewBoth
            // 
            this.btnViewBoth.Location = new System.Drawing.Point(1056, 3);
            this.btnViewBoth.Name = "btnViewBoth";
            this.btnViewBoth.Size = new System.Drawing.Size(75, 23);
            this.btnViewBoth.TabIndex = 19;
            this.btnViewBoth.Text = "View Both";
            this.btnViewBoth.UseVisualStyleBackColor = true;
            this.btnViewBoth.Click += new System.EventHandler(this.btnViewBoth_Click);
            // 
            // txtChangePricePercent
            // 
            this.txtChangePricePercent.Location = new System.Drawing.Point(839, 5);
            this.txtChangePricePercent.Name = "txtChangePricePercent";
            this.txtChangePricePercent.Size = new System.Drawing.Size(49, 20);
            this.txtChangePricePercent.TabIndex = 20;
            this.txtChangePricePercent.Text = "0";
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(1172, 5);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(49, 20);
            this.txtTop.TabIndex = 21;
            this.txtTop.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1137, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Top:";
            // 
            // chkAllMarket
            // 
            this.chkAllMarket.AutoSize = true;
            this.chkAllMarket.Location = new System.Drawing.Point(5, 32);
            this.chkAllMarket.Name = "chkAllMarket";
            this.chkAllMarket.Size = new System.Drawing.Size(73, 17);
            this.chkAllMarket.TabIndex = 23;
            this.chkAllMarket.Text = "All Market";
            this.chkAllMarket.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Avg Quantity >=";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(184, 33);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(49, 20);
            this.txtQuantity.TabIndex = 24;
            this.txtQuantity.Text = "100000";
            // 
            // btnAddMonitor
            // 
            this.btnAddMonitor.Location = new System.Drawing.Point(256, 30);
            this.btnAddMonitor.Name = "btnAddMonitor";
            this.btnAddMonitor.Size = new System.Drawing.Size(75, 23);
            this.btnAddMonitor.TabIndex = 26;
            this.btnAddMonitor.Text = "Add Monitor";
            this.btnAddMonitor.UseVisualStyleBackColor = true;
            this.btnAddMonitor.Click += new System.EventHandler(this.btnAddMonitor_Click);
            // 
            // txtAsc
            // 
            this.txtAsc.Location = new System.Drawing.Point(400, 33);
            this.txtAsc.Name = "txtAsc";
            this.txtAsc.Size = new System.Drawing.Size(49, 20);
            this.txtAsc.TabIndex = 27;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(523, 33);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(49, 20);
            this.txtDesc.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(362, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Asc:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(488, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Desc:";
            // 
            // chkPriceHistory
            // 
            this.chkPriceHistory.AutoSize = true;
            this.chkPriceHistory.Location = new System.Drawing.Point(612, 36);
            this.chkPriceHistory.Name = "chkPriceHistory";
            this.chkPriceHistory.Size = new System.Drawing.Size(85, 17);
            this.chkPriceHistory.TabIndex = 37;
            this.chkPriceHistory.Text = "Price History";
            this.chkPriceHistory.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(711, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Min Price >=";
            // 
            // txtMinPrice
            // 
            this.txtMinPrice.Location = new System.Drawing.Point(800, 32);
            this.txtMinPrice.Name = "txtMinPrice";
            this.txtMinPrice.Size = new System.Drawing.Size(49, 20);
            this.txtMinPrice.TabIndex = 38;
            this.txtMinPrice.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(865, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Five Basic Element:";
            // 
            // cboFiveBasicElement
            // 
            this.cboFiveBasicElement.FormattingEnabled = true;
            this.cboFiveBasicElement.Location = new System.Drawing.Point(971, 28);
            this.cboFiveBasicElement.Name = "cboFiveBasicElement";
            this.cboFiveBasicElement.Size = new System.Drawing.Size(92, 21);
            this.cboFiveBasicElement.TabIndex = 40;
            // 
            // frmViewInfo_ChangePrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 733);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboFiveBasicElement);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMinPrice);
            this.Controls.Add(this.chkPriceHistory);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtAsc);
            this.Controls.Add(this.btnAddMonitor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.chkAllMarket);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTop);
            this.Controls.Add(this.txtChangePricePercent);
            this.Controls.Add(this.btnViewBoth);
            this.Controls.Add(this.btnView2);
            this.Controls.Add(this.lstStock);
            this.Controls.Add(this.dgvCheckedPriceDESC);
            this.Controls.Add(this.dgvCheckedPriceASC);
            this.Controls.Add(this.dgvPriceDESC);
            this.Controls.Add(this.chkAllStock);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dgvPriceASC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboStockTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSub);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.cboStockFrom);
            this.Name = "frmViewInfo_ChangePrice";
            this.Text = "View changed percent price";
            this.Load += new System.EventHandler(this.frmViewInfo_ChangePrice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceASC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceDESC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckedPriceASC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCheckedPriceDESC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboStockFrom;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.TextBox txtSub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStockTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvPriceASC;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.CheckBox chkAllStock;
        private System.Windows.Forms.DataGridView dgvPriceDESC;
        private System.Windows.Forms.DataGridView dgvCheckedPriceASC;
        private System.Windows.Forms.DataGridView dgvCheckedPriceDESC;
        private System.Windows.Forms.ListBox lstStock;
        private System.Windows.Forms.Button btnView2;
        private System.Windows.Forms.Button btnViewBoth;
        private System.Windows.Forms.TextBox txtChangePricePercent;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAllMarket;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnAddMonitor;
        private System.Windows.Forms.TextBox txtAsc;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkPriceHistory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMinPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboFiveBasicElement;
    }
}