using System;
using System.Collections.Generic;
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
        public void MyMethod(LaunchControl launchControl)
        {
            //throw new NotImplementedException();
        }
    }

    //protected void btn_launch_Click(object sender, EventArgs e)
    //{
    //    toggleState = client.LaunchToggle(toggleState);
    //    toggleLaunch();
    //}

    //private void toggleLaunch()
    //{
    //    btn_launch.Text = toggleState.ToString();
    //}
    public partial class _Default : Page
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
                //lbl_confirmation.Text = client.GetConnectionConfirmation();
            }
            catch (Exception )
            {
                //lbl_confirmation.Text = exception.Message;
                //app.Visible = false;
            }

        }

        protected void btn_launch_Click(object sender, EventArgs e)
        {
            toggleState = client.LaunchToggle(toggleState);
            toggleLaunch();
        }

        private void toggleLaunch()
        {
            //btn_launch.Text = toggleState.ToString();
        }
    }
}