namespace Knowledge
{
    partial class frmSettings
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
            this.grpVoice = new System.Windows.Forms.GroupBox();
            this.barRate = new System.Windows.Forms.TrackBar();
            this.barVolumn = new System.Windows.Forms.TrackBar();
            this.lblResult = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPreviewVoice = new System.Windows.Forms.Button();
            this.cboVoice = new System.Windows.Forms.ComboBox();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btnLoad = new System.Windows.Forms.Button();
            this.grpVoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barVolumn)).BeginInit();
            this.SuspendLayout();
            // 
            // grpVoice
            // 
            this.grpVoice.Controls.Add(this.btnLoad);
            this.grpVoice.Controls.Add(this.btnBrowse);
            this.grpVoice.Controls.Add(this.label4);
            this.grpVoice.Controls.Add(this.txtFolder);
            this.grpVoice.Controls.Add(this.barRate);
            this.grpVoice.Controls.Add(this.barVolumn);
            this.grpVoice.Controls.Add(this.lblResult);
            this.grpVoice.Controls.Add(this.label3);
            this.grpVoice.Controls.Add(this.label2);
            this.grpVoice.Controls.Add(this.label1);
            this.grpVoice.Controls.Add(this.btnSave);
            this.grpVoice.Controls.Add(this.btnPreviewVoice);
            this.grpVoice.Controls.Add(this.cboVoice);
            this.grpVoice.Location = new System.Drawing.Point(13, 13);
            this.grpVoice.Name = "grpVoice";
            this.grpVoice.Size = new System.Drawing.Size(384, 287);
            this.grpVoice.TabIndex = 0;
            this.grpVoice.TabStop = false;
            this.grpVoice.Text = "Voice";
            // 
            // barRate
            // 
            this.barRate.Location = new System.Drawing.Point(84, 124);
            this.barRate.Name = "barRate";
            this.barRate.Size = new System.Drawing.Size(294, 45);
            this.barRate.TabIndex = 11;
            // 
            // barVolumn
            // 
            this.barVolumn.Location = new System.Drawing.Point(84, 37);
            this.barVolumn.Name = "barVolumn";
            this.barVolumn.Size = new System.Drawing.Size(294, 45);
            this.barVolumn.SmallChange = 10;
            this.barVolumn.TabIndex = 10;
            this.barVolumn.TickFrequency = 10;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(7, 16);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(82, 13);
            this.lblResult.TabIndex = 9;
            this.lblResult.Text = "Selected Voice:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Voice:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Volumn:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(152, 238);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPreviewVoice
            // 
            this.btnPreviewVoice.Location = new System.Drawing.Point(252, 238);
            this.btnPreviewVoice.Name = "btnPreviewVoice";
            this.btnPreviewVoice.Size = new System.Drawing.Size(94, 23);
            this.btnPreviewVoice.TabIndex = 4;
            this.btnPreviewVoice.Text = "Preview Voice";
            this.btnPreviewVoice.UseVisualStyleBackColor = true;
            this.btnPreviewVoice.Click += new System.EventHandler(this.btnPreviewVoice_Click);
            // 
            // cboVoice
            // 
            this.cboVoice.FormattingEnabled = true;
            this.cboVoice.Location = new System.Drawing.Point(84, 88);
            this.cboVoice.Name = "cboVoice";
            this.cboVoice.Size = new System.Drawing.Size(121, 21);
            this.cboVoice.TabIndex = 2;
            this.cboVoice.SelectedIndexChanged += new System.EventHandler(this.cboVoice_SelectedIndexChanged);
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(84, 182);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(240, 20);
            this.txtFolder.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Output Folder:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(330, 179);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(48, 23);
            this.btnBrowse.TabIndex = 14;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(54, 238);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 23);
            this.btnLoad.TabIndex = 15;
            this.btnLoad.Text = "Load Settings";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 367);
            this.Controls.Add(this.grpVoice);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.grpVoice.ResumeLayout(false);
            this.grpVoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barVolumn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpVoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPreviewVoice;
        private System.Windows.Forms.ComboBox cboVoice;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TrackBar barRate;
        private System.Windows.Forms.TrackBar barVolumn;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.FolderBrowserDialog dlgFolder;
        private System.Windows.Forms.Button btnLoad;
    }
}