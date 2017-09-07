namespace Forex
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
            this.panAction = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cboRule = new System.Windows.Forms.ComboBox();
            this.txtRate = new InputControl.ctrlInputControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboUsedFor = new System.Windows.Forms.ComboBox();
            this.cboRuleType = new System.Windows.Forms.ComboBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.dgvList = new PagingGridControl.ctrlPagingGrid();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEffectDateCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEffectMoney = new System.Windows.Forms.TextBox();
            this.dtPublishDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.panAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // panAction
            // 
            this.panAction.Controls.Add(this.label9);
            this.panAction.Controls.Add(this.dtPublishDate);
            this.panAction.Controls.Add(this.label8);
            this.panAction.Controls.Add(this.txtEffectMoney);
            this.panAction.Controls.Add(this.label7);
            this.panAction.Controls.Add(this.txtEffectDateCount);
            this.panAction.Controls.Add(this.label6);
            this.panAction.Controls.Add(this.cboRule);
            this.panAction.Controls.Add(this.txtRate);
            this.panAction.Controls.Add(this.btnCancel);
            this.panAction.Controls.Add(this.btnOK);
            this.panAction.Controls.Add(this.label5);
            this.panAction.Controls.Add(this.label4);
            this.panAction.Controls.Add(this.label3);
            this.panAction.Controls.Add(this.label2);
            this.panAction.Controls.Add(this.label1);
            this.panAction.Controls.Add(this.cboUsedFor);
            this.panAction.Controls.Add(this.cboRuleType);
            this.panAction.Controls.Add(this.txtComment);
            this.panAction.Controls.Add(this.txtUrl);
            this.panAction.Location = new System.Drawing.Point(154, 43);
            this.panAction.Name = "panAction";
            this.panAction.Size = new System.Drawing.Size(515, 309);
            this.panAction.TabIndex = 11;
            this.panAction.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Rule:";
            // 
            // cboRule
            // 
            this.cboRule.FormattingEnabled = true;
            this.cboRule.Location = new System.Drawing.Point(79, 119);
            this.cboRule.Name = "cboRule";
            this.cboRule.Size = new System.Drawing.Size(417, 21);
            this.cboRule.TabIndex = 13;
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(79, 36);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(417, 23);
            this.txtRate.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(255, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(159, 276);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Comment:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Used For:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rule Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Url:";
            // 
            // cboUsedFor
            // 
            this.cboUsedFor.FormattingEnabled = true;
            this.cboUsedFor.Location = new System.Drawing.Point(79, 92);
            this.cboUsedFor.Name = "cboUsedFor";
            this.cboUsedFor.Size = new System.Drawing.Size(121, 21);
            this.cboUsedFor.TabIndex = 4;
            // 
            // cboRuleType
            // 
            this.cboRuleType.FormattingEnabled = true;
            this.cboRuleType.Location = new System.Drawing.Point(79, 65);
            this.cboRuleType.Name = "cboRuleType";
            this.cboRuleType.Size = new System.Drawing.Size(121, 21);
            this.cboRuleType.TabIndex = 3;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(79, 146);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(417, 91);
            this.txtComment.TabIndex = 2;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(79, 13);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(417, 20);
            this.txtUrl.TabIndex = 0;
            // 
            // dgvList
            // 
            this.dgvList.AddEnable = true;
            this.dgvList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvList.Check = true;
            this.dgvList.DeleteEnable = true;
            this.dgvList.ExportEnable = false;
            this.dgvList.Filter = false;
            this.dgvList.FontSize = 0F;
            this.dgvList.HideId = true;
            this.dgvList.ImportEnable = false;
            this.dgvList.Insert = false;
            this.dgvList.ItemperPage = 10;
            this.dgvList.Location = new System.Drawing.Point(-1, 0);
            this.dgvList.Name = "dgvList";
            this.dgvList.Order = false;
            this.dgvList.OrderCol = false;
            this.dgvList.Size = new System.Drawing.Size(867, 408);
            this.dgvList.SizeFile = null;
            this.dgvList.TabIndex = 10;
            this.dgvList.TextFile = "";
            this.dgvList.CellClick += new PagingGridControl.ctrlPagingGrid.customCellClick(this.dgvList_CellClick);
            this.dgvList.Del += new PagingGridControl.ctrlPagingGrid.customDel(this.dgvList_Del);
            this.dgvList.Add += new PagingGridControl.ctrlPagingGrid.customAdd(this.dgvList_Add);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Effect Date Count:";
            // 
            // txtEffectDateCount
            // 
            this.txtEffectDateCount.Location = new System.Drawing.Point(357, 65);
            this.txtEffectDateCount.Name = "txtEffectDateCount";
            this.txtEffectDateCount.Size = new System.Drawing.Size(139, 20);
            this.txtEffectDateCount.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(223, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Effect Money:";
            // 
            // txtEffectMoney
            // 
            this.txtEffectMoney.Location = new System.Drawing.Point(357, 91);
            this.txtEffectMoney.Name = "txtEffectMoney";
            this.txtEffectMoney.Size = new System.Drawing.Size(139, 20);
            this.txtEffectMoney.TabIndex = 17;
            // 
            // dtPublishDate
            // 
            this.dtPublishDate.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtPublishDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPublishDate.Location = new System.Drawing.Point(79, 243);
            this.dtPublishDate.Name = "dtPublishDate";
            this.dtPublishDate.Size = new System.Drawing.Size(168, 20);
            this.dtPublishDate.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Publish Date:";
            // 
            // frmNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 420);
            this.Controls.Add(this.panAction);
            this.Controls.Add(this.dgvList);
            this.Name = "frmNews";
            this.Text = "frmNews";
            this.Load += new System.EventHandler(this.frmNews_Load);
            this.panAction.ResumeLayout(false);
            this.panAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panAction;
        private InputControl.ctrlInputControl txtRate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboUsedFor;
        private System.Windows.Forms.ComboBox cboRuleType;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtUrl;
        private PagingGridControl.ctrlPagingGrid dgvList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboRule;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtPublishDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEffectMoney;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEffectDateCount;
    }
}