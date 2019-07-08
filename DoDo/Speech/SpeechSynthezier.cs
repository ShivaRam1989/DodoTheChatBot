using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Speech
{
    public class SpeechSynthezier
    {
        public SpeechSynthesizer talker;
        public SpeechSynthezier()
        {
            talker = new SpeechSynthesizer();
            // Load all installed voices
            System.Collections.ObjectModel.ReadOnlyCollection<InstalledVoice>
                voices = talker.GetInstalledVoices();
            talker.SelectVoice(voices.FirstOrDefault().VoiceInfo.Name);

        }
        public void Speak(string textToSpeak)
        {
            //var current = talker.GetCurrentlySpokenPrompt();

            //if (current != null)
            //{
            //    talker.SpeakAsyncCancel(current);
            //}
            talker.SetOutputToWaveFile(@"C:\Audio.wav");
            talker.Speak(textToSpeak);
            talker.Volume = 100;

        }
    }
}
