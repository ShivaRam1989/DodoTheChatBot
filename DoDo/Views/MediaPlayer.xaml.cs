using DoDo.Mock;
using DoDo.Models;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Linq;
using powerpointinterop = Microsoft.Office.Interop.PowerPoint;
using System.Threading.Tasks;
using DoDo.Commands;

namespace DoDo.Views
{
    /// <summary>
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : Window
    {
        powerpointinterop.Application objApp ;
        VideoDetails videoDetailsMain = new VideoDetails();
        PptDetails pptDetailsMain = new PptDetails();
        Subscription<Speech.Speech> subscription;
        Speech.SpeechRecognize speechRecognize = new Speech.SpeechRecognize();
        powerpointinterop.Presentations objPresSet;
        powerpointinterop._Presentation objPres;
        powerpointinterop.Slides objSlides;
        powerpointinterop.SlideShowSettings objSSS;
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

        public MediaPlayer()
        {
            InitializeComponent();
            //speechRecognize.StartListening();
            subscription = EventAggregator.getInstance().Subscribe<Speech.Speech>(SubscribedMessage);
        }
        private void SubscribedMessage(Speech.Speech spokenText)
        {
            switch (spokenText.TextSpoken)
            {
                case "Next Slide Please":
                    if(objPresSet!=null)
                    {
                        if(objPresSet.Count>0)
                        {
                            objPres.SlideShowWindow.View.Next();
                        }
                    }
                    break;
                case "Pause the Video":
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() => {
                        PauseVideo();
                    });

                    break;
                case "Continue video":
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() => {
                        PlayAfterPauseVideo();
                    });

                    break;
                case "Forward video":
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() => {
                        PositionForwardVideo();
                    });

