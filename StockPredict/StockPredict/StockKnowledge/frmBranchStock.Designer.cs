namespace StockKnowledge
{
    partial class frmBranchStock
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
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.btnAutoUpdate = new System.Windows.Forms.Button();
            this.btnBranchFind = new System.Windows.Forms.Button();
            this.btnAutoUpdateStock = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(2, 184);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(773, 301);
            this.dgvList.TabIndex = 5;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(83, 155);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Branch Save";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(181, 155);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 23);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Branch Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(2, 155);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvStock
            // 
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Location = new System.Drawing.Point(781, 184);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.Size = new System.Drawing.Size(554, 301);
            this.dgvStock.TabIndex = 22;
            // 
            // btnAutoUpdate
            // 
            this.btnAutoUpdate.Location = new System.Drawing.Point(287, 155);
            this.btnAutoUpdate.Name = "btnAutoUpdate";
            this.btnAutoUpdate.Size = new System.Drawing.Size(124, 23);
            this.btnAutoUpdate.TabIndex = 23;
            this.btnAutoUpdate.Text = "Auto Update Branch";
            this.btnAutoUpdate.UseVisualStyleBackColor = true;
            this.btnAutoUpdate.Click += new System.EventHandler(this.btnAutoUpdate_Click);
            // 
            // btnBranchFind
            // 
            this.btnBranchFind.Location = new System.Drawing.Point(418, 155);
            this.btnBranchFind.Name = "btnBranchFind";
            this.btnBranchFind.Size = new System.Drawing.Size(75, 23);
            this.btnBranchFind.TabIndex = 24;
            this.btnBranchFind.Text = "Branch Find";
            this.btnBranchFind.UseVisualStyleBackColor = true;
            this.btnBranchFind.Click += new System.EventHandler(this.btnBranchFind_Click);
            // 
            // btnAutoUpdateStock
            // 
            this.btnAutoUpdateStock.Location = new System.Drawing.Point(499, 155);
            this.btnAutoUpdateStock.Name = "btnAutoUpdateStock";
            this.btnAutoUpdateStock.Size = new System.Drawing.Size(112, 23);
            this.btnAutoUpdateStock.TabIndex = 25;
            this.btnAutoUpdateStock.Text = "Auto Update Stock";
            this.btnAutoUpdateStock.UseVisualStyleBackColor = true;
            this.btnAutoUpdateStock.Click += new System.EventHandler(this.btnAutoUpdateStock_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(617, 160);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(40, 13);
            this.lblMsg.TabIndex = 26;
            this.lblMsg.Text = "Status:";
            // 
            // frmBranchStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 493);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnAutoUpdateStock);
            this.Controls.Add(this.btnBranchFind);
            this.Controls.Add(this.btnAutoUpdate);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.dgvList);
            this.Name = "frmBranchStock";
            this.Text = "Branch - Stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDefinition_Load);
            this.SizeChanged += new System.EventHandler(this.frmDefinition_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.Button btnAutoUpdate;
        private System.Windows.Forms.Button btnBranchFind;
        private System.Windows.Forms.Button btnAutoUpdateStock;
        private System.Windows.Forms.Label lblMsg;
    }
}