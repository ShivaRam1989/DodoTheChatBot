using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Models
{
    [Serializable]
    public class DODO
    {
        public List<Category> Categories { get; set; }
    }

    [Serializable]
    public class DoDoBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }

    [Serializable]
    public class Question : DoDoBase
    {

        public List<SubQuestion> SubQuestions { get; set; }

        public List<Answer> Answers { get; set; }

        public string Text { get; set; }

    }

    [Serializable]
    public class SubQuestion : DoDoBase
    {
        public int Parent { get; set; }

        public string Text { get; set; }
    }

    [Serializable]
    public class Answer : DoDoBase
    {
        public string Text { get; set; }
    }

    [Serializable]
    public class Category : DoDoBase
    {
        public List<Question> Questions { get; set; }

        public string Text { get; set; }
    }
}
