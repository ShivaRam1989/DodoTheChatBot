using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using DoDo.Models;
namespace DoDo.Mock
{
    public class Mocker
    {
        //static SubQuestion sQ1 = new SubQuestion { Id = "1", Name = "SubQuestion1", Parent = 1 };
        //static SubQuestion sQ2 = new SubQuestion { Id = "2", Name = "SubQuestion2", Parent = 1 };
        //static SubQuestion sQ3 = new SubQuestion { Id = "3", Name = "SubQuestion3", Parent = 2 };
        //static SubQuestion sQ4 = new SubQuestion { Id = "4", Name = "SubQuestion4", Parent = 2 };
        //static SubQuestion sQ5 = new SubQuestion { Id = "5", Name = "SubQuestion5", Parent = 3 };
        //static SubQuestion sQ6 = new SubQuestion { Id = "6", Name = "SubQuestion6", Parent = 3 };

           public static string debugPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


        //static Question question1 = new Question { Id = "1", Name = "Question1", SubQuestions = new List<SubQuestion> { sQ1, sQ2 } };
        //static Question question2 = new Question { Id = "2", Name = "Question2", SubQuestions = new List<SubQuestion> { sQ3, sQ4 } };
        //static Question question3 = new Question { Id = "3", Name = "Question3", SubQuestions = new List<SubQuestion> { sQ5, sQ6 } };

        //static Category c1 = new Category() { Id = "1", Name = "Category1", Questions = new List<Question> { question1, question2, question3 } };


        //static SubQuestion sQ7 = new SubQuestion { Id = "7", Name = "SubQuestion7", Parent = 1 };
        //static SubQuestion sQ8 = new SubQuestion { Id = "8", Name = "SubQuestion8", Parent = 1 };
        //static SubQuestion sQ9 = new SubQuestion { Id = "9", Name = "SubQuestion9", Parent = 2 };
        //static SubQuestion sQ10 = new SubQuestion { Id = "10", Name = "SubQuestion10", Parent = 2 };
        //static SubQuestion sQ11 = new SubQuestion { Id = "11", Name = "SubQuestion11", Parent = 3 };
        //static SubQuestion sQ12 = new SubQuestion { Id = "12", Name = "SubQuestion12", Parent = 3 };




        //static Question question4 = new Question { Id = "4", Name = "Question4", SubQuestions = new List<SubQuestion> { sQ7, sQ8 } };
        //static Question question5 = new Question { Id = "5", Name = "Question5", SubQuestions = new List<SubQuestion> { sQ9, sQ10 } };
        //static Question question6 = new Question { Id = "6", Name = "Question6", SubQuestions = new List<SubQuestion> { sQ11, sQ12 } };

        //static Category c2 = new Category() { Id = "2", Name = "Category2", Questions = new List<Question> { question4, question5, question6 } };

        public static List<Category> GetMockModels()
        {
            List<Category> categories = null;
            XmlSerializer serializer = new XmlSerializer(typeof(DODO), new XmlRootAttribute("DODO"));
            //string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            using (TextReader reader = new StreamReader(Path.Combine(debugPath, "Data.xml")))
            {
                categories = ((DODO)serializer.Deserialize(reader)).Categories;
            }
            return categories;

        }
    }
}