                    break;
                case "Backward video":
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() => {
                        PositionBackVideo();
                    });

                    break;
                case "Previous Slide Please":
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() => {
                        if (objPresSet != null)
                        {
                            if (objPresSet.Count > 0)
                            {
                                objPres.SlideShowWindow.View.Previous();
                            }
                        }
                    });

                    break;
                case "Stop video":
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() => {
                        StopVideo();
                    });

                    break;

            }
        }
        public void PositionForwardVideo()
        {
            if (DodoMediaPlayer.Source != null)
            {
                DodoMediaPlayer.Position = DodoMediaPlayer.Position + new TimeSpan(0, 0, 20);
                DodoMediaPlayer.Play();
            }
        }
        public void PositionBackVideo()
        {
            if (DodoMediaPlayer.Source != null)
            {
                DodoMediaPlayer.Position = DodoMediaPlayer.Position - new TimeSpan(0, 0, 20);
                DodoMediaPlayer.Play();
            }
        }
        public void PlayVideo(VideoDetails videoDetails)
        {
            if (videoDetails != null)
            {
                videoDetailsMain = videoDetails;
                string videoPath = System.IO.Path.Combine(Mocker.debugPath, "Videos", videoDetails.Name);
                DodoMediaPlayer.Source = new Uri(videoPath);
                this.Show();
                DodoMediaPlayer.Play();
            }
        }
        public void PlayAfterPauseVideo()
        {
            if (DodoMediaPlayer.Source != null && DodoMediaPlayer.Source.OriginalString!=string.Empty)
            {
                DodoMediaPlayer.Play();
            }
        }

        public void StopVideo()
        {
            if (DodoMediaPlayer.Source != null) {
                DodoMediaPlayer.Stop();
            }
        }

        public void PauseVideo()
        {
            if (DodoMediaPlayer.CanPause)
            {
                DodoMediaPlayer.Pause();
            }
        }

        public void PositionVideo()
        {
            if (DodoMediaPlayer.Source != null)
            {
                DodoMediaPlayer.Position = TimeSpan.FromMinutes(Convert.ToDouble(10));
            }
        }
        public void PptAction(PptDetails pptDetails)
        {
            pptDetailsMain = pptDetails;
            if (pptDetails != null)
            {
                try
                {

                    //Create a new presentation based on a template.
                    objApp = new powerpointinterop.Application();
                    //  objApp.SlideShowBegin += new Microsoft.Office.Interop.PowerPoint.EApplication_SlideShowBeginEventHandler(powerpnt_SlideShowBegin);
                    objApp.SlideShowEnd += new Microsoft.Office.Interop.PowerPoint.EApplication_SlideShowEndEventHandler(powerpnt_SlideShowEnd);
                    //objApp.SlideShowNextSlide += new Microsoft.Office.Interop.PowerPoint.EApplication_SlideShowNextSlideEventHandler(powerpnt_SlideShowNextSlide);
                    objApp.Visible = MsoTriState.msoTrue;
                    objPresSet = objApp.Presentations;
                    string pptName = pptDetails.Name;
                    string pptPath = System.IO.Path.Combine(Mocker.debugPath, "Ppts", pptName);
                    objPres = objPresSet.Open(pptPath, MsoTriState.msoTrue, MsoTriState.msoTrue, MsoTriState.msoTrue);
                    objSlides = objPres.Slides;
                    objSSS = objPres.SlideShowSettings;
                    objSSS.Run();

                }
                catch (Exception)
                {

                }
            }
            else
            {
                MessageBox.Show("Media Not Found");
            }
        }
        private void powerpnt_SlideShowBegin(powerpointinterop.SlideShowWindow Wn)
        {

        }
        private void powerpnt_SlideShowEnd(powerpointinterop.Presentation Wn)
        {
            Wn.Close();
            VideoDetails videoDetails = null;
            switch (pptDetailsMain.Id)
            {
                case 1:
                    //azad exit and rpa video start
                    videoDetails = VideoCollection.Find(x => x.Id == 2);
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() => { PlayVideo(videoDetails); });
                    break;
                case 2:
                    //rpa video
                    videoDetails = VideoCollection.Find(x => x.Id == 3);
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() => {
                        PlayVideo(videoDetails);
                    });
                    break;
                case 3:
                    //market data entry bot
                    videoDetails = VideoCollection.Find(x => x.Id == 6);
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() => {
                        PlayVideo(videoDetails);
                    });
                    break;
                case 4:
                    //market data ppt end
                    videoDetails = VideoCollection.Find(x => x.Id == 7);
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() => {
                        PlayVideo(videoDetails);
                    });
                    break;
                case 5:
                    //market data ends and 
                    //tech video start
                    videoDetails = VideoCollection.Find(x => x.Id == 10);
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() => {
                        PlayVideo(videoDetails);
                    });
                    break;
                case 6:
                    //Q&A ppt
                    videoDetails = VideoCollection.Find(x => x.Id == 13);
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() => { PlayVideo(videoDetails); });
                    break;
            }
        }
        private void DodoMediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            VideoDetails videoDetails = null;
            PptDetails pptDetails = null;
            this.Hide();
            switch(videoDetailsMain.Id)
            {
                case 0:
                    //intro and azadpartika start
                    videoDetails = VideoCollection.Find(x => x.Id == 1);
                    PlayVideo(videoDetails);
                    break;
                case 1:
                    //azad pratika ppt
                    pptDetails = PptCollection.Find(x => x.Id == 1);
                    PptAction(pptDetails);
                    break;
                case 2:
                    //rpa ppt
                    pptDetails = PptCollection.Find(x => x.Id == 2);
                    PptAction(pptDetails);
                    break;
                case 3:
                    videoDetails = VideoCollection.Find(x => x.Id == 4);
                    PlayVideo(videoDetails);
                    break;
                case 4:
                    ////20 secs stop for lizitha
                    //Thread.Sleep(new TimeSpan(0, 0, 20));
                    //start gaurdx demo video
                    videoDetails = VideoCollection.Find(x => x.Id == 5);
                    PlayVideo(videoDetails);
                    PauseVideo();
                    break;
                case 5:
                    //open gaurdx ppt
                    //pptDetails = PptCollection.Find(x => x.Id == 3);
                    //PptAction(pptDetails);
                    break;
                case 6:
                    //open market data ppt
                    pptDetails = PptCollection.Find(x => x.Id == 4);
                    PptAction(pptDetails);
                    break;
                case 7:
                    //open market video 1 ended
                    videoDetails = VideoCollection.Find(x => x.Id == 8);
                    PlayVideo(videoDetails);
                    break;
                case 8:
                    //open market video 2 ended
                    videoDetails = VideoCollection.Find(x => x.Id == 9);
                    PlayVideo(videoDetails);
                    break;
                case 9: 
                    //open market data ppt part 2
                    pptDetails = PptCollection.Find(x => x.Id == 5);
                    PptAction(pptDetails);
                    break;
                case 10:
                    //tech video ended q&a video start
                    videoDetails = VideoCollection.Find(x => x.Id == 11);
                    PlayVideo(videoDetails);
                    break;
                case 11:
                    //tech video part 2
                    videoDetails = VideoCollection.Find(x => x.Id == 12);
                    PlayVideo(videoDetails);
                    break;
                case 12:
                    //tech video 
                    pptDetails = PptCollection.Find(x => x.Id == 6);
                    PptAction(pptDetails);
                    break;
                case 13:
                    this.Close();
                    break;
            }
        }
    }
}
