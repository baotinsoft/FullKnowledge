namespace Forex
{
    partial class frmCompareGoldVN_World
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
            this.btnDisplay = new System.Windows.Forms.Button();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dgvList.Location = new System.Drawing.Point(0, 34);
            this.dgvList.Name = "dgvList";
            this.dgvList.Order = false;
            this.dgvList.OrderCol = false;
            this.dgvList.Size = new System.Drawing.Size(806, 332);
            this.dgvList.SizeFile = null;
            this.dgvList.TabIndex = 7;
            this.dgvList.TextFile = "";
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(185, 5);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay.TabIndex = 8;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // txtMonth
            // 
            this.txtMonth.Location = new System.Drawing.Point(79, 5);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(100, 20);
            this.txtMonth.TabIndex = 9;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Red;
            this.lblMessage.Location = new System.Drawing.Point(267, 11);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Month Ago:";
            // 
            // frmCompareGoldVN_World
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 364);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.btnDisplay);
            this.Controls.Add(this.dgvList);
            this.Name = "frmCompareGoldVN_World";
            this.Text = "frmCompareGoldVN_World";
            this.Load += new System.EventHandler(this.frmCompareGoldVN_World_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PagingGridControl.ctrlPagingGrid dgvList;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label1;
    }
}