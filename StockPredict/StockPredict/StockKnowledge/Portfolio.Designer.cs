namespace StockKnowledge
{
    partial class frmPortfolio
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtBuyPrice = new System.Windows.Forms.TextBox();
            this.lblBuyPrice = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStock = new System.Windows.Forms.ComboBox();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.lblRealBuyPrice = new System.Windows.Forms.Label();
            this.txtRealBuyPrice = new System.Windows.Forms.TextBox();
            this.lblRealSalePrice = new System.Windows.Forms.Label();
            this.txtRealSalePrice = new System.Windows.Forms.TextBox();
            this.dtRealBuyDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRealSaleDate = new System.Windows.Forms.Label();
            this.dtRealSaleDate = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.lblStart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(93, 130);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Cập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtBuyPrice
            // 
            this.txtBuyPrice.Location = new System.Drawing.Point(92, 33);
            this.txtBuyPrice.Name = "txtBuyPrice";
            this.txtBuyPrice.Size = new System.Drawing.Size(80, 20);
            this.txtBuyPrice.TabIndex = 1;
            this.txtBuyPrice.Text = "0";
            // 
            // lblBuyPrice
            // 
            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Location = new System.Drawing.Point(4, 40);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(50, 13);
            this.lblBuyPrice.TabIndex = 2;
            this.lblBuyPrice.Text = "Giá Mua:";
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(361, 6);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(637, 350);
            this.dgvList.TabIndex = 4;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cổ phiếu:";
            // 
            // cboStock
            // 
            this.cboStock.FormattingEnabled = true;
            this.cboStock.Location = new System.Drawing.Point(65, 6);
            this.cboStock.Name = "cboStock";
            this.cboStock.Size = new System.Drawing.Size(290, 21);
            this.cboStock.TabIndex = 10;
            this.cboStock.SelectedIndexChanged += new System.EventHandler(this.cboStock_SelectedIndexChanged);
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Location = new System.Drawing.Point(189, 36);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(48, 13);
            this.lblSalePrice.TabIndex = 13;
            this.lblSalePrice.Text = "Giá Bán:";
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(276, 33);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(79, 20);
            this.txtSalePrice.TabIndex = 12;
            this.txtSalePrice.Text = "0";
            // 
            // lblRealBuyPrice
            // 
            this.lblRealBuyPrice.AutoSize = true;
            this.lblRealBuyPrice.Location = new System.Drawing.Point(4, 66);
            this.lblRealBuyPrice.Name = "lblRealBuyPrice";
            this.lblRealBuyPrice.Size = new System.Drawing.Size(78, 13);
            this.lblRealBuyPrice.TabIndex = 15;
            this.lblRealBuyPrice.Text = "Giá Mua Thực:";
            // 
            // txtRealBuyPrice
            // 
            this.txtRealBuyPrice.Location = new System.Drawing.Point(92, 59);
            this.txtRealBuyPrice.Name = "txtRealBuyPrice";
            this.txtRealBuyPrice.Size = new System.Drawing.Size(80, 20);
            this.txtRealBuyPrice.TabIndex = 14;
            this.txtRealBuyPrice.Text = "0";
            // 
            // lblRealSalePrice
            // 
            this.lblRealSalePrice.AutoSize = true;
            this.lblRealSalePrice.Location = new System.Drawing.Point(189, 62);
            this.lblRealSalePrice.Name = "lblRealSalePrice";
            this.lblRealSalePrice.Size = new System.Drawing.Size(76, 13);
            this.lblRealSalePrice.TabIndex = 17;
            this.lblRealSalePrice.Text = "Giá Bán Thực:";
            // 
            // txtRealSalePrice
            // 
            this.txtRealSalePrice.Location = new System.Drawing.Point(276, 59);
            this.txtRealSalePrice.Name = "txtRealSalePrice";
            this.txtRealSalePrice.Size = new System.Drawing.Size(79, 20);
            this.txtRealSalePrice.TabIndex = 16;
            this.txtRealSalePrice.Text = "0";
            // 
            // dtRealBuyDate
            // 
            this.dtRealBuyDate.CustomFormat = "dd/MM/yyyy";
            this.dtRealBuyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRealBuyDate.Location = new System.Drawing.Point(92, 86);
            this.dtRealBuyDate.Name = "dtRealBuyDate";
            this.dtRealBuyDate.Size = new System.Drawing.Size(80, 20);
            this.dtRealBuyDate.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Ngày Mua Thực:";
            // 
            // lblRealSaleDate
            // 
            this.lblRealSaleDate.AutoSize = true;
            this.lblRealSaleDate.Location = new System.Drawing.Point(190, 92);
            this.lblRealSaleDate.Name = "lblRealSaleDate";
            this.lblRealSaleDate.Size = new System.Drawing.Size(85, 13);
            this.lblRealSaleDate.TabIndex = 21;
            this.lblRealSaleDate.Text = "Ngày Bán Thực:";
            // 
            // dtRealSaleDate
            // 
            this.dtRealSaleDate.CustomFormat = "dd/MM/yyyy";
            this.dtRealSaleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRealSaleDate.Location = new System.Drawing.Point(276, 86);
            this.dtRealSaleDate.Name = "dtRealSaleDate";
            this.dtRealSaleDate.Size = new System.Drawing.Size(79, 20);
            this.dtRealSaleDate.TabIndex = 20;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(175, 130);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 130);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "Khởi Tạo";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtStart
            // 
            this.dtStart.CustomFormat = "dd/MM/yyyy";
            this.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtStart.Location = new System.Drawing.Point(93, 174);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(80, 20);
            this.dtStart.TabIndex = 24;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(178, 171);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(97, 23);
            this.btnView.TabIndex = 25;
            this.btnView.Text = "Xem So Sánh";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(4, 176);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(77, 13);
            this.lblStart.TabIndex = 26;
            this.lblStart.Text = "Ngày Bắt Đầu:";
            // 
            // frmPortfolio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 358);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblRealSaleDate);
            this.Controls.Add(this.dtRealSaleDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtRealBuyDate);
            this.Controls.Add(this.lblRealSalePrice);
            this.Controls.Add(this.txtRealSalePrice);
            this.Controls.Add(this.lblRealBuyPrice);
            this.Controls.Add(this.txtRealBuyPrice);
            this.Controls.Add(this.lblSalePrice);
            this.Controls.Add(this.txtSalePrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboStock);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.lblBuyPrice);
            this.Controls.Add(this.txtBuyPrice);
            this.Controls.Add(this.btnUpdate);
            this.Name = "frmPortfolio";
            this.Text = "frmPortfolio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPortfolio_Load);
            this.SizeChanged += new System.EventHandler(this.frmPortfolio_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtBuyPrice;
        private System.Windows.Forms.Label lblBuyPrice;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStock;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.Label lblRealBuyPrice;
        private System.Windows.Forms.TextBox txtRealBuyPrice;
        private System.Windows.Forms.Label lblRealSalePrice;
        private System.Windows.Forms.TextBox txtRealSalePrice;
        private System.Windows.Forms.DateTimePicker dtRealBuyDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRealSaleDate;
        private System.Windows.Forms.DateTimePicker dtRealSaleDate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblStart;
    }
}