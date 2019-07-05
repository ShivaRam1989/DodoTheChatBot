using Launcher.PushPollService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Launcher
{
    public class CallBk : IContractCallback
    {
        public void OnCallback()
        {
            //Callback method is called
        }
    }
    public partial class Welcome : System.Web.UI.Page
    {
        private ContractClient client;
        private static LaunchControl toggleState;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                IContractCallback contractCallback = new CallBk();
                InstanceContext cntxt = new InstanceContext(contractCallback);
                client = new ContractClient(cntxt, "WSDualHttpBinding_IContract");
                lbl_confirmation.Text = client.GetConnectionConfirmation();
            }
            catch (Exception exception) {
                lbl_confirmation.Text = exception.Message;
                app.Visible = false;
            }
        }

        protected void btn_launch_Click(object sender, EventArgs e)
        {
            toggleState = client.LaunchToggle(toggleState);
            toggleLaunch();
        }

        private void toggleLaunch() {
            btn_launch.Text = toggleState.ToString();
        }
    }
}