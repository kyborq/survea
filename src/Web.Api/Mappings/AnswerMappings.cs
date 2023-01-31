using Core.Entities;
using Web.Api.Dtos;

namespace Web.Api.Mappings
{
    public static class AnswerMappings
    {
        public static AnswerDto MapToAnswerDto( this Answer answer )
        {
            return new AnswerDto
            {
                AnswerText = answer.AnswerText,
                QuestionNumber = answer.QuestionNumber,
                QuestionType = answer.QuestionType
            };
        }
    }
}
