using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using IISHost;
using System.ServiceModel.Description;

namespace Host_Service
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost host;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri address = new Uri("http://10.170.190.26:9999/IISHost/Invoke");
          //  Uri address = new Uri("http://192.168.1.15:9999/IISHost/Invoke");
            host = new ServiceHost(typeof(IISHost.Invoke), address);
            WSDualHttpBinding netTcpBinding = new WSDualHttpBinding();
            host.AddServiceEndpoint(typeof(IISHost.IContract), netTcpBinding,"");
            netTcpBinding.ReceiveTimeout = new TimeSpan(1, 0, 0);
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
          
            
            host.Open();
            MessageBox.Show("Started");
            StartButton.IsEnabled = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(host!=null)
            {
                host.Close();
            }
            StartButton.IsEnabled = true;
        }
    }
}
