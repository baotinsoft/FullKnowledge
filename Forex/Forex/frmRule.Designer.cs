namespace Forex
{
    partial class frmRule
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
            this.dgvList = new PagingGridControl.ctrlPagingGrid();
            this.panAction = new System.Windows.Forms.Panel();
            this.txtRule = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.cboRuleType = new System.Windows.Forms.ComboBox();
            this.cboUsedFor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtRate = new InputControl.ctrlInputControl();
            this.panAction.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvList.Insert = false;
            this.dgvList.ItemperPage = 10;
            this.dgvList.Location = new System.Drawing.Point(4, 12);
            this.dgvList.Name = "dgvList";
            this.dgvList.Order = false;
            this.dgvList.OrderCol = false;
            this.dgvList.Size = new System.Drawing.Size(741, 408);
            this.dgvList.SizeFile = null;
            this.dgvList.TabIndex = 8;
            this.dgvList.TextFile = "";
            this.dgvList.CellClick += new PagingGridControl.ctrlPagingGrid.customCellClick(this.dgvList_CellClick);
            this.dgvList.Del += new PagingGridControl.ctrlPagingGrid.customDel(this.dgvList_Del);
            this.dgvList.Add += new PagingGridControl.ctrlPagingGrid.customAdd(this.dgvList_Add);
            // 
            // panAction
            // 
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
            this.panAction.Controls.Add(this.txtRule);
            this.panAction.Location = new System.Drawing.Point(80, 83);
            this.panAction.Name = "panAction";
            this.panAction.Size = new System.Drawing.Size(510, 245);
            this.panAction.TabIndex = 9;
            this.panAction.Visible = false;
            // 
            // txtRule
            // 
            this.txtRule.Location = new System.Drawing.Point(79, 13);
            this.txtRule.Name = "txtRule";
            this.txtRule.Size = new System.Drawing.Size(417, 20);
            this.txtRule.TabIndex = 0;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(79, 119);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(417, 68);
            this.txtComment.TabIndex = 2;
            // 
            // cboRuleType
            // 
            this.cboRuleType.FormattingEnabled = true;
            this.cboRuleType.Location = new System.Drawing.Point(79, 65);
            this.cboRuleType.Name = "cboRuleType";
            this.cboRuleType.Size = new System.Drawing.Size(121, 21);
            this.cboRuleType.TabIndex = 3;
            // 
            // cboUsedFor
            // 
            this.cboUsedFor.FormattingEnabled = true;
            this.cboUsedFor.Location = new System.Drawing.Point(79, 92);
            this.cboUsedFor.Name = "cboUsedFor";
            this.cboUsedFor.Size = new System.Drawing.Size(121, 21);
            this.cboUsedFor.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rule:";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rule Type:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Comment:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(142, 203);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(238, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(79, 36);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(417, 23);
            this.txtRate.TabIndex = 12;
            // 
            // frmRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 418);
            this.Controls.Add(this.panAction);
            this.Controls.Add(this.dgvList);
            this.Name = "frmRule";
            this.Text = "frmRule";
            this.Load += new System.EventHandler(this.frmRule_Load);
            this.panAction.ResumeLayout(false);
            this.panAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PagingGridControl.ctrlPagingGrid dgvList;
        private System.Windows.Forms.Panel panAction;
        private System.Windows.Forms.TextBox txtRule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboUsedFor;
        private System.Windows.Forms.ComboBox cboRuleType;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private InputControl.ctrlInputControl txtRate;
    }
}