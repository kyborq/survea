using Core.Entities;
using System.Collections.Generic;
using Web.Api.Dtos;

namespace Web.Api.Mappings
{
    public static class AttemptMappings
    {
        public static AttemptDto MapToAttemptDto( this PassedTest attempt )
        {
            List<AnswerDto> answerDtos = new List<AnswerDto>();
            foreach ( var answer in attempt.Answers )
            {
                answerDtos.Add( answer.MapToAnswerDto() );
            }
            return new AttemptDto
            {
                TestId = attempt.TestId,
                UserId = attempt.UserId,
                TestPassingId = attempt.TestPassingId,
                Answers = answerDtos,
                FinishedAt = attempt.FinishedAt
            };
        }
    }
}
