namespace StockPredict
{
    partial class frmExport2CSV
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
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.fdlgBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.cboStockCode = new System.Windows.Forms.ComboBox();
            this.btnExportBoth = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.odlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(151, 12);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.Size = new System.Drawing.Size(119, 20);
            this.txtStockCode.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(289, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(79, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Xuất tới ...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cboStockCode
            // 
            this.cboStockCode.FormattingEnabled = true;
            this.cboStockCode.Location = new System.Drawing.Point(151, 53);
            this.cboStockCode.Name = "cboStockCode";
            this.cboStockCode.Size = new System.Drawing.Size(121, 21);
            this.cboStockCode.TabIndex = 2;
            // 
            // btnExportBoth
            // 
            this.btnExportBoth.Location = new System.Drawing.Point(289, 51);
            this.btnExportBoth.Name = "btnExportBoth";
            this.btnExportBoth.Size = new System.Drawing.Size(178, 23);
            this.btnExportBoth.TabIndex = 3;
            this.btnExportBoth.Text = "Xuất cả hai...";
            this.btnExportBoth.UseVisualStyleBackColor = true;
            this.btnExportBoth.Click += new System.EventHandler(this.btnExportBoth_Click);
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(374, 9);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(93, 23);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Nhập dữ liệu";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mã chứng khoán:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chọn mã chứng khoán:";
            // 
            // frmExport2CSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 89);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnExportBoth);
            this.Controls.Add(this.cboStockCode);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtStockCode);
            this.MaximizeBox = false;
            this.Name = "frmExport2CSV";
            this.Text = "Xuat Du Lieu Ra CSV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.FolderBrowserDialog fdlgBrowse;
        private System.Windows.Forms.ComboBox cboStockCode;
        private System.Windows.Forms.Button btnExportBoth;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog odlgOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}