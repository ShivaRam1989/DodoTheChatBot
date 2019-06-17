using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            FillDictionary();
            BindListbox();
        }

        private void BindListbox()
        {
            foreach (string item in questions.Values)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = item;                
                mybox.Items.Add(itm);
            }
        }

        public object listbox { get; private set; }

        private void FillDictionary()
        {
            questions.Add(1, "What is Python Academy?");
            answers.Add(1, "Academy to provide hands on experience for Python.");
            questions.Add(2, "What is the duration of Python Academy?");
            answers.Add(2, "Academy is for 3 weeks.");
            questions.Add(3, "Who will be benefited from Python Academy?");
            answers.Add(3, "Who wants to learn python and wants to automate repetitive task.");
            questions.Add(4, "Who can join the Python Academy? What are the pre-requisites for joining Python Academy?");
            answers.Add(4, "Who has bisc programing knowledge.");
            questions.Add(5, "When is the Python Academy starting?");
            answers.Add(5, "1st July,2019");
            questions.Add(6, "How many hours do I need to spend in Python Academy?");
            answers.Add(6, "6 hour for 3 days");
            questions.Add(7, "How do I join Python Academy?");
            answers.Add(7, "By using this registration link :");
            questions.Add(8, "Is this an online or classroom training?");
            answers.Add(8, "Classroom training");
            questions.Add(9, "I know C/C++/Java/some other programming language. Will Python Academy be beneficial for me?");
            answers.Add(9, "Yes, as it is basic langauge for machine learning");


        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            dynamic selection = mybox.SelectedItem ;
            object id = ((System.Windows.Controls.ContentControl)selection).Content;

            int key = questions.FirstOrDefault(x => x.Value == id.ToString()).Key;
            string result = "";
            answers.TryGetValue(key, out result);
            Results.Text = result;

            string qq = "";
            int index = key + 1;

            List<int> set = new List<int>();
            while (index != key)
            {
                
                if (index > questions.Count)
                {
                    index = 0;
                    
                }
                set.Add(index);
                 index++;
               
            }
            RelativeQQ.Items.Clear();
            foreach( int i in set)
            {
                ListBoxItem item = new ListBoxItem();
                string value = "";
                questions.TryGetValue(i, out value);
                if(!string.IsNullOrWhiteSpace(value))
                {
                    item.Content = value;
                    RelativeQQ.Items.Add(item);
                }
                
            }
            

        }

        private void RelativeQQ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RelativeResults.Visibility = Visibility.Visible;
            mybox.Visibility = Visibility.Hidden;
            Results.Visibility = Visibility.Hidden;

            dynamic selection = RelativeQQ.SelectedItem;
            object id = ((System.Windows.Controls.ContentControl)selection).Content;

            int key = questions.FirstOrDefault(x => x.Value == id.ToString()).Key;
            string result = "";
            answers.TryGetValue(key, out result);
            RelativeResults.Text = "Que: "+ id  + "\nAns: "+result;
        }
    }
}
