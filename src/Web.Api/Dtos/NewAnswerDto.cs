using Core.Entities.Questions;

namespace Web.Api.Dtos
{
    public class NewAnswerDto
    {
        public int QuestionNumber { get; set; }
        public QuestionType QuestionType { get; set; }
        public string AnswerText { get; set; }
    }
}
