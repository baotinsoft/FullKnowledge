namespace Knowledge
{
    partial class frmTermSave
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtEn = new System.Windows.Forms.TextBox();
            this.lblEn = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtVn = new System.Windows.Forms.TextBox();
            this.lblVn = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(79, 61);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(1069, 196);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 144);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // txtEn
            // 
            this.txtEn.Location = new System.Drawing.Point(79, 7);
            this.txtEn.Name = "txtEn";
            this.txtEn.Size = new System.Drawing.Size(202, 20);
            this.txtEn.TabIndex = 17;
            // 
            // lblEn
            // 
            this.lblEn.AutoSize = true;
            this.lblEn.Location = new System.Drawing.Point(13, 11);
            this.lblEn.Name = "lblEn";
            this.lblEn.Size = new System.Drawing.Size(23, 13);
            this.lblEn.TabIndex = 16;
            this.lblEn.Text = "En:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(845, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1051, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(615, 32);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(185, 21);
            this.cboType.TabIndex = 25;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(566, 35);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 24;
            this.lblType.Text = "Type:";
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 263);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(559, 101);
            this.dgvList.TabIndex = 26;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(948, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 23);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(79, 35);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(478, 20);
            this.txtUrl.TabIndex = 32;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(13, 35);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(23, 13);
            this.lblUrl.TabIndex = 31;
            this.lblUrl.Text = "Url:";
            // 
            // txtVn
            // 
            this.txtVn.Location = new System.Drawing.Point(355, 9);
            this.txtVn.Name = "txtVn";
            this.txtVn.Size = new System.Drawing.Size(202, 20);
            this.txtVn.TabIndex = 34;
            // 
            // lblVn
            // 
            this.lblVn.AutoSize = true;
            this.lblVn.Location = new System.Drawing.Point(296, 14);
            this.lblVn.Name = "lblVn";
            this.lblVn.Size = new System.Drawing.Size(23, 13);
            this.lblVn.TabIndex = 33;
            this.lblVn.Text = "Vn:";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(845, 33);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(97, 23);
            this.btnNew.TabIndex = 35;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmTermSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 376);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtVn);
            this.Controls.Add(this.lblVn);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtEn);
            this.Controls.Add(this.lblEn);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Name = "frmTermSave";
            this.Text = "frmTermSave";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTermSave_Load);
            this.SizeChanged += new System.EventHandler(this.frmTermSave_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtEn;
        private System.Windows.Forms.Label lblEn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtVn;
        private System.Windows.Forms.Label lblVn;
        private System.Windows.Forms.Button btnNew;
    }
}