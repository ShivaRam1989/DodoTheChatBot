using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Runtime.InteropServices;

namespace DoDo.Views
{


    //Step 4
    internal struct LASTINPUTINFO
    {
        public uint cbSize;

        public uint dwTime;
    }

    /// <summary>
    /// Interaction logic for IdleScreenView.xaml
    /// </summary>
    public partial class IdleScreenView : Window
    {
        public IdleScreenView()
        {
            InitializeComponent();
            Loaded += Window_Loaded;

        }

      



        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
