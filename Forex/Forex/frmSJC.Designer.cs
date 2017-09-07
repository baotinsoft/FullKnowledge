namespace Forex
{
    partial class frmSJC
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
            this.dgvMonthYear = new PagingGridControl.ctrlPagingGrid();
            this.dgvMonth = new PagingGridControl.ctrlPagingGrid();
            this.btnDisplayNear = new System.Windows.Forms.Button();
            this.cboDays = new System.Windows.Forms.ComboBox();
            this.dgvDisplay = new PagingGridControl.ctrlPagingGrid();
            this.cboMonths = new System.Windows.Forms.ComboBox();
            this.cboYears = new System.Windows.Forms.ComboBox();
            this.dgvWeekDay = new PagingGridControl.ctrlPagingGrid();
            this.btnCalc = new System.Windows.Forms.Button();
            this.txtQuan = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtComparePrice = new System.Windows.Forms.TextBox();
            this.btnGold = new System.Windows.Forms.Button();
            this.btnUSDRate = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuRules = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRulesGold = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewRule = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompareGoldPrice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNews = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewsDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewsNew = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGet = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.dgvMonthYear.ImportEnable = false;
            this.dgvMonthYear.Insert = false;
            this.dgvMonthYear.ItemperPage = 10;
            this.dgvMonthYear.Location = new System.Drawing.Point(470, 56);
            this.dgvMonthYear.Name = "dgvMonthYear";
            this.dgvMonthYear.Order = false;
            this.dgvMonthYear.OrderCol = false;
            this.dgvMonthYear.Size = new System.Drawing.Size(525, 255);
            this.dgvMonthYear.SizeFile = null;
            this.dgvMonthYear.TabIndex = 1;
            this.dgvMonthYear.TextFile = "";
            this.dgvMonthYear.MouseHover += new System.EventHandler(this.dgvMonthYear_MouseHover);
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
            this.dgvMonth.ImportEnable = false;
            this.dgvMonth.Insert = false;
            this.dgvMonth.ItemperPage = 12;
            this.dgvMonth.Location = new System.Drawing.Point(470, 317);
            this.dgvMonth.Name = "dgvMonth";
            this.dgvMonth.Order = false;
            this.dgvMonth.OrderCol = false;
            this.dgvMonth.Size = new System.Drawing.Size(525, 255);
            this.dgvMonth.SizeFile = null;
            this.dgvMonth.TabIndex = 2;
            this.dgvMonth.TextFile = "";
            this.dgvMonth.Load += new System.EventHandler(this.dgvMonth_Load);
            // 
            // btnDisplayNear
            // 
            this.btnDisplayNear.Location = new System.Drawing.Point(234, 27);
            this.btnDisplayNear.Name = "btnDisplayNear";
            this.btnDisplayNear.Size = new System.Drawing.Size(59, 23);
            this.btnDisplayNear.TabIndex = 3;
            this.btnDisplayNear.Text = "Display";
            this.btnDisplayNear.UseVisualStyleBackColor = true;
            this.btnDisplayNear.Click += new System.EventHandler(this.btnDisplayNear_Click);
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
            this.cboDays.Location = new System.Drawing.Point(0, 29);
            this.cboDays.Name = "cboDays";
            this.cboDays.Size = new System.Drawing.Size(72, 21);
            this.cboDays.TabIndex = 4;
            this.cboDays.Text = "20";
            this.cboDays.SelectedIndexChanged += new System.EventHandler(this.cboDays_SelectedIndexChanged);
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
            this.dgvDisplay.ImportEnable = false;
            this.dgvDisplay.Insert = false;
            this.dgvDisplay.ItemperPage = 10;
            this.dgvDisplay.Location = new System.Drawing.Point(0, 56);
            this.dgvDisplay.Name = "dgvDisplay";
            this.dgvDisplay.Order = false;
            this.dgvDisplay.OrderCol = false;
            this.dgvDisplay.Size = new System.Drawing.Size(464, 255);
            this.dgvDisplay.SizeFile = null;
            this.dgvDisplay.TabIndex = 5;
            this.dgvDisplay.TextFile = "";
            this.dgvDisplay.CellClick += new PagingGridControl.ctrlPagingGrid.customCellClick(this.dgvDisplay_CellClick);
            this.dgvDisplay.MouseHover += new System.EventHandler(this.dgvDisplay_MouseHover);
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
            this.cboMonths.Location = new System.Drawing.Point(78, 29);
            this.cboMonths.Name = "cboMonths";
            this.cboMonths.Size = new System.Drawing.Size(72, 21);
            this.cboMonths.TabIndex = 6;
            this.cboMonths.Text = "0";
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
            this.cboYears.Location = new System.Drawing.Point(156, 29);
            this.cboYears.Name = "cboYears";
            this.cboYears.Size = new System.Drawing.Size(72, 21);
            this.cboYears.TabIndex = 7;
            this.cboYears.Text = "0";
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
            this.dgvWeekDay.ImportEnable = false;
            this.dgvWeekDay.Insert = false;
            this.dgvWeekDay.ItemperPage = 10;
            this.dgvWeekDay.Location = new System.Drawing.Point(0, 317);
            this.dgvWeekDay.Name = "dgvWeekDay";
            this.dgvWeekDay.Order = false;
            this.dgvWeekDay.OrderCol = false;
            this.dgvWeekDay.Size = new System.Drawing.Size(464, 255);
            this.dgvWeekDay.SizeFile = null;
            this.dgvWeekDay.TabIndex = 8;
            this.dgvWeekDay.TextFile = "";
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(758, 29);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 9;
            this.btnCalc.Text = "Calculator";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // txtQuan
            // 
            this.txtQuan.Location = new System.Drawing.Point(364, 27);
            this.txtQuan.Name = "txtQuan";
            this.txtQuan.Size = new System.Drawing.Size(85, 20);
            this.txtQuan.TabIndex = 10;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(455, 27);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(85, 20);
            this.txtPrice.TabIndex = 11;
            // 
            // txtResult
            // 
            this.txtResult.Enabled = false;
            this.txtResult.Location = new System.Drawing.Point(652, 27);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 20);
            this.txtResult.TabIndex = 12;
            // 
            // txtComparePrice
            // 
            this.txtComparePrice.Location = new System.Drawing.Point(546, 27);
            this.txtComparePrice.Name = "txtComparePrice";
            this.txtComparePrice.Size = new System.Drawing.Size(85, 20);
            this.txtComparePrice.TabIndex = 13;
            // 
            // btnGold
            // 
            this.btnGold.Location = new System.Drawing.Point(839, 29);
            this.btnGold.Name = "btnGold";
            this.btnGold.Size = new System.Drawing.Size(75, 23);
            this.btnGold.TabIndex = 14;
            this.btnGold.Text = "Gold";
            this.btnGold.UseVisualStyleBackColor = true;
            this.btnGold.Click += new System.EventHandler(this.btnGold_Click);
            // 
            // btnUSDRate
            // 
            this.btnUSDRate.Location = new System.Drawing.Point(920, 27);
            this.btnUSDRate.Name = "btnUSDRate";
            this.btnUSDRate.Size = new System.Drawing.Size(75, 23);
            this.btnUSDRate.TabIndex = 15;
            this.btnUSDRate.Text = "USD Rate";
            this.btnUSDRate.UseVisualStyleBackColor = true;
            this.btnUSDRate.Click += new System.EventHandler(this.btnUSDRate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRules,
            this.mnuNews});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1002, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuRules
            // 
            this.mnuRules.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRulesGold,
            this.mnuNewRule,
            this.mnuCompareGoldPrice});
            this.mnuRules.Name = "mnuRules";
            this.mnuRules.Size = new System.Drawing.Size(47, 20);
            this.mnuRules.Text = "Rules";
            // 
            // mnuRulesGold
            // 
            this.mnuRulesGold.Name = "mnuRulesGold";
            this.mnuRulesGold.Size = new System.Drawing.Size(180, 22);
            this.mnuRulesGold.Text = "Gold";
            this.mnuRulesGold.Click += new System.EventHandler(this.mnuRulesGold_Click);
            // 
            // mnuNewRule
            // 
            this.mnuNewRule.Name = "mnuNewRule";
            this.mnuNewRule.Size = new System.Drawing.Size(180, 22);
            this.mnuNewRule.Text = "New Rule";
            this.mnuNewRule.Click += new System.EventHandler(this.mnuNewRule_Click);
            // 
            // mnuCompareGoldPrice
            // 
            this.mnuCompareGoldPrice.Name = "mnuCompareGoldPrice";
            this.mnuCompareGoldPrice.Size = new System.Drawing.Size(180, 22);
            this.mnuCompareGoldPrice.Text = "Compare Gold Price";
            this.mnuCompareGoldPrice.Click += new System.EventHandler(this.mnuCompareGoldPrice_Click);
            // 
            // mnuNews
            // 
            this.mnuNews.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewsDisplay,
            this.mnuNewsNew});
            this.mnuNews.Name = "mnuNews";
            this.mnuNews.Size = new System.Drawing.Size(48, 20);
            this.mnuNews.Text = "News";
            // 
            // mnuNewsDisplay
            // 
            this.mnuNewsDisplay.Name = "mnuNewsDisplay";
            this.mnuNewsDisplay.Size = new System.Drawing.Size(130, 22);
            this.mnuNewsDisplay.Text = "Display";
            this.mnuNewsDisplay.Click += new System.EventHandler(this.mnuNewsDisplay_Click);
            // 
            // mnuNewsNew
            // 
            this.mnuNewsNew.Name = "mnuNewsNew";
            this.mnuNewsNew.Size = new System.Drawing.Size(130, 22);
            this.mnuNewsNew.Text = "New News";
            this.mnuNewsNew.Click += new System.EventHandler(this.mnuNewsNew_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(299, 27);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(52, 23);
            this.btnGet.TabIndex = 17;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // frmSJC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 562);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnUSDRate);
            this.Controls.Add(this.btnGold);
            this.Controls.Add(this.txtComparePrice);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtQuan);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.dgvWeekDay);
            this.Controls.Add(this.cboYears);
            this.Controls.Add(this.cboMonths);
            this.Controls.Add(this.dgvDisplay);
            this.Controls.Add(this.cboDays);
            this.Controls.Add(this.btnDisplayNear);
            this.Controls.Add(this.dgvMonth);
            this.Controls.Add(this.dgvMonthYear);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmSJC";
            this.Text = "SJC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGet_Load);
            this.SizeChanged += new System.EventHandler(this.frmGold_SizeChanged);
            this.Resize += new System.EventHandler(this.frmSJC_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PagingGridControl.ctrlPagingGrid dgvMonthYear;
        private PagingGridControl.ctrlPagingGrid dgvMonth;
        private System.Windows.Forms.Button btnDisplayNear;
        private System.Windows.Forms.ComboBox cboDays;
        private PagingGridControl.ctrlPagingGrid dgvDisplay;
        private System.Windows.Forms.ComboBox cboMonths;
        private System.Windows.Forms.ComboBox cboYears;
        private PagingGridControl.ctrlPagingGrid dgvWeekDay;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TextBox txtQuan;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtComparePrice;
        private System.Windows.Forms.Button btnGold;
        private System.Windows.Forms.Button btnUSDRate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuRules;
        private System.Windows.Forms.ToolStripMenuItem mnuRulesGold;
        private System.Windows.Forms.ToolStripMenuItem mnuNewRule;
        private System.Windows.Forms.ToolStripMenuItem mnuNews;
        private System.Windows.Forms.ToolStripMenuItem mnuNewsDisplay;
        private System.Windows.Forms.ToolStripMenuItem mnuNewsNew;
        private System.Windows.Forms.ToolStripMenuItem mnuCompareGoldPrice;
        private System.Windows.Forms.Button btnGet;
    }
}

