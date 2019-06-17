using System.Collections.Generic;
using System.Windows;
using DoDo.Mock;
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
            this.DataContext = Mocker.GetMockModels();
        }


        
        
    }
}
