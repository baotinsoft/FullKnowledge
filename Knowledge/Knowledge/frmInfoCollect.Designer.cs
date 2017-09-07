namespace Knowledge
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
            this.lblType = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
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
            this.SuspendLayout();
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(13, 13);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type:";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(53, 10);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(125, 21);
            this.cboType.TabIndex = 1;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(191, 10);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(23, 13);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "Url:";
            // 
            // chkGoolge
            // 
            this.chkGoolge.AutoSize = true;
            this.chkGoolge.Location = new System.Drawing.Point(551, 47);
            this.chkGoolge.Name = "chkGoolge";
            this.chkGoolge.Size = new System.Drawing.Size(165, 17);
            this.chkGoolge.TabIndex = 4;
            this.chkGoolge.Text = "Use Goolge Advance Search";
            this.chkGoolge.UseVisualStyleBackColor = true;
            // 
            // btnCollect
            // 
            this.btnCollect.Location = new System.Drawing.Point(722, 41);
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
            this.lblFrom.Location = new System.Drawing.Point(136, 46);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(246, 46);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "To";
            // 
            // txtBegin
            // 
            this.txtBegin.Location = new System.Drawing.Point(414, 8);
            this.txtBegin.Name = "txtBegin";
            this.txtBegin.Size = new System.Drawing.Size(61, 20);
            this.txtBegin.TabIndex = 8;
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(481, 8);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(61, 20);
            this.txtEnd.TabIndex = 9;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(515, 105);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtComment.Size = new System.Drawing.Size(366, 237);
            this.txtComment.TabIndex = 10;
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Location = new System.Drawing.Point(346, 46);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(33, 13);
            this.lblOrder.TabIndex = 11;
            this.lblOrder.Text = "Order";
            // 
            // txtGoolgeSearch
            // 
            this.txtGoolgeSearch.Location = new System.Drawing.Point(635, 8);
            this.txtGoolgeSearch.Name = "txtGoolgeSearch";
            this.txtGoolgeSearch.Size = new System.Drawing.Size(243, 20);
            this.txtGoolgeSearch.TabIndex = 12;
            // 
            // lblGoogleSearch
            // 
            this.lblGoogleSearch.AutoSize = true;
            this.lblGoogleSearch.Location = new System.Drawing.Point(548, 10);
            this.lblGoogleSearch.Name = "lblGoogleSearch";
            this.lblGoogleSearch.Size = new System.Drawing.Size(81, 13);
            this.lblGoogleSearch.TabIndex = 13;
            this.lblGoogleSearch.Text = "Goolge Search:";
            // 
            // cboUrl
            // 
            this.cboUrl.FormattingEnabled = true;
            this.cboUrl.Location = new System.Drawing.Point(217, 7);
            this.cboUrl.Name = "cboUrl";
            this.cboUrl.Size = new System.Drawing.Size(191, 21);
            this.cboUrl.TabIndex = 14;
            this.cboUrl.SelectedIndexChanged += new System.EventHandler(this.cboUrl_SelectedIndexChanged);
            // 
            // txtAlphaEnd
            // 
            this.txtAlphaEnd.Location = new System.Drawing.Point(481, 34);
            this.txtAlphaEnd.Name = "txtAlphaEnd";
            this.txtAlphaEnd.Size = new System.Drawing.Size(61, 20);
            this.txtAlphaEnd.TabIndex = 16;
            // 
            // txtAlphaBegin
            // 
            this.txtAlphaBegin.Location = new System.Drawing.Point(414, 34);
            this.txtAlphaBegin.Name = "txtAlphaBegin";
            this.txtAlphaBegin.Size = new System.Drawing.Size(61, 20);
            this.txtAlphaBegin.TabIndex = 15;
            // 
            // btnSaveUrl
            // 
            this.btnSaveUrl.Location = new System.Drawing.Point(803, 41);
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
            this.chkLoop.Location = new System.Drawing.Point(551, 26);
            this.chkLoop.Name = "chkLoop";
            this.chkLoop.Size = new System.Drawing.Size(50, 17);
            this.chkLoop.TabIndex = 18;
            this.chkLoop.Text = "Loop";
            this.chkLoop.UseVisualStyleBackColor = true;
            // 
            // cboItemType
            // 
            this.cboItemType.FormattingEnabled = true;
            this.cboItemType.Location = new System.Drawing.Point(614, 70);
            this.cboItemType.Name = "cboItemType";
            this.cboItemType.Size = new System.Drawing.Size(267, 21);
            this.cboItemType.TabIndex = 20;
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Location = new System.Drawing.Point(551, 73);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(57, 13);
            this.lblItemType.TabIndex = 19;
            this.lblItemType.Text = "Item Type:";
            // 
            // frmInfoCollect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 452);
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
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.lblType);
            this.Name = "frmInfoCollect";
            this.Text = "frmInfoCollect";
            this.Load += new System.EventHandler(this.frmInfoCollect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboType;
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
    }
}