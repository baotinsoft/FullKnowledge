namespace StockPredict
{
    partial class frmInputBranchParam
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
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.cboParam = new System.Windows.Forms.ComboBox();
            this.txtParamValue = new System.Windows.Forms.TextBox();
            this.txtParamDesc = new System.Windows.Forms.TextBox();
            this.txtParamMask = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtParamVN = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtTerm = new System.Windows.Forms.TextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBranch
            // 
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(12, 12);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(392, 21);
            this.cboBranch.TabIndex = 0;
            // 
            // cboParam
            // 
            this.cboParam.FormattingEnabled = true;
            this.cboParam.Location = new System.Drawing.Point(410, 11);
            this.cboParam.Name = "cboParam";
            this.cboParam.Size = new System.Drawing.Size(235, 21);
            this.cboParam.TabIndex = 1;
            this.cboParam.SelectedIndexChanged += new System.EventHandler(this.cboParam_SelectedIndexChanged);
            // 
            // txtParamValue
            // 
            this.txtParamValue.Location = new System.Drawing.Point(651, 10);
            this.txtParamValue.Name = "txtParamValue";
            this.txtParamValue.Size = new System.Drawing.Size(100, 20);
            this.txtParamValue.TabIndex = 2;
            // 
            // txtParamDesc
            // 
            this.txtParamDesc.Location = new System.Drawing.Point(12, 64);
            this.txtParamDesc.Multiline = true;
            this.txtParamDesc.Name = "txtParamDesc";
            this.txtParamDesc.ReadOnly = true;
            this.txtParamDesc.Size = new System.Drawing.Size(1226, 78);
            this.txtParamDesc.TabIndex = 3;
            // 
            // txtParamMask
            // 
            this.txtParamMask.Location = new System.Drawing.Point(757, 10);
            this.txtParamMask.Name = "txtParamMask";
            this.txtParamMask.ReadOnly = true;
            this.txtParamMask.Size = new System.Drawing.Size(100, 20);
            this.txtParamMask.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1163, 33);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToOrderColumns = true;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvList.Location = new System.Drawing.Point(12, 148);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(1226, 576);
            this.dgvList.TabIndex = 8;
            this.dgvList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellValueChanged);
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1082, 33);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(12, 37);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(67, 20);
            this.txtID.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1163, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtParamVN
            // 
            this.txtParamVN.Location = new System.Drawing.Point(85, 38);
            this.txtParamVN.Name = "txtParamVN";
            this.txtParamVN.ReadOnly = true;
            this.txtParamVN.Size = new System.Drawing.Size(402, 20);
            this.txtParamVN.TabIndex = 12;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(1082, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtTerm
            // 
            this.txtTerm.Location = new System.Drawing.Point(924, 10);
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(95, 20);
            this.txtTerm.TabIndex = 14;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(1026, 12);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(37, 17);
            this.chkAll.TabIndex = 15;
            this.chkAll.Text = "All";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(892, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Quý";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(493, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(570, 20);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Help: Tìm kiếm theo ngành + quý; All: tất cả ngành";
            // 
            // frmInputBranchParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 726);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.txtTerm);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtParamVN);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtParamMask);
            this.Controls.Add(this.txtParamDesc);
            this.Controls.Add(this.txtParamValue);
            this.Controls.Add(this.cboParam);
            this.Controls.Add(this.cboBranch);
            this.Name = "frmInputBranchParam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Branch Parameter";
            this.Load += new System.EventHandler(this.frmInputBranchParam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.ComboBox cboParam;
        private System.Windows.Forms.TextBox txtParamValue;
        private System.Windows.Forms.TextBox txtParamDesc;
        private System.Windows.Forms.TextBox txtParamMask;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtParamVN;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtTerm;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}