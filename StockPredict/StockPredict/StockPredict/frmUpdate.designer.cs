namespace StockPredict
{
    partial class frmUpdate
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
            this.btnQuit = new System.Windows.Forms.Button();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.cboStock = new System.Windows.Forms.ComboBox();
            this.btnOptimize = new System.Windows.Forms.Button();
            this.btnUpdateOne = new System.Windows.Forms.Button();
            this.odlgHisFile = new System.Windows.Forms.OpenFileDialog();
            this.btnUpdateAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkContinue = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(431, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 59);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Thoát";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // txtProgress
            // 
            this.txtProgress.Location = new System.Drawing.Point(3, 70);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProgress.Size = new System.Drawing.Size(503, 191);
            this.txtProgress.TabIndex = 12;
            // 
            // cboStock
            // 
            this.cboStock.FormattingEnabled = true;
            this.cboStock.Location = new System.Drawing.Point(123, 6);
            this.cboStock.Name = "cboStock";
            this.cboStock.Size = new System.Drawing.Size(295, 21);
            this.cboStock.TabIndex = 13;
            // 
            // btnOptimize
            // 
            this.btnOptimize.Location = new System.Drawing.Point(86, 40);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(97, 23);
            this.btnOptimize.TabIndex = 14;
            this.btnOptimize.Text = "Tối ưu tham số";
            this.btnOptimize.UseVisualStyleBackColor = true;
            this.btnOptimize.Click += new System.EventHandler(this.btnOptimize_Click);
            // 
            // btnUpdateOne
            // 
            this.btnUpdateOne.Location = new System.Drawing.Point(189, 41);
            this.btnUpdateOne.Name = "btnUpdateOne";
            this.btnUpdateOne.Size = new System.Drawing.Size(104, 23);
            this.btnUpdateOne.TabIndex = 15;
            this.btnUpdateOne.Text = "Cập nhật 1 giá trị";
            this.btnUpdateOne.UseVisualStyleBackColor = true;
            this.btnUpdateOne.Click += new System.EventHandler(this.btnUpdateOne_Click);
            // 
            // odlgHisFile
            // 
            this.odlgHisFile.FileName = "openFileDialog1";
            // 
            // btnUpdateAll
            // 
            this.btnUpdateAll.Location = new System.Drawing.Point(299, 41);
            this.btnUpdateAll.Name = "btnUpdateAll";
            this.btnUpdateAll.Size = new System.Drawing.Size(101, 23);
            this.btnUpdateAll.TabIndex = 16;
            this.btnUpdateAll.Text = "Cập nhật tất cả";
            this.btnUpdateAll.UseVisualStyleBackColor = true;
            this.btnUpdateAll.Click += new System.EventHandler(this.btnUpdateAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Chọn chứng khoán:";
            // 
            // chkContinue
            // 
            this.chkContinue.AutoSize = true;
            this.chkContinue.Location = new System.Drawing.Point(15, 45);
            this.chkContinue.Name = "chkContinue";
            this.chkContinue.Size = new System.Drawing.Size(65, 17);
            this.chkContinue.TabIndex = 18;
            this.chkContinue.Text = "Tiếp tục";
            this.chkContinue.UseVisualStyleBackColor = true;
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 273);
            this.Controls.Add(this.chkContinue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdateAll);
            this.Controls.Add(this.btnUpdateOne);
            this.Controls.Add(this.btnOptimize);
            this.Controls.Add(this.cboStock);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.btnQuit);
            this.MaximizeBox = false;
            this.Name = "frmUpdate";
            this.Text = "Cap Nhat Mo Hinh";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuit;
        public System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.ComboBox cboStock;
        private System.Windows.Forms.Button btnOptimize;
        private System.Windows.Forms.Button btnUpdateOne;
        private System.Windows.Forms.OpenFileDialog odlgHisFile;
        private System.Windows.Forms.Button btnUpdateAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkContinue;
    }
}

