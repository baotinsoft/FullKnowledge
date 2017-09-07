namespace Knowledge
{
    partial class frmSpeech
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
            this.btnSpeak = new System.Windows.Forms.Button();
            this.cboVoice = new System.Windows.Forms.ComboBox();
            this.txtSpeak = new System.Windows.Forms.TextBox();
            this.trVolume = new System.Windows.Forms.TrackBar();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.trRate = new System.Windows.Forms.TrackBar();
            this.btnCatchText = new System.Windows.Forms.Button();
            this.txtSentence = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.btnTalk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSpeak
            // 
            this.btnSpeak.Location = new System.Drawing.Point(97, 231);
            this.btnSpeak.Name = "btnSpeak";
            this.btnSpeak.Size = new System.Drawing.Size(75, 23);
            this.btnSpeak.TabIndex = 0;
            this.btnSpeak.Text = "Speak";
            this.btnSpeak.UseVisualStyleBackColor = true;
            this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
            // 
            // cboVoice
            // 
            this.cboVoice.FormattingEnabled = true;
            this.cboVoice.Location = new System.Drawing.Point(97, 2);
            this.cboVoice.Name = "cboVoice";
            this.cboVoice.Size = new System.Drawing.Size(279, 21);
            this.cboVoice.TabIndex = 1;
            // 
            // txtSpeak
            // 
            this.txtSpeak.Location = new System.Drawing.Point(108, 165);
            this.txtSpeak.Multiline = true;
            this.txtSpeak.Name = "txtSpeak";
            this.txtSpeak.Size = new System.Drawing.Size(268, 60);
            this.txtSpeak.TabIndex = 2;
            this.txtSpeak.Text = "anh yêu em rất nhiều";
            // 
            // trVolume
            // 
            this.trVolume.Location = new System.Drawing.Point(97, 40);
            this.trVolume.Maximum = 100;
            this.trVolume.Minimum = 10;
            this.trVolume.Name = "trVolume";
            this.trVolume.Size = new System.Drawing.Size(279, 45);
            this.trVolume.TabIndex = 6;
            this.trVolume.TickFrequency = 10;
            this.trVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trVolume.Value = 100;
            // 
            // SaveFileDialog1
            // 
            this.SaveFileDialog1.FileName = "MyVoice.wav";
            this.SaveFileDialog1.Filter = "Wave (*.wav)|*.wav";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(189, 231);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // trRate
            // 
            this.trRate.Location = new System.Drawing.Point(103, 114);
            this.trRate.Maximum = 100;
            this.trRate.Minimum = 10;
            this.trRate.Name = "trRate";
            this.trRate.Size = new System.Drawing.Size(279, 45);
            this.trRate.TabIndex = 8;
            this.trRate.TickFrequency = 10;
            this.trRate.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trRate.Value = 100;
            // 
            // btnCatchText
            // 
            this.btnCatchText.Location = new System.Drawing.Point(281, 231);
            this.btnCatchText.Name = "btnCatchText";
            this.btnCatchText.Size = new System.Drawing.Size(75, 23);
            this.btnCatchText.TabIndex = 9;
            this.btnCatchText.Text = "Catch Text";
            this.btnCatchText.UseVisualStyleBackColor = true;
            this.btnCatchText.Click += new System.EventHandler(this.btnCatchText_Click);
            // 
            // txtSentence
            // 
            this.txtSentence.Location = new System.Drawing.Point(395, 55);
            this.txtSentence.Name = "txtSentence";
            this.txtSentence.Size = new System.Drawing.Size(249, 20);
            this.txtSentence.TabIndex = 13;
            this.txtSentence.Text = "Xin mời bệnh nhân x tới phòng khám y";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(395, 29);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(100, 20);
            this.txtY.TabIndex = 12;
            this.txtY.Text = "01";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(395, 3);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(100, 20);
            this.txtX.TabIndex = 11;
            this.txtX.Text = "0001";
            // 
            // btnTalk
            // 
            this.btnTalk.Location = new System.Drawing.Point(514, 100);
            this.btnTalk.Name = "btnTalk";
            this.btnTalk.Size = new System.Drawing.Size(75, 23);
            this.btnTalk.TabIndex = 10;
            this.btnTalk.Text = "Speak";
            this.btnTalk.UseVisualStyleBackColor = true;
            this.btnTalk.Click += new System.EventHandler(this.btnTalk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Voice:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Volumn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Rate:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 273);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSentence);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.btnTalk);
            this.Controls.Add(this.btnCatchText);
            this.Controls.Add(this.trRate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.trVolume);
            this.Controls.Add(this.txtSpeak);
            this.Controls.Add(this.cboVoice);
            this.Controls.Add(this.btnSpeak);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSpeak;
        private System.Windows.Forms.ComboBox cboVoice;
        private System.Windows.Forms.TextBox txtSpeak;
        internal System.Windows.Forms.TrackBar trVolume;
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog1;
        private System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.TrackBar trRate;
        private System.Windows.Forms.Button btnCatchText;
        private System.Windows.Forms.TextBox txtSentence;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Button btnTalk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

