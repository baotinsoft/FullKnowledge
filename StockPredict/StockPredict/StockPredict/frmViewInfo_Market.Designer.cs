namespace StockPredict
{
    partial class frmViewInfo_Market
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
            this.dgvHO = new System.Windows.Forms.DataGridView();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHA = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHA)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHO
            // 
            this.dgvHO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHO.Location = new System.Drawing.Point(12, 36);
            this.dgvHO.Name = "dgvHO";
            this.dgvHO.Size = new System.Drawing.Size(726, 241);
            this.dgvHO.TabIndex = 0;
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(73, 10);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 20);
            this.dtFrom.TabIndex = 1;
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(395, 10);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(200, 20);
            this.dtTo.TabIndex = 2;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(663, 9);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Từ ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đến ngày:";
            // 
            // dgvHA
            // 
            this.dgvHA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHA.Location = new System.Drawing.Point(12, 283);
            this.dgvHA.Name = "dgvHA";
            this.dgvHA.Size = new System.Drawing.Size(726, 241);
            this.dgvHA.TabIndex = 6;
            // 
            // frmViewInfo_Market
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 532);
            this.Controls.Add(this.dgvHA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.dgvHO);
            this.Name = "frmViewInfo_Market";
            this.Text = "frmViewInfo_Market";
            this.Load += new System.EventHandler(this.frmViewInfo_Market_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHO;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHA;
    }
}