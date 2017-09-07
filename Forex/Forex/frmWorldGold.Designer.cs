namespace GetHistoricalData
{
    partial class frmWorldGold
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
            this.dgvDisplay = new PagingGridControl.ctrlPagingGrid();
            this.SuspendLayout();
            // 
            // dgvDisplay
            // 
            this.dgvDisplay.AddEnable = true;
            this.dgvDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDisplay.Check = true;
            this.dgvDisplay.DeleteEnable = true;
            this.dgvDisplay.ExportEnable = false;
            this.dgvDisplay.Filter = false;
            this.dgvDisplay.FontSize = 0F;
            this.dgvDisplay.HideId = true;
            this.dgvDisplay.Insert = false;
            this.dgvDisplay.ItemperPage = 10;
            this.dgvDisplay.Location = new System.Drawing.Point(0, -1);
            this.dgvDisplay.Name = "dgvDisplay";
            this.dgvDisplay.Order = false;
            this.dgvDisplay.OrderCol = false;
            this.dgvDisplay.Size = new System.Drawing.Size(464, 255);
            this.dgvDisplay.SizeFile = null;
            this.dgvDisplay.TabIndex = 6;
            this.dgvDisplay.TextFile = "";
            // 
            // frmWorldGold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 405);
            this.Controls.Add(this.dgvDisplay);
            this.Name = "frmWorldGold";
            this.Text = "frmWorldGold";
            this.ResumeLayout(false);

        }

        #endregion

        private PagingGridControl.ctrlPagingGrid dgvDisplay;
    }
}