namespace Forex
{
    partial class frmRate
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
            this.cboForex = new System.Windows.Forms.ComboBox();
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
            this.dgvList.Location = new System.Drawing.Point(3, 36);
            this.dgvList.Name = "dgvList";
            this.dgvList.Order = false;
            this.dgvList.OrderCol = false;
            this.dgvList.Size = new System.Drawing.Size(741, 377);
            this.dgvList.SizeFile = null;
            this.dgvList.TabIndex = 7;
            this.dgvList.TextFile = "";
            // 
            // cboForex
            // 
            this.cboForex.FormattingEnabled = true;
            this.cboForex.Location = new System.Drawing.Point(3, 9);
            this.cboForex.Name = "cboForex";
            this.cboForex.Size = new System.Drawing.Size(159, 21);
            this.cboForex.TabIndex = 8;
            this.cboForex.SelectedIndexChanged += new System.EventHandler(this.cboForex_SelectedIndexChanged);
            // 
            // frmRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 416);
            this.Controls.Add(this.cboForex);
            this.Controls.Add(this.dgvList);
            this.Name = "frmRate";
            this.Text = "frmRate";
            this.Load += new System.EventHandler(this.frmRate_Load);
            this.Resize += new System.EventHandler(this.frmRate_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private PagingGridControl.ctrlPagingGrid dgvList;
        private System.Windows.Forms.ComboBox cboForex;
    }
}