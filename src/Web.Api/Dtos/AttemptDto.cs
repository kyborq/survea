using System;
using System.Collections.Generic;

namespace Web.Api.Dtos
{
    public class AttemptDto
    {
        public int TestPassingId { get; set; }
        public DateTime FinishedAt { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
