using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.ServiceReference1;

namespace WebApplication1
{
    public partial class Admin : System.Web.UI.Page
    {
        private ContractClient client;
        private static LaunchControl launchControl;
        protected void Page_Load(object sender, EventArgs e)
        {
            IContractCallback contractCallback = new CallBk();
            InstanceContext cntxt = new InstanceContext(contractCallback);
            client = new ContractClient(cntxt, "WSDualHttpBinding_IContract");

        }

        private void SetDefaultVideoId()
        {
            //txt_videoId.Text = ConfigurationManager.AppSettings["defaultVideoId"];
        }

        private void SetDefaultTimeJump()
        {
           // txt_timeJump.Text = ConfigurationManager.AppSettings["defaultTimeInterval"];
        }

        private void SetDefaultPptToShow()
        {
           // txt_ppt.Text = ConfigurationManager.AppSettings["defaultPptId"];
        }

        protected void btn_video_play_Click(object sender, EventArgs e)
        {
            launchControl = LaunchControl.PlayAfterPause;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                VideoId = 1
            });
        }

        protected void btn_pause_Click(object sender, EventArgs e)
        {
            launchControl = LaunchControl.Pause;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                VideoId = 1
            });
        }

        protected void btn_stop_Click(object sender, EventArgs e)
        {
            launchControl = LaunchControl.Stop;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                VideoId = 1
            });
        }

        protected void btn_timeJump_Click(object sender, EventArgs e)
        {
            launchControl = LaunchControl.Hop;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                VideoId = 1,
                Interval = "2"
            });
        }

        protected void btn_launch_Click(object sender, EventArgs e)
        {
            launchControl = LaunchControl.Launch;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                VideoId = 0,
                Interval = ConfigurationManager.AppSettings["defaultTimeInterval"]
            });
        }

        protected void Listen_Click(object sender, EventArgs e)
        {
            launchControl = LaunchControl.Listen;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                //dummy not using these
                VideoId = 0,
                Interval = ConfigurationManager.AppSettings["defaultTimeInterval"]
            });
        }

        protected void StopListen_Click(object sender, EventArgs e)
        {
            launchControl = LaunchControl.StopListen;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                //dummy not using these
                VideoId = 0,
                Interval = ConfigurationManager.AppSettings["defaultTimeInterval"]
            });
        }

        protected void btn_1_EntryVideo_Click(object sender, EventArgs e)
        {
            PlayVideo(1);
        }
        private void PlayVideo(int videoId)
        {
            launchControl = LaunchControl.Play;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                VideoId = videoId
            });
        }
        private void StartPpt(int pptId)
        {
            client.ShowPptAsync(new MetaData()
            {
                PptId = pptId
            });
        }

        protected void btn_2_AzadPratikaEntry_Click(object sender, EventArgs e)
        {
            PlayVideo(2);
        }

        protected void btn_3_rpaVideo_Click(object sender, EventArgs e)
        {
            PlayVideo(3);
        }

        protected void btn_4_gaurdxstart_Click(object sender, EventArgs e)
        {
            PlayVideo(4);
        }

        protected void btn_5_gaurdxvideo_Click(object sender, EventArgs e)
        {
            PlayVideo(5);
        }

        protected void btn_6_marketdata_Click(object sender, EventArgs e)
        {
            PlayVideo(6);
        }

        protected void btn_7_MD1_Click(object sender, EventArgs e)
        {
            PlayVideo(7);
        }

        protected void btn_8_MD2_Click(object sender, EventArgs e)
        {
            PlayVideo(8);
        }

        protected void btn_9_MD3_Click(object sender, EventArgs e)
        {
            PlayVideo(9);
        }

        protected void btn_10_techvideo1_Click(object sender, EventArgs e)
        {
            PlayVideo(10);
        }

        protected void btn_11_techvideo2_Click(object sender, EventArgs e)
        {
            PlayVideo(11);
        }

        protected void btn_12_thankyou_Click(object sender, EventArgs e)
        {
            PlayVideo(12);
        }

        protected void btn_13_RPAVideo_Click(object sender, EventArgs e)
        {
            PlayVideo(13);
        }

        protected void btn_1_AzadPpt_Click(object sender, EventArgs e)
        {
            StartPpt(1);
        }

        protected void btn_2_RPAPpt_Click(object sender, EventArgs e)
        {
            StartPpt(2);
        }

        protected void btn_3_GaurdxPpt_Click(object sender, EventArgs e)
        {
            StartPpt(3);
        }

        protected void btn_4_MarketDataPpt_Click(object sender, EventArgs e)
        {
            StartPpt(4);
        }

        protected void btn_5_MarketDataPart2ppt_Click(object sender, EventArgs e)
        {
            StartPpt(5);
        }

        protected void btn_6_QAppt_Click(object sender, EventArgs e)
        {
            StartPpt(6);
        }
    }
}