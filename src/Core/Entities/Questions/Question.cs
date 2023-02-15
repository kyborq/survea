using System.Collections.Generic;

namespace Core.Entities.Questions
{
    public class Question
    {
        public string QuestionName { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<string> Choices { get; set; }
    }
}
