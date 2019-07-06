﻿using DoDo.PushPollService;
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
           // LaunchApp();
        }

        public void LaunchApp() {
            this.StartupUri = new System.Uri("Views/ChatSessionView.xaml", System.UriKind.Relative);
        }

        public void Bootstrap()
        {
            IContractCallback contractCallback = new CallBk();
            InstanceContext cntxt = new InstanceContext(contractCallback);
            ContractClient client = new ContractClient(cntxt);
            MessageBox.Show("test",client.GetConnectionConfirmation(),MessageBoxButton.OKCancel);
            client.LaunchToggleAsync(LaunchControl.Start);
        }

    }
    
    public class callbackclient:DuplexClientBase<IContract>
    {
        public callbackclient(InstanceContext instanceContext):base(instanceContext)
        {

        }

    }

    public class CallBk : IContractCallback
    {
        public void MyMethod(LaunchControl launchControl)
        {
            MessageBox.Show("Called");
        }
    }
}
