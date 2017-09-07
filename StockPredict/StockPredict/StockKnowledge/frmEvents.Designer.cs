namespace StockKnowledge
{
    partial class frmEvents
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
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbDetail = new System.Windows.Forms.RichTextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cboEventType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStock = new System.Windows.Forms.ComboBox();
            this.dtNoRightDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtLastRegisterDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtExecuteDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCurPrice = new System.Windows.Forms.TextBox();
            this.btnCal = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMethod = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnAuto = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.txtStockSearch = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(487, 26);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Cập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(73, 29);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(381, 20);
            this.txtValue.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Giá trị:";
            // 
            // rtbDetail
            // 
            this.rtbDetail.Location = new System.Drawing.Point(73, 251);
            this.rtbDetail.Name = "rtbDetail";
            this.rtbDetail.Size = new System.Drawing.Size(506, 80);
            this.rtbDetail.TabIndex = 3;
            this.rtbDetail.Text = "";
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(585, 6);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(413, 392);
            this.dgvList.TabIndex = 4;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chi tiết:";
            // 
            // cboEventType
            // 
            this.cboEventType.FormattingEnabled = true;
            this.cboEventType.Location = new System.Drawing.Point(73, 51);
            this.cboEventType.Name = "cboEventType";
            this.cboEventType.Size = new System.Drawing.Size(381, 21);
            this.cboEventType.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Loại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cách tính:";
            // 
            // cboMethod
            // 
            this.cboMethod.FormattingEnabled = true;
            this.cboMethod.Location = new System.Drawing.Point(73, 78);
            this.cboMethod.Name = "cboMethod";
            this.cboMethod.Size = new System.Drawing.Size(381, 21);
            this.cboMethod.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cổ phiếu:";
            // 
            // cboStock
            // 
            this.cboStock.FormattingEnabled = true;
            this.cboStock.Location = new System.Drawing.Point(73, 105);
            this.cboStock.Name = "cboStock";
            this.cboStock.Size = new System.Drawing.Size(381, 21);
            this.cboStock.TabIndex = 10;
            // 
            // dtNoRightDate
            // 
            this.dtNoRightDate.CustomFormat = "dd/MM/yyyy";
            this.dtNoRightDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNoRightDate.Location = new System.Drawing.Point(121, 133);
            this.dtNoRightDate.Name = "dtNoRightDate";
            this.dtNoRightDate.Size = new System.Drawing.Size(85, 20);
            this.dtNoRightDate.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Không hưởng quyền:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(218, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Đăng ký danh sách:";
            // 
            // dtLastRegisterDate
            // 
            this.dtLastRegisterDate.CustomFormat = "dd/MM/yyyy";
            this.dtLastRegisterDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLastRegisterDate.Location = new System.Drawing.Point(324, 133);
            this.dtLastRegisterDate.Name = "dtLastRegisterDate";
            this.dtLastRegisterDate.Size = new System.Drawing.Size(91, 20);
            this.dtLastRegisterDate.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Thực thi:";
            // 
            // dtExecuteDate
            // 
            this.dtExecuteDate.CustomFormat = "dd/MM/yyyy";
            this.dtExecuteDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExecuteDate.Location = new System.Drawing.Point(121, 162);
            this.dtExecuteDate.Name = "dtExecuteDate";
            this.dtExecuteDate.Size = new System.Drawing.Size(85, 20);
            this.dtExecuteDate.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Giá hiện hành:";
            // 
            // txtCurPrice
            // 
            this.txtCurPrice.Location = new System.Drawing.Point(121, 193);
            this.txtCurPrice.Name = "txtCurPrice";
            this.txtCurPrice.Size = new System.Drawing.Size(85, 20);
            this.txtCurPrice.TabIndex = 19;
            // 
            // btnCal
            // 
            this.btnCal.Location = new System.Drawing.Point(379, 190);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(75, 23);
            this.btnCal.TabIndex = 21;
            this.btnCal.Text = "Tính Thử";
            this.btnCal.UseVisualStyleBackColor = true;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // txtResult
            // 
            this.txtResult.Enabled = false;
            this.txtResult.Location = new System.Drawing.Point(271, 193);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(85, 20);
            this.txtResult.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(218, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Kết quả:";
            // 
            // txtMethod
            // 
            this.txtMethod.Enabled = false;
            this.txtMethod.Location = new System.Drawing.Point(121, 225);
            this.txtMethod.Name = "txtMethod";
            this.txtMethod.Size = new System.Drawing.Size(333, 20);
            this.txtMethod.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Cách tính:";
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(487, 86);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 26;
            this.btnAuto.Text = "Tự Động";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 380);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Thông Báo:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(73, 353);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(506, 80);
            this.txtMessage.TabIndex = 27;
            this.txtMessage.Text = "";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(487, 59);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(58, 17);
            this.chkAll.TabIndex = 29;
            this.chkAll.Text = "Tất Cả";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // txtStockSearch
            // 
            this.txtStockSearch.Location = new System.Drawing.Point(73, 6);
            this.txtStockSearch.Name = "txtStockSearch";
            this.txtStockSearch.Size = new System.Drawing.Size(381, 20);
            this.txtStockSearch.TabIndex = 30;
            this.txtStockSearch.TextChanged += new System.EventHandler(this.txtStockSearch_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Cổ phiếu:";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(487, 129);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 32;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // frmEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 465);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtStockSearch);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtMethod);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.btnCal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCurPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtExecuteDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtLastRegisterDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtNoRightDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboStock);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboMethod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboEventType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.rtbDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnUpdate);
            this.Name = "frmEvents";
            this.Text = "frmEvents";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEvents_Load);
            this.SizeChanged += new System.EventHandler(this.frmEvents_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbDetail;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboEventType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMethod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStock;
        private System.Windows.Forms.DateTimePicker dtNoRightDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtLastRegisterDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtExecuteDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCurPrice;
        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMethod;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.TextBox txtStockSearch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnFilter;
    }
}