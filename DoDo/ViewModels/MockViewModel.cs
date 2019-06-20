using DoDo.Models;
using System.Collections.Generic;
using System.Windows.Input;
using DoDo.Commands;
using System.Collections.ObjectModel;
using DoDo.Speech;
using System.Threading;

namespace DoDo.ViewModels
{
    public class MockViewModel : BaseViewModel
    {
        SpeechSynthezier speechSynthezier = new SpeechSynthezier();
        SpeechRecognize speechRecognize;
        SpeechRecognize speechRecognizeForsearch;
        Subscription<Speech.Speech> subscription;
        public MockViewModel()
        {
            CategorySelectedCommand = new RelayCommand(SelectCommand);
            SelectedCategory = Categories[0];
            GridColumn = 0;
            AnswerPointerSymbolPosition = "0,55,0,0";
            subscription = EventAggregator.getInstance().Subscribe<Speech.Speech>(SubscribedMessage);
        }
        private void SubscribedMessage(Speech.Speech spokenText)
        {
            speechSynthezier.Speak(spokenText.TextSpoken);
        }
        public List<Category> Categories
        {
            get
            {
                return Mock.Mocker.GetMockModels();
            }
        }

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get
            {
                return selectedCategory;
            }
            set
            {
                selectedCategory = value;
                SelectedCategoryQuestions = value.Questions;
                GridColumn = 0;
                AnswerVisibility = false;
                OnPropertyChanged("SelectedCategory");
            }
        }

        private Question selectedQuestion;
        public Question SelectedQuestion
        {
            get
            {
                return selectedQuestion;
            }
            set
            {
                selectedQuestion = value;
                int selectedQuestionIndex = 0;
                if (value != null)
                {
                    selectedQuestionIndex = SelectedCategoryQuestions.FindIndex(x => x.Text == value.Text);
                }
                AnswerPointerSymbolPosition = "0," + (selectedQuestionIndex + 1) * 55 + ",0,0";
                if (SelectedQuestion != null)
                {
                    if (SelectedQuestion.Answers.Count > 1)
                    {
                        SelectedQuestionAnswerDisplay = SelectedQuestion.Answers[0].Text;
                    }
                    else
                    {
                        SelectedQuestionAnswerDisplay = selectedQuestion.Answers[0].Text;
                    }

                    speechSynthezier.Speak(SelectedQuestionAnswerDisplay);
                }
                else
                {
                    SelectedQuestionAnswerDisplay = "";
                }
                AnswerVisibility = true;
                GridColumn = 1;
                OnPropertyChanged("SelectedQuestion");
            }
        }

        private string answerPointerSymbolPosition;
        public string AnswerPointerSymbolPosition
        {
            get
            {
                return answerPointerSymbolPosition;
            }
            set
            {
                answerPointerSymbolPosition = value;
                OnPropertyChanged("AnswerPointerSymbolPosition");

            }
        }

        private string _selectedQuestionAnswerDisplay;
        public string SelectedQuestionAnswerDisplay {
            get { return _selectedQuestionAnswerDisplay; }
            set
            {
                _selectedQuestionAnswerDisplay = value;
                OnPropertyChanged("SelectedQuestionAnswerDisplay");
            }
        }

        private bool answerVisibility;
        public bool AnswerVisibility
        {
            get
            {
                return answerVisibility;
            }
            set
            {
                answerVisibility = value;
                OnPropertyChanged("AnswerVisibility");

            }
        }
        private string searchedText;
        public string SearchedText
        {
            get
            {
                return searchedText;
            }
            set
            {
                searchedText = value;
                OnPropertyChanged("SearchedText");

            }
        }
        

        private int gridColumn;
        public int GridColumn
        {
            get
            {
                return gridColumn;
            }
            set
            {
                gridColumn = value;
                OnPropertyChanged("GridColumn");

            }
        }

        private bool isVoiceEnabled;
        public bool IsVoiceEnabled
        {
            get
            {
                return isVoiceEnabled;
            }
            set
            {
                if(value)
                {
                    List<string> list = new List<string>();
                    list.Add("eligibility");
                    speechRecognizeForsearch = new SpeechRecognize(list);
                }
                else
                {
                    speechRecognizeForsearch.Stop();
                }
                isVoiceEnabled = value;
                OnPropertyChanged("IsVoiceEnabled");

            }
        }


        private List<Question> selectedCategoryQuestions;
        public List<Question> SelectedCategoryQuestions
        {
            get
            {
                return selectedCategoryQuestions;
            }
            set
            {
                selectedCategoryQuestions = value;
                SelectedQuestion = value[0];
                OnPropertyChanged("SelectedCategoryQuestions");
            }
        }




        public ICommand CategorySelectedCommand { get; set; }


        public ICommand VoiceClick { get; set; }
        private  void SelectCommand(object parms)
        {
            Category category = (Category)parms;
            SelectedCategory = category;
            SelectedCategoryQuestions = new List<Question>(category.Questions);
        }


    }
}
