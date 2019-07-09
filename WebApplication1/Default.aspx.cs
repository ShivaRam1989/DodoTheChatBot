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
    public class CallBk : IContractCallback
    {
        public void MyMethod(LaunchControl control, MetaData metaData)
        {
            //throw new NotImplementedException();
        }

        public void OpenPPT(MetaData metaData)
        {
            //throw new NotImplementedException();
        }

        public void PlayVideo(MetaData metaData, LaunchControl control)
        {
            //throw new NotImplementedException();
        }
    }
    public partial class _Default : Page
    {
        private ContractClient client;
        private static LaunchControl launchControl;
        protected void Page_Load(object sender, EventArgs e)
        {
            IContractCallback contractCallback = new CallBk();
            InstanceContext cntxt = new InstanceContext(contractCallback);
            client = new ContractClient(cntxt, "WSDualHttpBinding_IContract");
        }

        protected void btn_launch_Click(object sender, EventArgs e)
        {
            client.LaunchToggleAsync(launchControl, new MetaData()
            {
                VideoId = ConfigurationManager.AppSettings["defaultVideoId"],
                Interval = ConfigurationManager.AppSettings["defaultTimeInterval"]
            });
            launchControl = LaunchControl.Start;
        }
    }
}