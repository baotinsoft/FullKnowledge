namespace StockPredict
{
    partial class frmViewInfo_PerVolume
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
            this.dgvAsc = new System.Windows.Forms.DataGridView();
            this.dgvDesc = new System.Windows.Forms.DataGridView();
            this.cboTop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.cboGroupFrom = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboBranchTo = new System.Windows.Forms.ComboBox();
            this.cboBranchFrom = new System.Windows.Forms.ComboBox();
            this.cboGroupTo = new System.Windows.Forms.ComboBox();
            this.cboMarket = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkMarket = new System.Windows.Forms.CheckBox();
            this.chkGroup = new System.Windows.Forms.CheckBox();
            this.chkBranch = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAsc
            // 
            this.dgvAsc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsc.Location = new System.Drawing.Point(2, 353);
            this.dgvAsc.Name = "dgvAsc";
            this.dgvAsc.Size = new System.Drawing.Size(1054, 268);
            this.dgvAsc.TabIndex = 0;
            // 
            // dgvDesc
            // 
            this.dgvDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDesc.Location = new System.Drawing.Point(2, 98);
            this.dgvDesc.Name = "dgvDesc";
            this.dgvDesc.Size = new System.Drawing.Size(1054, 240);
            this.dgvDesc.TabIndex = 1;
            // 
            // cboTop
            // 
            this.cboTop.FormattingEnabled = true;
            this.cboTop.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
            this.cboTop.Location = new System.Drawing.Point(34, 13);
            this.cboTop.Name = "cboTop";
            this.cboTop.Size = new System.Drawing.Size(121, 21);
            this.cboTop.TabIndex = 2;
            this.cboTop.Text = "10";
            this.cboTop.SelectedIndexChanged += new System.EventHandler(this.cboTop_SelectedIndexChanged);
            this.cboTop.Enter += new System.EventHandler(this.cboTop_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Top:";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(172, 16);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 4;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // cboGroupFrom
            // 
            this.cboGroupFrom.Enabled = false;
            this.cboGroupFrom.FormattingEnabled = true;
            this.cboGroupFrom.Location = new System.Drawing.Point(182, 44);
            this.cboGroupFrom.Name = "cboGroupFrom";
            this.cboGroupFrom.Size = new System.Drawing.Size(463, 21);
            this.cboGroupFrom.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Branch Group:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Branch:";
            // 
            // cboBranchTo
            // 
            this.cboBranchTo.Enabled = false;
            this.cboBranchTo.FormattingEnabled = true;
            this.cboBranchTo.Location = new System.Drawing.Point(669, 78);
            this.cboBranchTo.Name = "cboBranchTo";
            this.cboBranchTo.Size = new System.Drawing.Size(463, 21);
            this.cboBranchTo.TabIndex = 12;
            // 
            // cboBranchFrom
            // 
            this.cboBranchFrom.Enabled = false;
            this.cboBranchFrom.FormattingEnabled = true;
            this.cboBranchFrom.Location = new System.Drawing.Point(182, 78);
            this.cboBranchFrom.Name = "cboBranchFrom";
            this.cboBranchFrom.Size = new System.Drawing.Size(463, 21);
            this.cboBranchFrom.TabIndex = 13;
            // 
            // cboGroupTo
            // 
            this.cboGroupTo.Enabled = false;
            this.cboGroupTo.FormattingEnabled = true;
            this.cboGroupTo.Location = new System.Drawing.Point(669, 44);
            this.cboGroupTo.Name = "cboGroupTo";
            this.cboGroupTo.Size = new System.Drawing.Size(463, 21);
            this.cboGroupTo.TabIndex = 14;
            this.cboGroupTo.SelectedIndexChanged += new System.EventHandler(this.cboGroupTo_SelectedIndexChanged);
            // 
            // cboMarket
            // 
            this.cboMarket.Enabled = false;
            this.cboMarket.FormattingEnabled = true;
            this.cboMarket.Location = new System.Drawing.Point(379, 15);
            this.cboMarket.Name = "cboMarket";
            this.cboMarket.Size = new System.Drawing.Size(171, 21);
            this.cboMarket.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Market:";
            // 
            // chkMarket
            // 
            this.chkMarket.AutoSize = true;
            this.chkMarket.Location = new System.Drawing.Point(244, 17);
            this.chkMarket.Name = "chkMarket";
            this.chkMarket.Size = new System.Drawing.Size(59, 17);
            this.chkMarket.TabIndex = 17;
            this.chkMarket.Text = "Market";
            this.chkMarket.UseVisualStyleBackColor = true;
            this.chkMarket.CheckedChanged += new System.EventHandler(this.chkMarket_CheckedChanged);
            // 
            // chkGroup
            // 
            this.chkGroup.AutoSize = true;
            this.chkGroup.Location = new System.Drawing.Point(2, 46);
            this.chkGroup.Name = "chkGroup";
            this.chkGroup.Size = new System.Drawing.Size(92, 17);
            this.chkGroup.TabIndex = 18;
            this.chkGroup.Text = "Branch Group";
            this.chkGroup.UseVisualStyleBackColor = true;
            this.chkGroup.CheckedChanged += new System.EventHandler(this.chkGroup_CheckedChanged);
            // 
            // chkBranch
            // 
            this.chkBranch.AutoSize = true;
            this.chkBranch.Location = new System.Drawing.Point(28, 75);
            this.chkBranch.Name = "chkBranch";
            this.chkBranch.Size = new System.Drawing.Size(60, 17);
            this.chkBranch.TabIndex = 19;
            this.chkBranch.Text = "Branch";
            this.chkBranch.UseVisualStyleBackColor = true;
            this.chkBranch.CheckedChanged += new System.EventHandler(this.chkBranch_CheckedChanged);
            // 
            // frmViewInfo_PerVolume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 633);
            this.Controls.Add(this.chkBranch);
            this.Controls.Add(this.chkGroup);
            this.Controls.Add(this.chkMarket);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboMarket);
            this.Controls.Add(this.cboGroupTo);
            this.Controls.Add(this.cboBranchFrom);
            this.Controls.Add(this.cboBranchTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboGroupFrom);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTop);
            this.Controls.Add(this.dgvDesc);
            this.Controls.Add(this.dgvAsc);
            this.Name = "frmViewInfo_PerVolume";
            this.Text = "Statistic: Top stocks by Volume";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmViewInfo_PerVolume_Load);
            this.Resize += new System.EventHandler(this.frmViewInfo_PerVolume_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAsc;
        private System.Windows.Forms.DataGridView dgvDesc;
        private System.Windows.Forms.ComboBox cboTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ComboBox cboGroupFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboBranchTo;
        private System.Windows.Forms.ComboBox cboBranchFrom;
        private System.Windows.Forms.ComboBox cboGroupTo;
        private System.Windows.Forms.ComboBox cboMarket;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkMarket;
        private System.Windows.Forms.CheckBox chkGroup;
        private System.Windows.Forms.CheckBox chkBranch;
    }
}