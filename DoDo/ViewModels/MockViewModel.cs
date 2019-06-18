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
                OnPropertyChanged("SelectedQuestion");
            }
        }

        public string QuestionText
        {
            get
            {
                if (SelectedQuestion != null)
                {
                    return SelectedQuestion.Text;
                }
                else
                {
                    return "";
                }
            }
        }



        public string SelectedQuestionAnswer
        {
            get
            {
                if (SelectedQuestion != null)
                {
                    if (SelectedQuestion.Answers.Count > 1)
                    {
                        return SelectedQuestion.Answers[0].Text;
                    }
                    else
                    {
                        return selectedQuestion.Answers[0].Text;
                    }
                }
                else
                {
                    return "";
                }
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

        private bool prevQVisibility;
        public bool PrevQVisibility
        {
            get
            {
                return prevQVisibility;
            }
            set
            {
                prevQVisibility = value;
                OnPropertyChanged("PrevQVisibility");

            }
        }

        private bool selecteQVisibility;
        public bool SelecteQVisibility
        {
            get
            {
                return selecteQVisibility;
            }
            set
            {
                selecteQVisibility = value;
                OnPropertyChanged("SelecteQVisibility");

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
