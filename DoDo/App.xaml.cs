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

        public void LaunchApp() {
          // this.StartupUri = new System.Uri("Views/ChatSessionView.xaml", System.UriKind.Relative);           
        }

        public void Bootstrap()
        {
            IContractCallback contractCallback = new CallBk();
            InstanceContext cntxt = new InstanceContext(contractCallback);
            ContractClient client = new ContractClient(cntxt);
            MessageBox.Show(client.GetConnectionConfirmation(),"Status Check", MessageBoxButton.OKCancel);
        }
    }

    public class CallBk : IContractCallback
    {
        private static MediaPlayer mediaPlayer;

        public CallBk()
        {
            if (mediaPlayer == null)
            {
                mediaPlayer = new MediaPlayer();
            }
        }

        public void MyMethod(LaunchControl control,MetaData metaData)
        {
            MessageBox.Show(" Initiate control :- "
                + control.ToString()
                + "    Video ID :- "
                + metaData.VideoId
                + "    Time Interval:- "
                + metaData.Interval);
        }

        public void OpenPPT(MetaData metaData)
        {
            MessageBox.Show("PPT To Open :-  " + metaData.PptId);
        }

        public void PeekVideo(MetaData metaData, LaunchControl control)
        {
            mediaPlayer.PositionVideo(metaData.Interval);
        }

        public void PauseVideo(MetaData metaData, LaunchControl control)
        {
            mediaPlayer.PauseVideo();
        }
        public void StopVideo(MetaData metaData, LaunchControl control)
        {
            mediaPlayer.StopVideo();
        }

        public void PlayVideo(MetaData metaData, LaunchControl control)
        {            
            mediaPlayer.PlayVideo(metaData.VideoId);
        }
    }

}
