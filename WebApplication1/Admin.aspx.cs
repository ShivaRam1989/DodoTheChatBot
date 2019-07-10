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
            txt_videoId.Text = ConfigurationManager.AppSettings["defaultVideoId"];
        }

        private void SetDefaultTimeJump()
        {
            txt_timeJump.Text = ConfigurationManager.AppSettings["defaultTimeInterval"];
        }

        private void SetDefaultPptToShow()
        {
            txt_ppt.Text = ConfigurationManager.AppSettings["defaultPptId"];
        }

        protected void btn_video_play_Click(object sender, EventArgs e)
        {
            if (txt_videoId.Text == "") { SetDefaultVideoId(); }
            launchControl = LaunchControl.Play;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                VideoId = txt_videoId.Text
            });
        }

        protected void btn_pause_Click(object sender, EventArgs e)
        {
            if (txt_videoId.Text == "") { SetDefaultVideoId(); }
            launchControl = LaunchControl.Pause;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                VideoId = txt_videoId.Text
            });
        }

        protected void btn_stop_Click(object sender, EventArgs e)
        {
            if (txt_videoId.Text == "") { SetDefaultVideoId(); }
            launchControl = LaunchControl.Stop;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                VideoId = txt_videoId.Text
            });
        }

        protected void btn_timeJump_Click(object sender, EventArgs e)
        {
            if (txt_videoId.Text == "") { SetDefaultVideoId(); }
            if (txt_timeJump.Text == "") { SetDefaultTimeJump(); }
            launchControl = LaunchControl.Hop;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                VideoId = txt_videoId.Text,
                Interval = txt_timeJump.Text
            });
        }

        protected void btn_launch_Click(object sender, EventArgs e)
        {
            launchControl = LaunchControl.Launch;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                VideoId = ConfigurationManager.AppSettings["defaultVideoId"],
                Interval = ConfigurationManager.AppSettings["defaultTimeInterval"]
            });
        }

        protected void btn_ppt_Click(object sender, EventArgs e)
        {
            if (txt_ppt.Text == "") { SetDefaultPptToShow(); }
            client.ShowPptAsync(new MetaData()
            {
                PptId = txt_ppt.Text
            });
        }

        protected void Listen_Click(object sender, EventArgs e)
        {
            launchControl = LaunchControl.Listen;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                //dummy not using these
                VideoId = ConfigurationManager.AppSettings["defaultVideoId"],
                Interval = ConfigurationManager.AppSettings["defaultTimeInterval"]
            });
        }

        protected void StopListen_Click(object sender, EventArgs e)
        {
            launchControl = LaunchControl.StopListen;
            client.AdminCommandsAsync(launchControl, new MetaData()
            {
                //dummy not using these
                VideoId = ConfigurationManager.AppSettings["defaultVideoId"],
                Interval = ConfigurationManager.AppSettings["defaultTimeInterval"]
            });
        }
    }
}