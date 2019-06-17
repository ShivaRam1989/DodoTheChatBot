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
            SelectedCategory = Categories[0].Name;
            SelectedCategoryQuestions = new ObservableCollection<Question>(Categories[0].Questions);

        }

        public List<Category> Categories
        {
            get
            {
                return Mock.Mocker.GetMockModels();
            }
        }

        private string selectedCategory;
        public string SelectedCategory
        {
            get
            {
                return selectedCategory;
            }
            set
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        private ObservableCollection<Question> selectedCategoryQuestions;
        public ObservableCollection<Question> SelectedCategoryQuestions
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
            SelectedCategory = category.Name;
            SelectedCategoryQuestions = new ObservableCollection<Question>(category.Questions);
        }



    }
}
