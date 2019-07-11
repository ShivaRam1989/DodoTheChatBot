using DoDo.PushPollService;
using DoDo.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Office.Core;
using powerpointinterop = Microsoft.Office.Interop.PowerPoint;
using System.IO;
using DoDo.Mock;
using DoDo.Models;
using DoDo.Commands;
using System.Diagnostics;

namespace DoDo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Bootstrap();
        }

        public void LaunchApp()
        {
            // this.StartupUri = new System.Uri("Views/ChatSessionView.xaml", System.UriKind.Relative);           
        }

        public void Bootstrap()
        {
            IContractCallback contractCallback = new CallBk();
            InstanceContext cntxt = new InstanceContext(contractCallback);
            ContractClient client = new ContractClient(cntxt);
            MessageBox.Show(client.GetConnectionConfirmation(true), "Status Check", MessageBoxButton.OKCancel);
        }
    }

    public class CallBk : IContractCallback
    {
        Subscription<Speech.Speech> subscription;
        Speech.SpeechRecognize speechRecognize = new Speech.SpeechRecognize();
        MediaPlayer mediaPlayer = new MediaPlayer();

        public CallBk()
        {
            subscription = EventAggregator.getInstance().Subscribe<Speech.Speech>(SubscribedMessage);
        }
        private void SubscribedMessage(Speech.Speech spokenText)
        {
            MetaData metaData = new MetaData();
            switch (spokenText.TextSpoken)
            {
                case "Hi Dodo":
                case "Hey Dodo":
                case "Hello Dodo":
                    metaData.VideoId = 5;
                    metaData.Interval = "0";
                  //  PlayVideo(metaData, LaunchControl.Play);
                    break;
                case "Play the video":
                    metaData.VideoId = 6;
                    metaData.Interval = "0";
                   // PlayVideo(metaData, LaunchControl.Play);
                    break;
                default:
                    break;

            }
        }
        public List<VideoDetails> VideoCollection
        {
            get
            {
                return Mock.Mocker.GetMockModelsForVideo();
            }
        }
        public List<PptDetails> PptCollection
        {
            get
            {
                return Mock.Mocker.GetMockModelsForPpt();
            }
        }
        public void AdminCommand(LaunchControl control)
        {
            if (control == LaunchControl.Launch)
            {
                MetaData metaData = new MetaData();
                metaData.VideoId = 0;
                metaData.Interval = "0";
                PlayVideo(metaData, control);
            }
            if (control == LaunchControl.PlayAfterPause)
            {
                MetaData metaData = new MetaData();
                metaData.VideoId = 0;
                metaData.Interval = "0";
                PlayVideo(metaData, control);
            }
            if (control == LaunchControl.Listen)
            {
                speechRecognize.StartListening();
            }
            if (control == LaunchControl.StopListen)
            {
                speechRecognize.Stop();
            }
            if (control == LaunchControl.Pause)
            {
                MetaData metaData = new MetaData();
                metaData.VideoId = 0;
                PlayVideo(metaData, control);
            }
            if (control == LaunchControl.Stop)
            {
                MetaData metaData = new MetaData();
                metaData.VideoId = 0;
                metaData.Interval = "0";
                PlayVideo(metaData, control);
            }
        }

        public void OpenPPT(MetaData metaData)
        {
             PptDetails pptDetails = PptCollection.Find(x => x.Id == metaData.PptId);

            mediaPlayer.PptAction(pptDetails); 
        }
        //public void PptAction(MetaData metaData)
        //{
        //    if (pptDetails != null)
        //    {
        //        try
        //        {
        //            powerpointinterop.Application ppApp = new powerpointinterop.Application();
        //            ppApp.Visible = MsoTriState.msoTrue;
        //            powerpointinterop.Presentations ppPresens = ppApp.Presentations;
        //            string pptName = pptDetails.Name;
        //            string pptPath = System.IO.Path.Combine(Mocker.debugPath, "Ppts", pptName);

        //            powerpointinterop.Presentation objPres = ppPresens.Open(pptPath, MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
        //            powerpointinterop.Slides objSlides = objPres.Slides;
        //            Microsoft.Office.Interop.PowerPoint.SlideShowWindows objSSWs;
        //            Microsoft.Office.Interop.PowerPoint.SlideShowSettings objSSS;
        //            //Run the Slide show
        //            objSSS = objPres.SlideShowSettings;
        //            objSSS.Run();
        //            objSSWs = ppApp.SlideShowWindows;
        //            while (objSSWs.Count >= 1)
        //                System.Threading.Thread.Sleep(100);
        //            //Close the presentation without saving changes and quit PowerPoint
        //            objPres.Close();
        //            ppApp.Quit();
        //        }
        //        catch (Exception)
        //        {
        //           // MessageBox.Show("Ppt Closed");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Media Not Found");
        //    }
        //}

        public void PlayVideo(MetaData metaData, LaunchControl control)
        {
            Application.Current.Dispatcher.InvokeAsync(() => { MediaPlayerAction(metaData,control); });
        }

        public void MediaPlayerAction(MetaData metaData, LaunchControl action)
        {
            VideoDetails videoOrPptDetails = VideoCollection.Find(x => x.Id == metaData.VideoId);
            if(videoOrPptDetails!=null)
            {
                switch (action)
                {
                    case LaunchControl.Launch:
                    case LaunchControl.Play:
                        mediaPlayer.PlayVideo(videoOrPptDetails);
                        break;
                    case LaunchControl.PlayAfterPause:
                        mediaPlayer.PlayAfterPauseVideo();
                        break;
                    case LaunchControl.Pause:
                        mediaPlayer.PauseVideo();
                        break;
                    case LaunchControl.Stop:
                        mediaPlayer.StopVideo();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Media Not Found");
            }

        }
    }
}
