using DoDo.Mock;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DoDo.Views
{
    /// <summary>
    /// Interaction logic for MediaPlayer.xaml
    /// </summary>
    public partial class MediaPlayer : Window
    {
        public MediaPlayer()
        {
            InitializeComponent();
        }

        public void PlayVideo(string videoName)
        {
            string videoPath = System.IO.Path.Combine(Mocker.debugPath, "Videos", videoName);
            DodoMediaPlayer.Source = new Uri(videoPath);
            this.Show();
            DodoMediaPlayer.Play();
        }

        public void StopVideo()
        {
            if (DodoMediaPlayer.Source != null) {
                DodoMediaPlayer.Stop();
            }
        }

        public void PauseVideo()
        {
            if (DodoMediaPlayer.CanPause)
            {
                DodoMediaPlayer.Pause();
            }
        }

        public void PositionVideo()
        {
            if (DodoMediaPlayer.Source != null)
            {
                DodoMediaPlayer.Position = TimeSpan.FromMinutes(Convert.ToDouble(10));
            }
        }

        private void DodoMediaPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
