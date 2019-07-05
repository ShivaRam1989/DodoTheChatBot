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
            //this.StartupUri = new System.Uri("Views/ChatSessionView.xaml", System.UriKind.Relative);
            //MessageBox.Show("Running");
            Bootstrap();
        }

        public void LaunchApp() {
            this.StartupUri = new System.Uri("Views/ChatSessionView.xaml", System.UriKind.Relative);
        }

        public void Bootstrap()
        {
            IContractCallback contractCallback = new CallBk();
            InstanceContext cntxt = new InstanceContext(contractCallback);
            ContractClient client = new ContractClient(cntxt, "WSDualHttpBinding_IContract");
            MessageBox.Show(client.GetConnectionConfirmation());
            client.MyMethod();
        }

    }

    public class CallBk : IContractCallback
    {
        public void OnCallback()
        {
            MessageBox.Show("Callback 1st call");
        }
    }
}
