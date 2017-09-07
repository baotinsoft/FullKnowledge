namespace Knowledge
{
    partial class frmBookSave
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.cboAuthor = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cboPublisher = new System.Windows.Forms.ComboBox();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.lblISBN = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.lblPages = new System.Windows.Forms.Label();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cboFormat = new System.Windows.Forms.ComboBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnAutoSave = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUpdateType = new System.Windows.Forms.Button();
            this.txtUrlDownload = new System.Windows.Forms.TextBox();
            this.lblDownloadUrl = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(79, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(185, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(13, 51);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(41, 13);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author:";
            // 
            // cboAuthor
            // 
            this.cboAuthor.FormattingEnabled = true;
            this.cboAuthor.Location = new System.Drawing.Point(79, 48);
            this.cboAuthor.Name = "cboAuthor";
            this.cboAuthor.Size = new System.Drawing.Size(185, 21);
            this.cboAuthor.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(79, 110);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(735, 92);
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
            // cboPublisher
            // 
            this.cboPublisher.FormattingEnabled = true;
            this.cboPublisher.Location = new System.Drawing.Point(79, 84);
            this.cboPublisher.Name = "cboPublisher";
            this.cboPublisher.Size = new System.Drawing.Size(185, 21);
            this.cboPublisher.TabIndex = 7;
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(13, 87);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(53, 13);
            this.lblPublisher.TabIndex = 6;
            this.lblPublisher.Text = "Publisher:";
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(620, 15);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(185, 20);
            this.txtISBN.TabIndex = 9;
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(554, 15);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(35, 13);
            this.lblISBN.TabIndex = 8;
            this.lblISBN.Text = "ISBN:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(620, 53);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(185, 20);
            this.txtYear.TabIndex = 11;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(554, 53);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 10;
            this.lblYear.Text = "Year:";
            // 
            // txtPages
            // 
            this.txtPages.Location = new System.Drawing.Point(347, 15);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(185, 20);
            this.txtPages.TabIndex = 13;
            // 
            // lblPages
            // 
            this.lblPages.AutoSize = true;
            this.lblPages.Location = new System.Drawing.Point(281, 15);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(40, 13);
            this.lblPages.TabIndex = 12;
            this.lblPages.Text = "Pages:";
            // 
            // cboLanguage
            // 
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(347, 46);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(185, 21);
            this.cboLanguage.TabIndex = 15;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(281, 49);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(58, 13);
            this.lblLanguage.TabIndex = 14;
            this.lblLanguage.Text = "Language:";
            // 
            // cboFormat
            // 
            this.cboFormat.FormattingEnabled = true;
            this.cboFormat.Location = new System.Drawing.Point(915, 12);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Size = new System.Drawing.Size(185, 21);
            this.cboFormat.TabIndex = 19;
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(833, 18);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(42, 13);
            this.lblFormat.TabIndex = 18;
            this.lblFormat.Text = "Format:";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(347, 86);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(185, 20);
            this.txtSize.TabIndex = 17;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(281, 86);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(30, 13);
            this.lblSize.TabIndex = 16;
            this.lblSize.Text = "Size:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(915, 50);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(185, 20);
            this.txtPath.TabIndex = 21;
            this.txtPath.Text = "D:\\Ebooks\\New";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(833, 53);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 20;
            this.lblPath.Text = "Path:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(836, 144);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(836, 214);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(620, 84);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(185, 21);
            this.cboType.TabIndex = 25;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(554, 87);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 24;
            this.lblType.Text = "Type:";
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 214);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(802, 150);
            this.dgvList.TabIndex = 26;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(915, 81);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(185, 20);
            this.txtUrl.TabIndex = 28;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(833, 84);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(23, 13);
            this.lblUrl.TabIndex = 27;
            this.lblUrl.Text = "Url:";
            // 
            // btnAutoSave
            // 
            this.btnAutoSave.Location = new System.Drawing.Point(836, 179);
            this.btnAutoSave.Name = "btnAutoSave";
            this.btnAutoSave.Size = new System.Drawing.Size(100, 30);
            this.btnAutoSave.TabIndex = 29;
            this.btnAutoSave.Text = "Auto Save";
            this.btnAutoSave.UseVisualStyleBackColor = true;
            this.btnAutoSave.Click += new System.EventHandler(this.btnAutoSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(949, 144);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUpdateType
            // 
            this.btnUpdateType.Location = new System.Drawing.Point(949, 179);
            this.btnUpdateType.Name = "btnUpdateType";
            this.btnUpdateType.Size = new System.Drawing.Size(100, 30);
            this.btnUpdateType.TabIndex = 31;
            this.btnUpdateType.Text = "Update Type";
            this.btnUpdateType.UseVisualStyleBackColor = true;
            this.btnUpdateType.Click += new System.EventHandler(this.btnUpdateType_Click);
            // 
            // txtUrlDownload
            // 
            this.txtUrlDownload.Location = new System.Drawing.Point(914, 118);
            this.txtUrlDownload.Name = "txtUrlDownload";
            this.txtUrlDownload.Size = new System.Drawing.Size(185, 20);
            this.txtUrlDownload.TabIndex = 33;
            // 
            // lblDownloadUrl
            // 
            this.lblDownloadUrl.AutoSize = true;
            this.lblDownloadUrl.Location = new System.Drawing.Point(832, 121);
            this.lblDownloadUrl.Name = "lblDownloadUrl";
            this.lblDownloadUrl.Size = new System.Drawing.Size(74, 13);
            this.lblDownloadUrl.TabIndex = 32;
            this.lblDownloadUrl.Text = "Download Url:";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(949, 214);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 30);
            this.btnNew.TabIndex = 36;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmBookSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 376);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtUrlDownload);
            this.Controls.Add(this.lblDownloadUrl);
            this.Controls.Add(this.btnUpdateType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAutoSave);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.cboFormat);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.cboLanguage);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(this.lblPages);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.cboPublisher);
            this.Controls.Add(this.lblPublisher);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.cboAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "frmBookSave";
            this.Text = "frmBookSave";
            this.Load += new System.EventHandler(this.frmBookSave_Load);
            this.SizeChanged += new System.EventHandler(this.frmBookSave_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.ComboBox cboAuthor;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cboPublisher;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.Label lblPages;
        private System.Windows.Forms.ComboBox cboLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cboFormat;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Button btnAutoSave;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdateType;
        private System.Windows.Forms.TextBox txtUrlDownload;
        private System.Windows.Forms.Label lblDownloadUrl;
        private System.Windows.Forms.Button btnNew;
    }
}