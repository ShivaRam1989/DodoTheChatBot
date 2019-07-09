using System;
using System.Windows.Forms;

namespace SelfHost
{
    public partial class Form1 : Form
    {
        private System.ServiceModel.ServiceHost host;
        public Form1()
        {
            InitializeComponent();
            StartService();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            StartService();
        }

        private void StartService() {
            host = new System.ServiceModel.ServiceHost(typeof(PushPollService.Invoke));
            host.Open();
            btn_start.Enabled = false;
            btn_stop.Enabled = true;
            lbl_message.Text = "Service Started @ " + DateTime.Now.ToString();
        }

        private void StopService() {
            if (host != null)
            {
                host.Close();
            }
            btn_start.Enabled = true;
            btn_stop.Enabled = false;
            lbl_message.Text = "Service Stopped";
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            StopService();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            host.Close();
        }
    }
}
