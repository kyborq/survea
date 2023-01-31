using System.Collections.Generic;

namespace Web.Api.Dtos
{
    public class NewAttemptDto
    {
        public int TestId { get; set; }
        public List<NewAnswerDto> Answers { get; set; }
    }
}
