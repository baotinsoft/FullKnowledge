namespace Knowledge
{
    partial class frmRead
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
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.rtbContent = new System.Windows.Forms.RichTextBox();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.btnOpenPage = new System.Windows.Forms.Button();
            this.btnSaveBook = new System.Windows.Forms.Button();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.lblFile = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.chkIsMale = new System.Windows.Forms.CheckBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.picShow = new System.Windows.Forms.PictureBox();
            this.lstFile = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgOpen
            // 
            this.dlgOpen.Filter = "PDF files|*.pdf|Word files|*.docx";
            this.dlgOpen.InitialDirectory = "E:\\Ebooks";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(341, 16);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse ...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(54, 19);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(265, 20);
            this.txtFile.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(857, 18);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open All";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(422, 17);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 3;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // rtbContent
            // 
            this.rtbContent.Location = new System.Drawing.Point(447, 240);
            this.rtbContent.Name = "rtbContent";
            this.rtbContent.Size = new System.Drawing.Size(294, 191);
            this.rtbContent.TabIndex = 4;
            this.rtbContent.Text = "";
            // 
            // cboLanguage
            // 
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(585, 19);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(74, 21);
            this.cboLanguage.TabIndex = 5;
            // 
            // btnOpenPage
            // 
            this.btnOpenPage.Location = new System.Drawing.Point(776, 18);
            this.btnOpenPage.Name = "btnOpenPage";
            this.btnOpenPage.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPage.TabIndex = 6;
            this.btnOpenPage.Text = "Open Page";
            this.btnOpenPage.UseVisualStyleBackColor = true;
            this.btnOpenPage.Click += new System.EventHandler(this.btnOpenPage_Click);
            // 
            // btnSaveBook
            // 
            this.btnSaveBook.Location = new System.Drawing.Point(504, 17);
            this.btnSaveBook.Name = "btnSaveBook";
            this.btnSaveBook.Size = new System.Drawing.Size(75, 23);
            this.btnSaveBook.TabIndex = 7;
            this.btnSaveBook.Text = "Save Book";
            this.btnSaveBook.UseVisualStyleBackColor = true;
            this.btnSaveBook.Click += new System.EventHandler(this.btnSaveBook_Click);
            // 
            // txtPage
            // 
            this.txtPage.Location = new System.Drawing.Point(722, 18);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(41, 20);
            this.txtPage.TabIndex = 8;
            this.txtPage.Text = "6";
            this.txtPage.TextChanged += new System.EventHandler(this.txtPage_TextChanged);
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 74);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(429, 150);
            this.dgvList.TabIndex = 27;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 21);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(26, 13);
            this.lblFile.TabIndex = 28;
            this.lblFile.Text = "File:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 47);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(54, 45);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(265, 20);
            this.txtTitle.TabIndex = 29;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // chkIsMale
            // 
            this.chkIsMale.AutoSize = true;
            this.chkIsMale.Location = new System.Drawing.Point(665, 22);
            this.chkIsMale.Name = "chkIsMale";
            this.chkIsMale.Size = new System.Drawing.Size(49, 17);
            this.chkIsMale.TabIndex = 31;
            this.chkIsMale.Text = "Male";
            this.chkIsMale.UseVisualStyleBackColor = true;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(338, 50);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(64, 13);
            this.lblType.TabIndex = 33;
            this.lblType.Text = "Loại Ebook:";
            this.lblType.Visible = false;
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(447, 47);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(294, 21);
            this.cboType.TabIndex = 32;
            this.cboType.Visible = false;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // picShow
            // 
            this.picShow.Location = new System.Drawing.Point(695, 74);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(174, 160);
            this.picShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picShow.TabIndex = 41;
            this.picShow.TabStop = false;
            this.picShow.Click += new System.EventHandler(this.picShow_Click);
            // 
            // lstFile
            // 
            this.lstFile.FormattingEnabled = true;
            this.lstFile.Location = new System.Drawing.Point(449, 74);
            this.lstFile.Name = "lstFile";
            this.lstFile.Size = new System.Drawing.Size(240, 160);
            this.lstFile.TabIndex = 40;
            this.lstFile.Click += new System.EventHandler(this.lstFile_Click);
            // 
            // frmRead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 498);
            this.Controls.Add(this.picShow);
            this.Controls.Add(this.lstFile);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.chkIsMale);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.btnSaveBook);
            this.Controls.Add(this.btnOpenPage);
            this.Controls.Add(this.cboLanguage);
            this.Controls.Add(this.rtbContent);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnBrowse);
            this.Name = "frmRead";
            this.Text = "Read Knowledge";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReadEBook_Load);
            this.SizeChanged += new System.EventHandler(this.frmReadEBook_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.RichTextBox rtbContent;
        private System.Windows.Forms.ComboBox cboLanguage;
        private System.Windows.Forms.Button btnOpenPage;
        private System.Windows.Forms.Button btnSaveBook;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.CheckBox chkIsMale;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.ListBox lstFile;
    }
}