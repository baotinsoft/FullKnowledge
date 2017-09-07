namespace StockPredict
{
    partial class frmCreateParam
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
            this.cboGroup = new System.Windows.Forms.ComboBox();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.txtStockPos = new System.Windows.Forms.TextBox();
            this.txtBranchPos = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtVNParam = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMask = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // cboGroup
            // 
            this.cboGroup.FormattingEnabled = true;
            this.cboGroup.Location = new System.Drawing.Point(94, 9);
            this.cboGroup.Name = "cboGroup";
            this.cboGroup.Size = new System.Drawing.Size(540, 21);
            this.cboGroup.TabIndex = 0;
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(737, 14);
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(426, 20);
            this.txtParam.TabIndex = 1;
            // 
            // txtStockPos
            // 
            this.txtStockPos.Location = new System.Drawing.Point(737, 94);
            this.txtStockPos.Name = "txtStockPos";
            this.txtStockPos.Size = new System.Drawing.Size(100, 20);
            this.txtStockPos.TabIndex = 2;
            // 
            // txtBranchPos
            // 
            this.txtBranchPos.Location = new System.Drawing.Point(1063, 87);
            this.txtBranchPos.Name = "txtBranchPos";
            this.txtBranchPos.Size = new System.Drawing.Size(100, 20);
            this.txtBranchPos.TabIndex = 3;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(94, 53);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(540, 101);
            this.txtDesc.TabIndex = 4;
            // 
            // txtVNParam
            // 
            this.txtVNParam.Location = new System.Drawing.Point(738, 55);
            this.txtVNParam.Name = "txtVNParam";
            this.txtVNParam.Size = new System.Drawing.Size(425, 20);
            this.txtVNParam.TabIndex = 5;
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(1, 216);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(1162, 282);
            this.dgvList.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(561, 178);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(656, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(653, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Parameter:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(655, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "VNParameter:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(657, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Format Mask:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(653, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Stock Position:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(971, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Branch Position:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-2, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Parameter Group:";
            // 
            // txtMask
            // 
            this.txtMask.Location = new System.Drawing.Point(738, 139);
            this.txtMask.Name = "txtMask";
            this.txtMask.Size = new System.Drawing.Size(425, 20);
            this.txtMask.TabIndex = 16;
            // 
            // frmCreateParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 502);
            this.Controls.Add(this.txtMask);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.txtVNParam);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtBranchPos);
            this.Controls.Add(this.txtStockPos);
            this.Controls.Add(this.txtParam);
            this.Controls.Add(this.cboGroup);
            this.Name = "frmCreateParam";
            this.Text = "Create Parameters";
            this.Load += new System.EventHandler(this.frmCreateParam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboGroup;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.TextBox txtStockPos;
        private System.Windows.Forms.TextBox txtBranchPos;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtVNParam;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMask;
    }
}