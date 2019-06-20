using System.Collections.Generic;
using System.Windows;
using DoDo.Mock;
using DoDo.ViewModels;

namespace DoDo.Views
{
    /// <summary>
    /// Interaction logic for ChatSessionView.xaml
    /// </summary>
    public partial class ChatSessionView : Window
    {
        public static Dictionary<int, string> questions = new Dictionary<int, string>();
        public static Dictionary<int, string> answers = new Dictionary<int, string>();
       
        public ChatSessionView()
        {
            InitializeComponent();
            this.DataContext = new MockViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RootWindow_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
