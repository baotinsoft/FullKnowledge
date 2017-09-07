namespace Forex
{
    partial class frmGold
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
            this.cboYears = new System.Windows.Forms.ComboBox();
            this.cboMonths = new System.Windows.Forms.ComboBox();
            this.cboDays = new System.Windows.Forms.ComboBox();
            this.btnDisplayNear = new System.Windows.Forms.Button();
            this.dgvWeekDay = new PagingGridControl.ctrlPagingGrid();
            this.dgvMonth = new PagingGridControl.ctrlPagingGrid();
            this.dgvMonthYear = new PagingGridControl.ctrlPagingGrid();
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
            this.dgvDisplay.Location = new System.Drawing.Point(0, 30);
            this.dgvDisplay.Name = "dgvDisplay";
            this.dgvDisplay.Order = false;
            this.dgvDisplay.OrderCol = false;
            this.dgvDisplay.Size = new System.Drawing.Size(464, 255);
            this.dgvDisplay.SizeFile = null;
            this.dgvDisplay.TabIndex = 6;
            this.dgvDisplay.TextFile = "";
            // 
            // cboYears
            // 
            this.cboYears.FormattingEnabled = true;
            this.cboYears.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboYears.Location = new System.Drawing.Point(158, 3);
            this.cboYears.Name = "cboYears";
            this.cboYears.Size = new System.Drawing.Size(72, 21);
            this.cboYears.TabIndex = 11;
            this.cboYears.Text = "0";
            // 
            // cboMonths
            // 
            this.cboMonths.FormattingEnabled = true;
            this.cboMonths.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboMonths.Location = new System.Drawing.Point(80, 3);
            this.cboMonths.Name = "cboMonths";
            this.cboMonths.Size = new System.Drawing.Size(72, 21);
            this.cboMonths.TabIndex = 10;
            this.cboMonths.Text = "0";
            // 
            // cboDays
            // 
            this.cboDays.FormattingEnabled = true;
            this.cboDays.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboDays.Location = new System.Drawing.Point(2, 3);
            this.cboDays.Name = "cboDays";
            this.cboDays.Size = new System.Drawing.Size(72, 21);
            this.cboDays.TabIndex = 9;
            this.cboDays.Text = "3";
            // 
            // btnDisplayNear
            // 
            this.btnDisplayNear.Location = new System.Drawing.Point(247, 1);
            this.btnDisplayNear.Name = "btnDisplayNear";
            this.btnDisplayNear.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayNear.TabIndex = 8;
            this.btnDisplayNear.Text = "Display";
            this.btnDisplayNear.UseVisualStyleBackColor = true;
            this.btnDisplayNear.Click += new System.EventHandler(this.btnDisplayNear_Click);
            // 
            // dgvWeekDay
            // 
            this.dgvWeekDay.AddEnable = true;
            this.dgvWeekDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvWeekDay.Check = true;
            this.dgvWeekDay.DeleteEnable = true;
            this.dgvWeekDay.ExportEnable = false;
            this.dgvWeekDay.Filter = false;
            this.dgvWeekDay.FontSize = 0F;
            this.dgvWeekDay.HideId = true;
            this.dgvWeekDay.Insert = false;
            this.dgvWeekDay.ItemperPage = 10;
            this.dgvWeekDay.Location = new System.Drawing.Point(0, 291);
            this.dgvWeekDay.Name = "dgvWeekDay";
            this.dgvWeekDay.Order = false;
            this.dgvWeekDay.OrderCol = false;
            this.dgvWeekDay.Size = new System.Drawing.Size(464, 255);
            this.dgvWeekDay.SizeFile = null;
            this.dgvWeekDay.TabIndex = 14;
            this.dgvWeekDay.TextFile = "";
            // 
            // dgvMonth
            // 
            this.dgvMonth.AddEnable = true;
            this.dgvMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMonth.Check = true;
            this.dgvMonth.DeleteEnable = true;
            this.dgvMonth.ExportEnable = false;
            this.dgvMonth.Filter = false;
            this.dgvMonth.FontSize = 0F;
            this.dgvMonth.HideId = true;
            this.dgvMonth.Insert = false;
            this.dgvMonth.ItemperPage = 12;
            this.dgvMonth.Location = new System.Drawing.Point(470, 291);
            this.dgvMonth.Name = "dgvMonth";
            this.dgvMonth.Order = false;
            this.dgvMonth.OrderCol = false;
            this.dgvMonth.Size = new System.Drawing.Size(429, 255);
            this.dgvMonth.SizeFile = null;
            this.dgvMonth.TabIndex = 13;
            this.dgvMonth.TextFile = "";
            // 
            // dgvMonthYear
            // 
            this.dgvMonthYear.AddEnable = true;
            this.dgvMonthYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvMonthYear.Check = true;
            this.dgvMonthYear.DeleteEnable = true;
            this.dgvMonthYear.ExportEnable = false;
            this.dgvMonthYear.Filter = false;
            this.dgvMonthYear.FontSize = 0F;
            this.dgvMonthYear.HideId = true;
            this.dgvMonthYear.Insert = false;
            this.dgvMonthYear.ItemperPage = 10;
            this.dgvMonthYear.Location = new System.Drawing.Point(470, 30);
            this.dgvMonthYear.Name = "dgvMonthYear";
            this.dgvMonthYear.Order = false;
            this.dgvMonthYear.OrderCol = false;
            this.dgvMonthYear.Size = new System.Drawing.Size(429, 255);
            this.dgvMonthYear.SizeFile = null;
            this.dgvMonthYear.TabIndex = 12;
            this.dgvMonthYear.TextFile = "";
            // 
            // frmGold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 337);
            this.Controls.Add(this.dgvWeekDay);
            this.Controls.Add(this.dgvMonth);
            this.Controls.Add(this.dgvMonthYear);
            this.Controls.Add(this.cboYears);
            this.Controls.Add(this.cboMonths);
            this.Controls.Add(this.cboDays);
            this.Controls.Add(this.btnDisplayNear);
            this.Controls.Add(this.dgvDisplay);
            this.Name = "frmGold";
            this.Text = "World Gold";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGold_Load);
            this.Resize += new System.EventHandler(this.frmGold_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private PagingGridControl.ctrlPagingGrid dgvDisplay;
        private System.Windows.Forms.ComboBox cboYears;
        private System.Windows.Forms.ComboBox cboMonths;
        private System.Windows.Forms.ComboBox cboDays;
        private System.Windows.Forms.Button btnDisplayNear;
        private PagingGridControl.ctrlPagingGrid dgvWeekDay;
        private PagingGridControl.ctrlPagingGrid dgvMonth;
        private PagingGridControl.ctrlPagingGrid dgvMonthYear;
    }
}