using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Knowledge.DBContext;
//using SpeechLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using WindowFramework;
using System.Drawing;

namespace Knowledge
{
    public partial class frmRead : Form
    {
        bool isSelect = false;
        PdfReader pReader;
        int pPage = 1, totalPage, id;
        decimal size;
        int type = 1; //1:books, 2:knowledge, 3:term
        DBKnowledge db = new DBKnowledge();
        string outputFolder, outputFile;
        string dirImage = @"D:\Data\Knowledge";

        public frmRead()
        {
            InitializeComponent();
        }

        public frmRead(int type)
        {
            InitializeComponent();
            this.type = type;

            List<Definition> lst = null;
            switch (type)
            {
                case 1: //Ebook
                    lblType.Text = "Ebook Type:";
                    cboLanguage.SelectedItem = 1002; //vn
                    lst = db.DefinitionList(4, "Select Type");
                    break;
                case 2: //Knowledge
                    lblType.Text = "Knowledge Type:";
                    lst = db.DefinitionList(5, "Select Type");
                    cboLanguage.SelectedItem = 1002; //vn
                    break;
                case 3: //Term
                    lblType.Text = "Term Type:";
                    lst = db.DefinitionList(5, "Select Type");
                    cboLanguage.SelectedItem = 1002; //vn
                    break;
                case 4: //Rules
                    lblType.Text = "Rule Type:";
                    lst = db.DefinitionList(5, "Select Type");
                    cboLanguage.SelectedItem = 1002; //vn
                    break;
            }

            cboType.Visible = true;
            lblType.Visible = true;
            cboType.DataSource = lst;
            cboType.ValueMember = "Id";
            cboType.DisplayMember = "Code";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dlgOpen.ShowDialog();
            txtFile.Text = dlgOpen.FileName;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            rtbContent.Text = "";
            rtbContent.Text = ParsePdf(txtFile.Text);
        }

