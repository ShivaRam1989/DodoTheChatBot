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
            //client.LaunchToggleAsync(LaunchControl.Start);
        }
    }

    public class CallBk : IContractCallback
    {
        public void MyMethod(LaunchControl control,MetaData metaData)
        {
            MessageBox.Show(" Initiate control :- "
                + control.ToString()
                + " Video ID :- "
                + metaData.VideoId
                + " Time Interval:- "
                + metaData.Interval);
        }

        public void OpenPPT(Item pptDetails)
        {
        }

        public void PlayVideo(Item videoDetails, ActionType actionType)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();

            //switch ("category")
            //{
            //    case "mp4":
            mediaPlayer.PlayVideo("OfficeTools.mp4");
            // mediaPlayer.StopVideo();
            //        break;

            //}
        }
    }

}
