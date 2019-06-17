using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDo.Models
{
    public class DoDoBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Question : DoDoBase
    {

        public List<SubQuestion> SubQuestions { get; set; }

    }

    public class SubQuestion : DoDoBase
    {
        public int Parent { get; set; }
    }

    public class Answers : DoDoBase
    {

    }

    public class Category : DoDoBase
    {
        public List<Question> Questions { get; set; }
    }
}