        public string ParsePdf(string fileName)
        {
            if (!File.Exists(fileName)) return "Not found file: " + fileName;
                
            using (PdfReader reader = new PdfReader(fileName))
            {
                StringBuilder sb = new StringBuilder();

                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                totalPage = reader.NumberOfPages;
                FileInfo f = new FileInfo(fileName);
                size = f.Length;

                for (int page = 0; page < totalPage; page++)
                {
                    string text = PdfTextExtractor.GetTextFromPage(reader, page + 1, strategy);
                    if (text.Length > 0)
                    {
                        sb.Append(Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text))));
                    }
                }
                reader.Close();
                return sb.ToString();
            }            
        }

        public string ParsePdfPage(string fileName)
        {
            if (fileName.Length == 0) return "";
            if (fileName.Length > 0)
            {
                if (!File.Exists(fileName)) return "Not found file: " + fileName;

                pReader = new PdfReader(fileName);
                totalPage = pReader.NumberOfPages;
                FileInfo f = new FileInfo(fileName);
                size = f.Length;
            }
            StringBuilder sb = new StringBuilder();

            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            

            string text = PdfTextExtractor.GetTextFromPage(pReader, pPage, strategy);
            if (text.Length > 0)
            {
                sb.Append(Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(text))));
            }
            return sb.ToString();
        }

        SpeechSynthesizer synth;
        private void btnRead_Click(object sender, EventArgs e)
        {            
            if (btnRead.Text == "Read")
            {
                if (synth == null) synth = new SpeechSynthesizer();
                VoiceGender gender = chkIsMale.Checked ? VoiceGender.Male : VoiceGender.Female;
                string culture = "";
                //if (cboLanguage.Text == "English")
                //    culture = "Microsoft";
                //else
                //    culture = "NHMTTS Voice";
                //synth.SelectVoice(synth.GetInstalledVoices().Where(v => v.VoiceInfo.Name.Contains(culture) && v.VoiceInfo.Gender == gender).First().VoiceInfo.Name);

                if (cboLanguage.Text == "English")
                    culture = "en-US";
                else
                    culture = "vi-VN";

                if (!synth.Voice.Culture.Name.Contains(culture))
                    synth.SelectVoice(synth.GetInstalledVoices().Where(v => v.VoiceInfo.Culture.Name == culture && v.VoiceInfo.Gender == gender).First().VoiceInfo.Name);

                // Configure the audio output. 
                outputFile = outputFolder + @"\" + id + "_" + DateTime.Now.ToString().Replace('/', '_').Replace(':', '_') + ".wav";
                synth.SetOutputToWaveFile(outputFile);

                // Register for the SpeakCompleted event.
                synth.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(synth_SpeakCompleted);


                synth.SpeakAsync(txtTitle.Text + rtbContent.Text);
                btnRead.Text = "Stop";
            }
            else
            {
                btnRead.Text = "Read";
                synth.SpeakAsyncCancelAll();
            }
            //SpeechLib. oVoice = new SpeechLib();
            //SpVoice oVoice = new SpVoice();
            //SpFileStream cpFileStream = new SpFileStream();
            //if (cboLanguage.Text == "English")
            //    oVoice.Voice = oVoice.GetVoices().Item(2);
            //else
            //    oVoice.Voice = oVoice.GetVoices().Item(1);
            //oVoice.Volume = 100;
            //oVoice.Rate = 4;//4

            //oVoice.Speak(txtTitle.Text + rtbContent.Text, SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault);
        }

        // Handle the SpeakCompleted event.
        private void synth_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {

            // Create a SoundPlayer instance to play the output audio file.
            System.Media.SoundPlayer m_SoundPlayer =
              new System.Media.SoundPlayer(outputFile);

            //  Play the output file.
            m_SoundPlayer.Play();
        }

        private void LoadSettings()
        {
            LibIni.path = System.Windows.Forms.Application.StartupPath + @"\Settings.ini";
            try
            {
                synth.SelectVoice(LibIni.IniReadValue("Speech", "Voice"));
            }
            catch (Exception) { }
            try
            {
                synth.Rate = Convert.ToInt32(LibIni.IniReadValue("Speech", "Rate"));
            }
            catch (Exception) { }

            try
            {
                synth.Volume = Convert.ToInt32(LibIni.IniReadValue("Speech", "Volumn"));
            }
            catch (Exception) { }

            try
            {
                  LibIni.IniReadValue("Speech", "Folder");
            }
            catch (Exception) { }
        }

        private void frmReadEBook_SizeChanged(object sender, EventArgs e)
        {
            //txtTitle.Width = this.Width - txtTitle.Location.X - 20;
            dgvList.Height = this.Height - dgvList.Location.Y - 20;
            rtbContent.Width = this.Width - rtbContent.Location.X - 20;
            rtbContent.Height = this.Height - rtbContent.Location.Y - 20;
        }

        private void btnOpenPage_Click(object sender, EventArgs e)
        {
            rtbContent.Text = ParsePdfPage(txtFile.Text);
        }

        private void btnSaveBook_Click(object sender, EventArgs e)
        {
            frmBookSave frm = new frmBookSave();
            frm.file = txtFile.Text;
            frm.page = totalPage;
            frm.size = size;
            frm.languageId = Convert.ToInt32(cboLanguage.SelectedValue);
            frm.Show();
        }

        private void frmReadEBook_Load(object sender, EventArgs e)
        {
            List<Definition> lst = db.DefinitionList(2, "Select Language");
            cboLanguage.DataSource = lst;
            cboLanguage.ValueMember = "Id";
            cboLanguage.DisplayMember = "Code";

            pPage = Convert.ToInt32(txtPage.Text);

            switch(type)
            {
                case 1: //Ebook
                    dgvList.DataSource = db.EbookList();
                    break;
                case 2: //Knowledge
                    dgvList.DataSource = db.KnowledgeList(0, "");
                    break;
                case 3: //Term
                    dgvList.DataSource = db.TermList(0, "", "");
                    break;
                case 4: //Rules
                    dgvList.DataSource = db.RuleList(0, "");
                    break;
            }
            LoadSettings();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (!isSelect)
            {
                if (txtTitle.Text.Length > 4)
                    dgvList.DataSource = db.EbookList(txtTitle.Text, (int)cboType.SelectedValue, (int)cboLanguage.SelectedValue);
                else if (txtTitle.Text.Length == 0)
                    dgvList.DataSource = db.EbookList();
            }
            else if (txtTitle.Text.Length == 0) isSelect = false;
        }

        private void picShow_Click(object sender, EventArgs e)
        {
            if (picShow.Width < 200)
            {
                picShow.Width = picShow.Width * 4;
                picShow.Height = picShow.Height * 4;
            }
            else
            {
                picShow.Width = picShow.Width / 4;
                picShow.Height = picShow.Height / 4;

            }

        }

        private void lstFile_Click(object sender, EventArgs e)
        {
            if (lstFile.SelectedIndex > -1) picShow.Image = new Bitmap(lstFile.Items[lstFile.SelectedIndex].ToString());
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex > 0)
                switch (type)
                {
                    case 1: //Ebook
                        dgvList.DataSource = db.EbookList((int)cboType.SelectedValue);
                        break;
                    case 2: //Knowledge
                        dgvList.DataSource = db.KnowledgeList((int)cboType.SelectedValue, "");
                        break;
                    case 3: //Term
                        dgvList.DataSource = db.TermList((int)cboType.SelectedValue, "", "");
                        break;
                    case 4: //Rule
                        dgvList.DataSource = db.KnowledgeList((int)cboType.SelectedValue, "");
                        break;
                }

        }

        private void txtPage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pPage = Convert.ToInt32(txtPage.Text);
            }
            catch (Exception) { }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            isSelect = true;
            var row = dgvList.Rows[e.RowIndex].DataBoundItem;
            string dirSource = dirImage;
            switch (type)
            {
                case 1: //Ebook
                    vEbook obj = ((vEbook)row);
                    id = obj.Id;
                    txtFile.Text = obj.Path + @"\" + obj.Name + "." + obj.Format;
                    txtTitle.Text = obj.Name;
                    txtPage.Text = obj.Pages.ToString();
                    cboLanguage.SelectedValue = obj.LanguageId.Value;
                    break;
                case 2: //Knowledge
                    Knowledge.DBContext.Knowledge obj2 = ((Knowledge.DBContext.Knowledge)row);
                    id = obj2.Id;
                    txtTitle.Text = obj2.Title;
                    rtbContent.Text = obj2.Description;
                    cboLanguage.SelectedValue = 1002; //vn
                    dirSource += @"\Knowledge\";
                    break;
                case 3: //Term
                    Term obj3 = ((Term)row);
                    id = obj3.Id;
                    txtTitle.Text = obj3.Vn;
                    rtbContent.Text = obj3.Description;
                    cboLanguage.SelectedValue = 1002; //vn
                    break;
                case 4: //Rule
                    Knowledge.DBContext.Rule obj4 = ((Knowledge.DBContext.Rule)row);
                    id = obj4.Id;
                    txtTitle.Text = obj4.Title;
                    rtbContent.Text = obj4.Description;
                    cboLanguage.SelectedValue = 1002; //vn
                    dirSource += @"\Rule\";
                    break;
            }
            string[] files = Directory.GetFiles(dirSource, "*" + id + "_*");
            foreach (string file in files)
                lstFile.Items.Add(file);

        }
    }
}
