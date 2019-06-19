using DoDo.Models;
using System.Collections.Generic;
using System.Windows.Input;
using DoDo.Commands;
using System.Collections.ObjectModel;

namespace DoDo.ViewModels
{
    public class MockViewModel : BaseViewModel
    {
        public MockViewModel()
        {
            CategorySelectedCommand = new RelayCommand(SelectCommand);
            SelectedCategory = Categories[0];
            GridColumn = 0;
            AnswerPointerSymbolPosition = "0,55,0,0";
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
            get => _selectedQuestionAnswerDisplay;
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

        private bool isPopupOpen;
        public bool IsPopupOpen
        {
            get
            {
                return isPopupOpen;
            }
            set
            {
                isPopupOpen = value;
                OnPropertyChanged("IsPopupOpen");

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
                OnPropertyChanged("SelectedCategoryQuestions");
            }
        }




        public ICommand CategorySelectedCommand { get; set; }
      

        private  void SelectCommand(object parms)
        {
            Category category = (Category)parms;
            SelectedCategory = category;
            SelectedCategoryQuestions = new List<Question>(category.Questions);
        }



    }
}
