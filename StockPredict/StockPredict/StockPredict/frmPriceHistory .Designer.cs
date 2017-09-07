namespace StockPredict
{
    partial class frmPriceHistory
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
            this.txtDays = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lstStock = new System.Windows.Forms.ListBox();
            this.chkAllStock = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(0, 204);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(1064, 328);
            this.dgvList.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Days:";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(156, 12);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(49, 20);
            this.txtDays.TabIndex = 31;
            this.txtDays.Text = "10";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 30;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lstStock
            // 
            this.lstStock.FormattingEnabled = true;
            this.lstStock.Location = new System.Drawing.Point(0, 38);
            this.lstStock.MultiColumn = true;
            this.lstStock.Name = "lstStock";
            this.lstStock.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstStock.Size = new System.Drawing.Size(1240, 160);
            this.lstStock.TabIndex = 33;
            // 
            // chkAllStock
            // 
            this.chkAllStock.AutoSize = true;
            this.chkAllStock.Location = new System.Drawing.Point(238, 12);
            this.chkAllStock.Name = "chkAllStock";
            this.chkAllStock.Size = new System.Drawing.Size(73, 17);
            this.chkAllStock.TabIndex = 34;
            this.chkAllStock.Text = "All Stocks";
            this.chkAllStock.UseVisualStyleBackColor = true;
            // 
            // frmPriceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 537);
            this.Controls.Add(this.chkAllStock);
            this.Controls.Add(this.lstStock);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvList);
            this.Name = "frmPriceHistory";
            this.Text = "Stock Monitor";
            this.Load += new System.EventHandler(this.frmPriceHistory_Load);
            this.SizeChanged += new System.EventHandler(this.frmPriceHistory_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListBox lstStock;
        private System.Windows.Forms.CheckBox chkAllStock;
    }
}