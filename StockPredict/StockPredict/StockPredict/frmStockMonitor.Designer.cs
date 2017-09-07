namespace StockPredict
{
    partial class frmStockMonitor
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
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chkPriceHistory = new System.Windows.Forms.CheckBox();
            this.chkStockInfo = new System.Windows.Forms.CheckBox();
            this.chkStockHolder = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(0, 38);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(1075, 494);
            this.dgvList.TabIndex = 2;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Id:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(156, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(49, 20);
            this.txtId.TabIndex = 31;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkPriceHistory
            // 
            this.chkPriceHistory.AutoSize = true;
            this.chkPriceHistory.Location = new System.Drawing.Point(239, 15);
            this.chkPriceHistory.Name = "chkPriceHistory";
            this.chkPriceHistory.Size = new System.Drawing.Size(85, 17);
            this.chkPriceHistory.TabIndex = 33;
            this.chkPriceHistory.Text = "Price History";
            this.chkPriceHistory.UseVisualStyleBackColor = true;
            // 
            // chkStockInfo
            // 
            this.chkStockInfo.AutoSize = true;
            this.chkStockInfo.Location = new System.Drawing.Point(343, 14);
            this.chkStockInfo.Name = "chkStockInfo";
            this.chkStockInfo.Size = new System.Drawing.Size(75, 17);
            this.chkStockInfo.TabIndex = 34;
            this.chkStockInfo.Text = "Stock Info";
            this.chkStockInfo.UseVisualStyleBackColor = true;
            // 
            // chkStockHolder
            // 
            this.chkStockHolder.AutoSize = true;
            this.chkStockHolder.Location = new System.Drawing.Point(424, 15);
            this.chkStockHolder.Name = "chkStockHolder";
            this.chkStockHolder.Size = new System.Drawing.Size(88, 17);
            this.chkStockHolder.TabIndex = 38;
            this.chkStockHolder.Text = "Stock Holder";
            this.chkStockHolder.UseVisualStyleBackColor = true;
            // 
            // frmStockMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 537);
            this.Controls.Add(this.chkStockHolder);
            this.Controls.Add(this.chkStockInfo);
            this.Controls.Add(this.chkPriceHistory);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvList);
            this.Name = "frmStockMonitor";
            this.Text = "Stock Monitor";
            this.Load += new System.EventHandler(this.frmStockMonitor_Load);
            this.SizeChanged += new System.EventHandler(this.frmStockMonitor_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chkPriceHistory;
        private System.Windows.Forms.CheckBox chkStockInfo;
        private System.Windows.Forms.CheckBox chkStockHolder;
    }
}