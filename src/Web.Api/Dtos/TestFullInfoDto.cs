using Core.Entities.Questions;
using System;
using System.Collections.Generic;

namespace Web.Api.Dtos
{
    public class TestFullInfoDto
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public int AgeRestriction { get; set; }
        public int QuestionCount { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Question> Questions { get; set; }

        public DetailedTestInfoDto DetailedTestInfo { get; set; }
        public List<string> Tags { get; set; }
        public List<int> AttemptIds { get; set; }
        public int OwnerId { get; set; }
    }
}
