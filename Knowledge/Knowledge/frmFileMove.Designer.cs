namespace Knowledge
{
    partial class frmFileMove
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
            this.btnOneType = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFromDir = new System.Windows.Forms.TextBox();
            this.frmAllTypes = new System.Windows.Forms.Button();
            this.txtToDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUpdateAllTypes = new System.Windows.Forms.Button();
            this.btnUpdateOneType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOneType
            // 
            this.btnOneType.Location = new System.Drawing.Point(15, 119);
            this.btnOneType.Name = "btnOneType";
            this.btnOneType.Size = new System.Drawing.Size(104, 23);
            this.btnOneType.TabIndex = 0;
            this.btnOneType.Text = "Di chuyển một loại";
            this.btnOneType.UseVisualStyleBackColor = true;
            this.btnOneType.Click += new System.EventHandler(this.btnOneType_Click);
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(106, 12);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(450, 21);
            this.cboType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Loại Ebook:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Từ Thư Mục:";
            // 
            // txtFromDir
            // 
            this.txtFromDir.Location = new System.Drawing.Point(106, 51);
            this.txtFromDir.Name = "txtFromDir";
            this.txtFromDir.Size = new System.Drawing.Size(450, 20);
            this.txtFromDir.TabIndex = 4;
            this.txtFromDir.Text = "D:\\Ebooks";
            // 
            // frmAllTypes
            // 
            this.frmAllTypes.Location = new System.Drawing.Point(135, 119);
            this.frmAllTypes.Name = "frmAllTypes";
            this.frmAllTypes.Size = new System.Drawing.Size(144, 23);
            this.frmAllTypes.TabIndex = 5;
            this.frmAllTypes.Text = "Di chuyển tất cả loại";
            this.frmAllTypes.UseVisualStyleBackColor = true;
            this.frmAllTypes.Click += new System.EventHandler(this.frmAllTypes_Click);
            // 
            // txtToDir
            // 
            this.txtToDir.Location = new System.Drawing.Point(106, 88);
            this.txtToDir.Name = "txtToDir";
            this.txtToDir.Size = new System.Drawing.Size(450, 20);
            this.txtToDir.TabIndex = 7;
            this.txtToDir.Text = "D:\\Ebooks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đến Thư Mục:";
            // 
            // btnUpdateAllTypes
            // 
            this.btnUpdateAllTypes.Location = new System.Drawing.Point(409, 119);
            this.btnUpdateAllTypes.Name = "btnUpdateAllTypes";
            this.btnUpdateAllTypes.Size = new System.Drawing.Size(144, 23);
            this.btnUpdateAllTypes.TabIndex = 9;
            this.btnUpdateAllTypes.Text = "Cập nhật tất cả loại";
            this.btnUpdateAllTypes.UseVisualStyleBackColor = true;
            this.btnUpdateAllTypes.Click += new System.EventHandler(this.btnUpdateAllTypes_Click);
            // 
            // btnUpdateOneType
            // 
            this.btnUpdateOneType.Location = new System.Drawing.Point(289, 119);
            this.btnUpdateOneType.Name = "btnUpdateOneType";
            this.btnUpdateOneType.Size = new System.Drawing.Size(104, 23);
            this.btnUpdateOneType.TabIndex = 8;
            this.btnUpdateOneType.Text = "Cập nhật một loại";
            this.btnUpdateOneType.UseVisualStyleBackColor = true;
            this.btnUpdateOneType.Click += new System.EventHandler(this.btnUpdateOneType_Click);
            // 
            // frmFileMove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 154);
            this.Controls.Add(this.btnUpdateAllTypes);
            this.Controls.Add(this.btnUpdateOneType);
            this.Controls.Add(this.txtToDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.frmAllTypes);
            this.Controls.Add(this.txtFromDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.btnOneType);
            this.Name = "frmFileMove";
            this.Text = "frmFileMove";
            this.Load += new System.EventHandler(this.frmOneType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOneType;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFromDir;
        private System.Windows.Forms.Button frmAllTypes;
        private System.Windows.Forms.TextBox txtToDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdateAllTypes;
        private System.Windows.Forms.Button btnUpdateOneType;
    }
}