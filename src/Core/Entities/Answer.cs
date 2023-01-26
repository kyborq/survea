using Core.Entities.Questions;

namespace Core.Entities
{
    public class Answer : BaseEntity
    {
        public int AnswerId { get; set; }
        public int QuestionNumber { get; set; }
        public QuestionType QuestionType { get; set; }
        public string AnswerText { get; set; }

        public int TestPassingId { get; set; }
        public PassedTest TestPassing { get; set; }
    }
}
