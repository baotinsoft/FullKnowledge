using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using WindowFramework;

namespace Knowledge
{
    public partial class frmSettings : Form
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();
        string enSpeak = "Try to preview voice";
        string vnSpeak = "Thử giọng trước khi dùng";
        string selectedSpeak;
                
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnPreviewVoice_Click(object sender, EventArgs e)
        {
            synth.SelectVoice(synth.GetInstalledVoices().Where(v => v.VoiceInfo.Name == cboVoice.SelectedText).First().VoiceInfo.Name);
            synth.Rate = barRate.Value;
            synth.Volume = barVolumn.Value;
            synth.Speak(selectedSpeak);
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            var lst = synth.GetInstalledVoices();
            foreach(var item in lst)
            {
                cboVoice.Items.Add(item.VoiceInfo.Name);
            }
            cboVoice.SelectedIndex = 0;
            
            barVolumn.Maximum = 100;
            barRate.Maximum = 10;

            LibIni.path = System.Windows.Forms.Application.StartupPath + @"\Settings.ini";

            LoadSettings();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            LibIni.IniWriteValue("Speech", "Voice", synth.Voice.Name);
            LibIni.IniWriteValue("Speech", "Volumn", barVolumn.Value.ToString());
            LibIni.IniWriteValue("Speech", "Rate", barRate.Value.ToString());
            LibIni.IniWriteValue("Speech", "Folder", txtFolder.Text);
        }

        private void cboVoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVoice.SelectedIndex > -1)
            {
                VoiceInfo selectedVoice = synth.GetInstalledVoices().Where(v => v.VoiceInfo.Name == cboVoice.SelectedItem.ToString()).First().VoiceInfo;
                synth.SelectVoice(selectedVoice.Name);
                lblResult.Text = "Selected Voice: " + selectedVoice.Name + ". Language: " + selectedVoice.Culture.Name + ". Gender: " + (selectedVoice.Gender == VoiceGender.Male ? "Male" : "Famale");
                if (selectedVoice.Culture.Name.Contains("en")) selectedSpeak = enSpeak;
                else selectedSpeak = vnSpeak;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (dlgFolder.ShowDialog() == DialogResult.OK) txtFolder.Text = dlgFolder.SelectedPath;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                cboVoice.SelectedItem = LibIni.IniReadValue("Speech", "Voice");
            }
            catch (Exception) { }
            try
            {
                barRate.Value = Convert.ToInt32(LibIni.IniReadValue("Speech", "Rate"));
            }
            catch (Exception) { barRate.Value = synth.Rate; }

            try
            {
                barVolumn.Value = Convert.ToInt32(LibIni.IniReadValue("Speech", "Volumn"));
            }
            catch (Exception) { barVolumn.Value = synth.Volume; }


            try
            {
                txtFolder.Text = LibIni.IniReadValue("Speech", "Folder");
            }
            catch (Exception) { txtFolder.Text = System.Windows.Forms.Application.StartupPath + @"\Data\Sound"; }
            if (txtFolder.Text.Length == 0) txtFolder.Text = System.Windows.Forms.Application.StartupPath + @"\Data\Sound";
        }
    }
}
