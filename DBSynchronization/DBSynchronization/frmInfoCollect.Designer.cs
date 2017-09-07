namespace DBSynchronization
{
    partial class frmInfoCollect
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
            this.lblTable = new System.Windows.Forms.Label();
            this.cboTable = new System.Windows.Forms.ComboBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.chkGoolge = new System.Windows.Forms.CheckBox();
            this.btnCollect = new System.Windows.Forms.Button();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtBegin = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblOrder = new System.Windows.Forms.Label();
            this.txtGoolgeSearch = new System.Windows.Forms.TextBox();
            this.lblGoogleSearch = new System.Windows.Forms.Label();
            this.cboUrl = new System.Windows.Forms.ComboBox();
            this.txtAlphaEnd = new System.Windows.Forms.TextBox();
            this.txtAlphaBegin = new System.Windows.Forms.TextBox();
            this.btnSaveUrl = new System.Windows.Forms.Button();
            this.chkLoop = new System.Windows.Forms.CheckBox();
            this.cboItemType = new System.Windows.Forms.ComboBox();
            this.lblItemType = new System.Windows.Forms.Label();
            this.chkDaily = new System.Windows.Forms.CheckBox();
            this.lblFieldName = new System.Windows.Forms.Label();
            this.lblDataType = new System.Windows.Forms.Label();
            this.lblSkip = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dlgBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.btnStoreData = new System.Windows.Forms.Button();
            this.lblDefGroup = new System.Windows.Forms.Label();
            this.chkHttpPost = new System.Windows.Forms.CheckBox();
            this.cboContentType = new System.Windows.Forms.ComboBox();
            this.lblContentType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(13, 13);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(37, 13);
            this.lblTable.TabIndex = 0;
            this.lblTable.Text = "Table:";
            // 
            // cboTable
            // 
            this.cboTable.FormattingEnabled = true;
            this.cboTable.Location = new System.Drawing.Point(53, 10);
            this.cboTable.Name = "cboTable";
            this.cboTable.Size = new System.Drawing.Size(125, 21);
            this.cboTable.TabIndex = 1;
            this.cboTable.SelectedIndexChanged += new System.EventHandler(this.cboTable_SelectedIndexChanged);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(281, 10);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(23, 13);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "Url:";
            // 
            // chkGoolge
            // 
            this.chkGoolge.AutoSize = true;
            this.chkGoolge.Location = new System.Drawing.Point(817, 121);
            this.chkGoolge.Name = "chkGoolge";
            this.chkGoolge.Size = new System.Drawing.Size(165, 17);
            this.chkGoolge.TabIndex = 4;
            this.chkGoolge.Text = "Use Goolge Advance Search";
            this.chkGoolge.UseVisualStyleBackColor = true;
            // 
            // btnCollect
            // 
            this.btnCollect.Location = new System.Drawing.Point(1104, 102);
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Size = new System.Drawing.Size(75, 23);
            this.btnCollect.TabIndex = 5;
            this.btnCollect.Text = "Collect";
            this.btnCollect.UseVisualStyleBackColor = true;
            this.btnCollect.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(256, 46);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(366, 46);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "To";
            // 
            // txtBegin
            // 
            this.txtBegin.Location = new System.Drawing.Point(817, 69);
            this.txtBegin.Name = "txtBegin";
            this.txtBegin.Size = new System.Drawing.Size(46, 20);
            this.txtBegin.TabIndex = 8;
            this.txtBegin.Text = "0";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(869, 69);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(46, 20);
            this.txtEnd.TabIndex = 9;
            this.txtEnd.Text = "0";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(817, 205);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComment.Size = new System.Drawing.Size(438, 172);
            this.txtComment.TabIndex = 10;
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(466, 46);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(33, 13);
            this.lblOrder.TabIndex = 11;
            this.lblOrder.Text = "Order";
            // 
            // txtGoolgeSearch
            // 
            this.txtGoolgeSearch.Location = new System.Drawing.Point(1008, 69);
            this.txtGoolgeSearch.Name = "txtGoolgeSearch";
            this.txtGoolgeSearch.Size = new System.Drawing.Size(252, 20);
            this.txtGoolgeSearch.TabIndex = 12;
            // 
            // lblGoogleSearch
            // 
            this.lblGoogleSearch.AutoSize = true;
            this.lblGoogleSearch.Location = new System.Drawing.Point(921, 71);
            this.lblGoogleSearch.Name = "lblGoogleSearch";
            this.lblGoogleSearch.Size = new System.Drawing.Size(81, 13);
            this.lblGoogleSearch.TabIndex = 13;
            this.lblGoogleSearch.Text = "Goolge Search:";
            // 
            // cboUrl
            // 
            this.cboUrl.FormattingEnabled = true;
            this.cboUrl.Location = new System.Drawing.Point(310, 7);
            this.cboUrl.Name = "cboUrl";
            this.cboUrl.Size = new System.Drawing.Size(948, 21);
            this.cboUrl.TabIndex = 14;
            this.cboUrl.SelectedIndexChanged += new System.EventHandler(this.cboUrl_SelectedIndexChanged);
            // 
            // txtAlphaEnd
            // 
            this.txtAlphaEnd.Location = new System.Drawing.Point(869, 95);
            this.txtAlphaEnd.Name = "txtAlphaEnd";
            this.txtAlphaEnd.Size = new System.Drawing.Size(46, 20);
            this.txtAlphaEnd.TabIndex = 16;
            // 
            // txtAlphaBegin
            // 
            this.txtAlphaBegin.Location = new System.Drawing.Point(817, 95);
            this.txtAlphaBegin.Name = "txtAlphaBegin";
            this.txtAlphaBegin.Size = new System.Drawing.Size(46, 20);
            this.txtAlphaBegin.TabIndex = 15;
            // 
            // btnSaveUrl
            // 
            this.btnSaveUrl.Location = new System.Drawing.Point(1023, 102);
            this.btnSaveUrl.Name = "btnSaveUrl";
            this.btnSaveUrl.Size = new System.Drawing.Size(75, 23);
            this.btnSaveUrl.TabIndex = 17;
            this.btnSaveUrl.Text = "Save Url";
            this.btnSaveUrl.UseVisualStyleBackColor = true;
            this.btnSaveUrl.Click += new System.EventHandler(this.btnSaveUrl_Click);
            // 
            // chkLoop
            // 
            this.chkLoop.AutoSize = true;
            this.chkLoop.Location = new System.Drawing.Point(924, 87);
            this.chkLoop.Name = "chkLoop";
            this.chkLoop.Size = new System.Drawing.Size(50, 17);
            this.chkLoop.TabIndex = 18;
            this.chkLoop.Text = "Loop";
            this.chkLoop.UseVisualStyleBackColor = true;
            // 
            // cboItemType
            // 
            this.cboItemType.FormattingEnabled = true;
            this.cboItemType.Location = new System.Drawing.Point(881, 149);
            this.cboItemType.Name = "cboItemType";
            this.cboItemType.Size = new System.Drawing.Size(374, 21);
            this.cboItemType.TabIndex = 20;
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Location = new System.Drawing.Point(818, 152);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(57, 13);
            this.lblItemType.TabIndex = 19;
            this.lblItemType.Text = "Item Type:";
            // 
            // chkDaily
            // 
            this.chkDaily.AutoSize = true;
            this.chkDaily.Location = new System.Drawing.Point(197, 10);
            this.chkDaily.Name = "chkDaily";
            this.chkDaily.Size = new System.Drawing.Size(49, 17);
            this.chkDaily.TabIndex = 21;
            this.chkDaily.Text = "Daily";
            this.chkDaily.UseVisualStyleBackColor = true;
            // 
            // lblFieldName
            // 
            this.lblFieldName.AutoSize = true;
            this.lblFieldName.Location = new System.Drawing.Point(12, 46);
            this.lblFieldName.Name = "lblFieldName";
            this.lblFieldName.Size = new System.Drawing.Size(60, 13);
            this.lblFieldName.TabIndex = 22;
            this.lblFieldName.Text = "Field Name";
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.Location = new System.Drawing.Point(557, 46);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(54, 13);
            this.lblDataType.TabIndex = 23;
            this.lblDataType.Text = "DataType";
            // 
            // lblSkip
            // 
            this.lblSkip.AutoSize = true;
            this.lblSkip.Location = new System.Drawing.Point(148, 46);
            this.lblSkip.Name = "lblSkip";
            this.lblSkip.Size = new System.Drawing.Size(28, 13);
            this.lblSkip.TabIndex = 24;
            this.lblSkip.Text = "Skip";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(817, 46);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(395, 20);
            this.txtPath.TabIndex = 25;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(1218, 46);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(42, 23);
            this.btnBrowse.TabIndex = 26;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnStoreData
            // 
            this.btnStoreData.Location = new System.Drawing.Point(1185, 102);
            this.btnStoreData.Name = "btnStoreData";
            this.btnStoreData.Size = new System.Drawing.Size(75, 23);
            this.btnStoreData.TabIndex = 27;
            this.btnStoreData.Text = "Store Data";
            this.btnStoreData.UseVisualStyleBackColor = true;
            this.btnStoreData.Click += new System.EventHandler(this.btnStoreData_Click);
            // 
            // lblDefGroup
            // 
            this.lblDefGroup.AutoSize = true;
            this.lblDefGroup.Location = new System.Drawing.Point(684, 46);
            this.lblDefGroup.Name = "lblDefGroup";
            this.lblDefGroup.Size = new System.Drawing.Size(56, 13);
            this.lblDefGroup.TabIndex = 28;
            this.lblDefGroup.Text = "Def Group";
            // 
            // chkHttpPost
            // 
            this.chkHttpPost.AutoSize = true;
            this.chkHttpPost.Location = new System.Drawing.Point(821, 182);
            this.chkHttpPost.Name = "chkHttpPost";
            this.chkHttpPost.Size = new System.Drawing.Size(70, 17);
            this.chkHttpPost.TabIndex = 29;
            this.chkHttpPost.Text = "Http Post";
            this.chkHttpPost.UseVisualStyleBackColor = true;
            // 
            // cboContentType
            // 
            this.cboContentType.FormattingEnabled = true;
            this.cboContentType.Location = new System.Drawing.Point(972, 180);
            this.cboContentType.Name = "cboContentType";
            this.cboContentType.Size = new System.Drawing.Size(141, 21);
            this.cboContentType.TabIndex = 31;
            // 
            // lblContentType
            // 
            this.lblContentType.AutoSize = true;
            this.lblContentType.Location = new System.Drawing.Point(896, 183);
            this.lblContentType.Name = "lblContentType";
            this.lblContentType.Size = new System.Drawing.Size(70, 13);
            this.lblContentType.TabIndex = 30;
            this.lblContentType.Text = "Control Type:";
            // 
            // frmInfoCollect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1270, 452);
            this.Controls.Add(this.cboContentType);
            this.Controls.Add(this.lblContentType);
            this.Controls.Add(this.chkHttpPost);
            this.Controls.Add(this.lblDefGroup);
            this.Controls.Add(this.btnStoreData);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblSkip);
            this.Controls.Add(this.lblDataType);
            this.Controls.Add(this.lblFieldName);
            this.Controls.Add(this.chkDaily);
            this.Controls.Add(this.cboItemType);
            this.Controls.Add(this.lblItemType);
            this.Controls.Add(this.chkLoop);
            this.Controls.Add(this.btnSaveUrl);
            this.Controls.Add(this.txtAlphaEnd);
            this.Controls.Add(this.txtAlphaBegin);
            this.Controls.Add(this.cboUrl);
            this.Controls.Add(this.lblGoogleSearch);
            this.Controls.Add(this.txtGoolgeSearch);
            this.Controls.Add(this.lblOrder);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.txtBegin);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.btnCollect);
            this.Controls.Add(this.chkGoolge);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.cboTable);
            this.Controls.Add(this.lblTable);
            this.Name = "frmInfoCollect";
            this.Text = "frmInfoCollect";
            this.Load += new System.EventHandler(this.frmInfoCollect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.CheckBox chkGoolge;
        private System.Windows.Forms.Button btnCollect;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtBegin;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.TextBox txtGoolgeSearch;
        private System.Windows.Forms.Label lblGoogleSearch;
        private System.Windows.Forms.ComboBox cboUrl;
        private System.Windows.Forms.TextBox txtAlphaEnd;
        private System.Windows.Forms.TextBox txtAlphaBegin;
        private System.Windows.Forms.Button btnSaveUrl;
        private System.Windows.Forms.CheckBox chkLoop;
        private System.Windows.Forms.ComboBox cboItemType;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.CheckBox chkDaily;
        private System.Windows.Forms.Label lblFieldName;
        private System.Windows.Forms.Label lblDataType;
        private System.Windows.Forms.Label lblSkip;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog dlgBrowse;
        private System.Windows.Forms.Button btnStoreData;
        private System.Windows.Forms.Label lblDefGroup;
        private System.Windows.Forms.CheckBox chkHttpPost;
        private System.Windows.Forms.ComboBox cboContentType;
        private System.Windows.Forms.Label lblContentType;
    }
}