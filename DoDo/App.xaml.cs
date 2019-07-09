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

        public void LaunchApp()
        {
            // this.StartupUri = new System.Uri("Views/ChatSessionView.xaml", System.UriKind.Relative);           
        }

        public void Bootstrap()
        {
            IContractCallback contractCallback = new CallBk();
            InstanceContext cntxt = new InstanceContext(contractCallback);
            ContractClient client = new ContractClient(cntxt);
            MessageBox.Show(client.GetConnectionConfirmation(), "Status Check", MessageBoxButton.OKCancel);
        }
    }

    public class CallBk : IContractCallback
    {
        public void MyMethod(LaunchControl control, MetaData metaData)
        {
            if (control == LaunchControl.Start)
            {
                PlayVideo(metaData, control);
            }
        }

        public void OpenPPT(MetaData metaData)
        {
            MessageBox.Show("PPT To Open :-  " + metaData.PptId);
        }

        public void PlayVideo(MetaData metaData, LaunchControl control)
        {
            //Application.Current.Dispatcher.InvokeAsync((() => { Play(metaData); }));
        }

        public void MediaPlayerAction(MetaData metaData, LaunchControl action)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();

            switch (action)
            {
                case LaunchControl.Play:
                    mediaPlayer.PlayVideo(metaData.VideoId);
                    break;
                //case LaunchControl.Hop:
                //    mediaPlayer.PositionVideo(metaData.Interval);
                //    break;
                case LaunchControl.Pause:
                    mediaPlayer.PauseVideo();
                    break;
                case LaunchControl.Stop:
                    mediaPlayer.StopVideo();
                    break;
            }

        }

    }
}
