namespace StockPredict
{
    partial class frmViewInfo_Finance
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
            this.dgvBranch = new System.Windows.Forms.DataGridView();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnView = new System.Windows.Forms.Button();
            this.lstStock = new System.Windows.Forms.ListBox();
            this.lstParameter = new System.Windows.Forms.ListBox();
            this.lstBranch = new System.Windows.Forms.ListBox();
            this.btnUpdateStock = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnDefaultSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBranch
            // 
            this.dgvBranch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBranch.Location = new System.Drawing.Point(2, 269);
            this.dgvBranch.Name = "dgvBranch";
            this.dgvBranch.Size = new System.Drawing.Size(1267, 113);
            this.dgvBranch.TabIndex = 3;
            // 
            // dgvStock
            // 
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(2, 388);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.Size = new System.Drawing.Size(1267, 326);
            this.dgvStock.TabIndex = 4;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(1185, 12);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(109, 17);
            this.chkAll.TabIndex = 5;
            this.chkAll.Text = "All(Update Stock)";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(1185, 35);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(84, 23);
            this.btnView.TabIndex = 7;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lstStock
            // 
            this.lstStock.FormattingEnabled = true;
            this.lstStock.Location = new System.Drawing.Point(918, -1);
            this.lstStock.MultiColumn = true;
            this.lstStock.Name = "lstStock";
            this.lstStock.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstStock.Size = new System.Drawing.Size(261, 264);
            this.lstStock.TabIndex = 8;
            // 
            // lstParameter
            // 
            this.lstParameter.FormattingEnabled = true;
            this.lstParameter.Location = new System.Drawing.Point(637, -1);
            this.lstParameter.Name = "lstParameter";
            this.lstParameter.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstParameter.Size = new System.Drawing.Size(275, 264);
            this.lstParameter.TabIndex = 9;
            // 
            // lstBranch
            // 
            this.lstBranch.FormattingEnabled = true;
            this.lstBranch.Location = new System.Drawing.Point(2, -1);
            this.lstBranch.Name = "lstBranch";
            this.lstBranch.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBranch.Size = new System.Drawing.Size(629, 264);
            this.lstBranch.TabIndex = 10;
            // 
            // btnUpdateStock
            // 
            this.btnUpdateStock.Location = new System.Drawing.Point(1185, 75);
            this.btnUpdateStock.Name = "btnUpdateStock";
            this.btnUpdateStock.Size = new System.Drawing.Size(84, 23);
            this.btnUpdateStock.TabIndex = 11;
            this.btnUpdateStock.Text = "Stock";
            this.btnUpdateStock.UseVisualStyleBackColor = true;
            this.btnUpdateStock.Click += new System.EventHandler(this.btnUpdateStock_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(1185, 117);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(84, 23);
            this.btnDefault.TabIndex = 12;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnDefaultSave
            // 
            this.btnDefaultSave.Location = new System.Drawing.Point(1185, 160);
            this.btnDefaultSave.Name = "btnDefaultSave";
            this.btnDefaultSave.Size = new System.Drawing.Size(84, 23);
            this.btnDefaultSave.TabIndex = 13;
            this.btnDefaultSave.Text = "Save Default";
            this.btnDefaultSave.UseVisualStyleBackColor = true;
            this.btnDefaultSave.Click += new System.EventHandler(this.btnDefaultSave_Click);
            // 
            // frmViewInfo_Finance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 726);
            this.Controls.Add(this.btnDefaultSave);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnUpdateStock);
            this.Controls.Add(this.lstBranch);
            this.Controls.Add(this.lstParameter);
            this.Controls.Add(this.lstStock);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.dgvBranch);
            this.Name = "frmViewInfo_Finance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Information about Finance of Branch and Stock";
            this.Load += new System.EventHandler(this.frmViewInfo_Finance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBranch;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ListBox lstStock;
        private System.Windows.Forms.ListBox lstParameter;
        private System.Windows.Forms.ListBox lstBranch;
        private System.Windows.Forms.Button btnUpdateStock;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnDefaultSave;
    }
}