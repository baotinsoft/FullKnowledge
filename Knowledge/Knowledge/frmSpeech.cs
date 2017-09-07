using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechLib;
using System.Globalization;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.AudioFormat;

namespace Knowledge
{
    public partial class frmSpeech : Form
    {
        public frmSpeech()
        {
            InitializeComponent();
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            if (cboVoice.SelectedIndex == -1) return;
            SpVoice oVoice = new SpVoice();
            SpFileStream cpFileStream = new SpFileStream();
            oVoice.Voice = oVoice.GetVoices().Item(cboVoice.SelectedIndex);
            oVoice.Volume = trVolume.Value;
            oVoice.Rate = trRate.Value;
            oVoice.Speak(txtSpeak.Text, SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault);
            ////SpeechSynthesizer s = new SpeechSynthesizer();
            //SpVoice s = new SpVoice();
            //s.Speak("my name is Phu");
            ////s.Speak("Hello. My name is Microsoft Server Speech Text to Speech Voice (en-US, Helen).");
            //ISpeechRecoContext catchText = new SpInProcRecoContext();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trRate.Minimum = -10;
            trRate.Maximum = 10;
            trRate.Value = 0;
            SpVoice spVoice = new SpVoice();
            ISpeechObjectTokens arrVoice = spVoice.GetVoices();
            string s;
            for(int i=0;i<5;i++)
            {
                cboVoice.Items.Add(arrVoice.Item(i).GetDescription());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SpVoice oVoice = new SpVoice();
                SpFileStream cpFileStream = new SpFileStream();

                cpFileStream.Open(SaveFileDialog1.FileName, SpeechLib.SpeechStreamFileMode.SSFMCreateForWrite, false);
                SpeechAudioFormatInfo info = new SpeechAudioFormatInfo(6, AudioBitsPerSample.Sixteen, AudioChannel.Mono);
                SpAudioFormat info1 = new SpAudioFormat();
               
                info1.Type = SpeechAudioFormatType.SAFTGSM610_11kHzMono;
                cpFileStream.Format.Type = SpeechAudioFormatType.SAFT11kHz16BitStereo;


                oVoice.AudioOutputStream = cpFileStream;
                oVoice.Voice = oVoice.GetVoices().Item(cboVoice.SelectedIndex);
                oVoice.Volume = trVolume.Value;
                oVoice.Rate = trRate.Value;
                oVoice.Speak(txtSpeak.Text, SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault);

                oVoice = null;
                cpFileStream.Close();
                cpFileStream = null;


            }

            //SpFileStream spFileStream = new SpFileStream();



            //SpVoice speech = new SpVoice();



            //SpAudioFormat format = new SpAudioFormat();

               
            //spFileStream.Open(@"d:\dude.wav", SpeechStreamFileMode.SSFMCreateForWrite, true);

            //speech.AudioOutputStream = spFileStream;


            ////NOTE: This is where I get hosed
            //speech.Voice = speech.GetVoices().Item(0);
            //speech.Volume = trVolume.Value;
            //speech.Rate = trRate.Value;
            //speech.Speak("I love you", SpeechVoiceSpeakFlags.SVSFDefault);
            //spFileStream.Close();
            //spFileStream = null;
        }

        private void btnCatchText_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine RecognitionEngine;
            using (RecognitionEngine = new SpeechRecognitionEngine(new CultureInfo("en-US")))
            {
                RecognitionEngine.SetInputToWaveFile("D:/wav/test.wav");

                //RecognitionEngine.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(RecognitionEngine_RecognizeCompleted); 
                GrammarBuilder gb = new GrammarBuilder();

                gb.AppendDictation();

                Grammar g = new Grammar(gb);

                g.Name = "Dictation Grammar";

                //recognizer.LoadGrammar(g);

                RecognitionEngine.LoadGrammar(g);
                RecognitionResult Result = RecognitionEngine.Recognize();
                RecognitionEngine.RecognizeAsync(RecognizeMode.Single);

                StringBuilder Output = new StringBuilder();
                foreach (RecognizedWordUnit Word in Result.Words)
                {
                    Output.Append(Word.Text + " ");
                }

                // RecognitionEngine.RecognizeAsyncStop();

                txtSpeak.Text = Output.ToString();

                RecognitionEngine.Dispose();
                //Dispose();
            }
        }

        private void btnTalk_Click(object sender, EventArgs e)
        {
            SpVoice oVoice = new SpVoice();
            SpFileStream cpFileStream = new SpFileStream();
            oVoice.Voice = oVoice.GetVoices().Item(1);
            oVoice.Volume = trVolume.Value;
            oVoice.Rate = trRate.Value;//4

            string speak = txtSentence.Text.Replace(" x ", " " + txtX.Text + " ");
            speak = speak.Replace(" y", " " + txtY.Text);
            oVoice.Speak(speak, SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault);

        }


    }
}
