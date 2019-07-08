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

        protected void btn_video_play_Click(object sender, EventArgs e)
        {
            if (txt_videoId.Text == "") { SetDefaultVideoId(); }
            launchControl = LaunchControl.Play;
            client.LaunchToggle(launchControl, new MetaData()
            {
                VideoId = txt_videoId.Text
            });
        }

        protected void btn_pause_Click(object sender, EventArgs e)
        {
            if (txt_videoId.Text == "") { SetDefaultVideoId(); }
            launchControl = LaunchControl.Pause;
            client.LaunchToggle(launchControl, new MetaData()
            {
                VideoId = txt_videoId.Text
            });
        }

        protected void btn_stop_Click(object sender, EventArgs e)
        {
            if (txt_videoId.Text == "") { SetDefaultVideoId(); }
            launchControl = LaunchControl.Stop;
            client.LaunchToggle(launchControl, new MetaData()
            {
                VideoId = txt_videoId.Text
            });
        }

        protected void btn_timeJump_Click(object sender, EventArgs e)
        {
            if (txt_videoId.Text == "") { SetDefaultVideoId(); }
            if (txt_timeJump.Text == "") { SetDefaultTimeJump(); }
            launchControl = LaunchControl.Hop;
            client.LaunchToggle(launchControl, new MetaData()
            {
                VideoId = txt_videoId.Text,
                Interval = Convert.ToInt32(txt_timeJump.Text)
            });
        }

        protected void btn_launch_Click(object sender, EventArgs e)
        {
            launchControl = LaunchControl.Start;
            client.LaunchToggle(launchControl, new MetaData()
            {
                VideoId = ConfigurationManager.AppSettings["defaultVideoId"],
                Interval = Convert.ToInt32(ConfigurationManager.AppSettings["defaultTimeInterval"])
            });
        }
    }
}