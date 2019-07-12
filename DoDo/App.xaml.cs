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
        MediaPlayer mediaPlayer = new MediaPlayer();

        public CallBk()
        {
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
               // mediaPlayer.StartListening();
            }
            if (control == LaunchControl.StopListen)
            {
                mediaPlayer.StopListening();
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
