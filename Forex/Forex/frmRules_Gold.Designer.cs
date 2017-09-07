namespace Forex
{
    partial class frmRules_Gold
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
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
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
            this.dgvList.Location = new System.Drawing.Point(1, 33);
            this.dgvList.Name = "dgvList";
            this.dgvList.Order = false;
            this.dgvList.OrderCol = false;
            this.dgvList.Size = new System.Drawing.Size(767, 313);
            this.dgvList.SizeFile = null;
            this.dgvList.TabIndex = 6;
            this.dgvList.TextFile = "";
            // 
            // dtFrom
            // 
            this.dtFrom.CustomFormat = "dd/MM/yyyy";
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrom.Location = new System.Drawing.Point(12, 7);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(88, 20);
            this.dtFrom.TabIndex = 7;
            // 
            // dtTo
            // 
            this.dtTo.CustomFormat = "dd/MM/yyyy";
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTo.Location = new System.Drawing.Point(117, 7);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(88, 20);
            this.dtTo.TabIndex = 8;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(212, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Run";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmRules_Gold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 350);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.dgvList);
            this.Name = "frmRules_Gold";
            this.Text = "frmRules_Gold";
            this.Load += new System.EventHandler(this.frmRules_Gold_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private PagingGridControl.ctrlPagingGrid dgvList;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnOK;
    }
}