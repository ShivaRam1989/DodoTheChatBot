using DoDo.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Speech
{
    public enum SpeechTextOptions
        {
        PauseVideo= 0,
        ContinueVideo 
    }
    public class SpeechRecognize
    {
        SpeechRecognitionEngine speechRecognitionEngine = null;




        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public SpeechRecognize()
        {

            try
            {
                //StartListening();
            }
            catch (Exception ex)
            {

            }
        }

        public void StartListening()
        {
            speechRecognitionEngine = createSpeechEngine("en-US");
            speechRecognitionEngine.LoadGrammar(new Grammar(new GrammarBuilder("Next Slide Please"))); // load a "test" grammar
            speechRecognitionEngine.LoadGrammar(new Grammar(new GrammarBuilder("Previous Slide Please"))); // load a "test" grammar
            speechRecognitionEngine.LoadGrammar(new Grammar(new GrammarBuilder("Pause Video"))); // load a "test" grammar
            speechRecognitionEngine.LoadGrammar(new Grammar(new GrammarBuilder("Continue video"))); // load a "test" grammar
            speechRecognitionEngine.LoadGrammar(new Grammar(new GrammarBuilder("Forward video")));
            speechRecognitionEngine.LoadGrammar(new Grammar(new GrammarBuilder("Backward video")));
            speechRecognitionEngine.LoadGrammar(new Grammar(new GrammarBuilder("Stop video")));

            speechRecognitionEngine.SpeechRecognized += engine_SpeechRecognized; // if speech is recognized, call the specified method


            speechRecognitionEngine.SpeechRecognitionRejected += _recognizeSpeechAndWriteToConsole_SpeechRecognitionRejected; // if recognized speech is rejected, call the specified method

            speechRecognitionEngine.SetInputToDefaultAudioDevice(); // set the input to the default audio device

            speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple); // recognize speech asynchronous
        }

        static void _recognizeSpeechAndWriteToConsole_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "Hi Dodo":
                case "Hey Dodo":
                case "Hello Dodo":

                    break;
                case "Thank you":
                    break;
                case "Play the video":
                    break;
                default:
                    break;

            }


        }

        static void _recognizeSpeechAndWriteToConsole_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            Console.WriteLine("Speech rejected. Did   mean:");
            foreach (RecognizedPhrase r in e.Result.Alternates)
            {
                Console.WriteLine("    " + r.Text);
            }
        }

        #endregion

        #region internal functions and methods

        /// <summary>
        /// Creates the speech engine.
        /// </summary>
        /// <param name="preferredCulture">The preferred culture.</param>
        /// <returns></returns>
        private SpeechRecognitionEngine createSpeechEngine(string preferredCulture)
        {
            foreach (RecognizerInfo config in SpeechRecognitionEngine.InstalledRecognizers())
            {
                if (config.Culture.ToString() == preferredCulture)
                {
                    speechRecognitionEngine = new SpeechRecognitionEngine(config);
                    break;
                }
            }

            // if the desired culture is not found, then load default
            if (speechRecognitionEngine == null)
            {
                speechRecognitionEngine = new SpeechRecognitionEngine(SpeechRecognitionEngine.InstalledRecognizers()[0]);
            }

            return speechRecognitionEngine;
        }

        /// <summary>
        /// Loads the grammar and commands.
        /// </summary>
        private void loadGrammarAndCommands(List<string> texts)
        {
            try
            {
                Choices choices = new Choices();
                foreach (string text in texts)
                {
                    choices.Add(text);
                }
                Grammar wordsList = new Grammar(new GrammarBuilder(choices));
                speechRecognitionEngine.LoadGrammar(wordsList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the known command.
        /// </summary>
        /// <param name="command">The order.</param>
        /// <returns></returns>
        private string getKnownTextOrExecute(string command)
        {
            try
            {
                return command;
            }
            catch (Exception)
            {
                return command;
            }
        }

        #endregion

        #region speechEngine events

        /// <summary>
        /// Handles the SpeechRecognized event of the engine control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Speech.Recognition.SpeechRecognizedEventArgs"/> instance containing the event data.</param>
        void engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Speech speech = new Speech();
            speech.TextSpoken = getKnownTextOrExecute(e.Result.Text);
            EventAggregator.getInstance().Publish(speech);
        }


        #endregion

        #region window closing

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        public void Stop()
        {
            // unhook events
            speechRecognitionEngine.RecognizeAsyncStop();
            // clean references
            speechRecognitionEngine.Dispose();
        }

        #endregion

    }
}
