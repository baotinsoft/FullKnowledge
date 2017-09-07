namespace StockKnowledge
{
    partial class frmNews
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbDetail = new System.Windows.Forms.RichTextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNewsType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBranch = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboStock = new System.Windows.Forms.ComboBox();
            this.chkGood = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnAuto = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.dtPublish = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(487, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Cập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(73, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(381, 20);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tiêu Đề:";
            // 
            // rtbDetail
            // 
            this.rtbDetail.Location = new System.Drawing.Point(73, 133);
            this.rtbDetail.Name = "rtbDetail";
            this.rtbDetail.Size = new System.Drawing.Size(506, 199);
            this.rtbDetail.TabIndex = 3;
            this.rtbDetail.Text = "";
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(585, 6);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(413, 412);
            this.dgvList.TabIndex = 4;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chi tiết:";
            // 
            // cboNewsType
            // 
            this.cboNewsType.FormattingEnabled = true;
            this.cboNewsType.Location = new System.Drawing.Point(73, 28);
            this.cboNewsType.Name = "cboNewsType";
            this.cboNewsType.Size = new System.Drawing.Size(200, 21);
            this.cboNewsType.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Loại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ngành:";
            // 
            // cboBranch
            // 
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(73, 55);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(381, 21);
            this.cboBranch.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cổ phiếu:";
            // 
            // cboStock
            // 
            this.cboStock.FormattingEnabled = true;
            this.cboStock.Location = new System.Drawing.Point(73, 82);
            this.cboStock.Name = "cboStock";
            this.cboStock.Size = new System.Drawing.Size(381, 21);
            this.cboStock.TabIndex = 10;
            // 
            // chkGood
            // 
            this.chkGood.AutoSize = true;
            this.chkGood.Location = new System.Drawing.Point(487, 30);
            this.chkGood.Name = "chkGood";
            this.chkGood.Size = new System.Drawing.Size(42, 17);
            this.chkGood.TabIndex = 12;
            this.chkGood.Text = "Tốt";
            this.chkGood.UseVisualStyleBackColor = true;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(487, 58);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(58, 17);
            this.chkAll.TabIndex = 31;
            this.chkAll.Text = "Tất Cả";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(487, 85);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 30;
            this.btnAuto.Text = "Tự Động";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 365);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "Thông Báo:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(73, 338);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(506, 80);
            this.txtMessage.TabIndex = 32;
            this.txtMessage.Text = "";
            // 
            // dtPublish
            // 
            this.dtPublish.CustomFormat = "dd/MM/yyyy";
            this.dtPublish.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPublish.Location = new System.Drawing.Point(371, 30);
            this.dtPublish.Name = "dtPublish";
            this.dtPublish.Size = new System.Drawing.Size(83, 20);
            this.dtPublish.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(289, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Ngày Đưa Tin:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Link:";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(73, 109);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(381, 20);
            this.txtLink.TabIndex = 36;
            // 
            // frmNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 430);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtPublish);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.chkGood);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboStock);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboNewsType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.rtbDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnUpdate);
            this.Name = "frmNews";
            this.Text = "frmNews";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNews_Load);
            this.SizeChanged += new System.EventHandler(this.frmNews_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbDetail;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboNewsType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBranch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStock;
        private System.Windows.Forms.CheckBox chkGood;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.DateTimePicker dtPublish;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLink;
    }
}