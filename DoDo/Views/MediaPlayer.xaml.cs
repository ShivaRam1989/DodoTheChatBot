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
        //MediaPlayer mediaPlayer = new MediaPlayer();
        public MediaPlayer()
        {
            InitializeComponent();
        }

        private void PlayVideo_Click(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\mgopidi\Desktop\DodoTheChatBot-master\DodoTheChatBot-master\DoDo\VideoFileNames.txt")) {

                //TODO: this part can be moved out as the file names here are static ;
                // File names can also be a static variable.
                String line = sr.ReadLine();
                string[] paths = line.Split(',');
                Dictionary<string, string> videoNames = new Dictionary<string, string>();
                for (int i = 0; i < paths.Length; i++) {
                   videoNames.Add((i+1).ToString(), paths[i]);
                }

                string selectedValue = VideoNumber.Text;
                string selectedVideo = string.Empty;
                videoNames.TryGetValue(selectedValue,out selectedVideo);
                DodoMediaPlayer.Source = new Uri(selectedVideo);
                DodoMediaPlayer.Play();
            }               
        }
        
        private void StopVideo_Click(object sender, RoutedEventArgs e)
        {
            DodoMediaPlayer.Stop();
        }

        private void PauseVideo_Click(object sender, RoutedEventArgs e)
        {
            DodoMediaPlayer.Pause();
        }

        private void PositionVideo_Click(object sender, RoutedEventArgs e)
        {
            DodoMediaPlayer.Position = TimeSpan.FromMinutes(Convert.ToDouble(MoveToPosition.Text));
        }
    }
}
