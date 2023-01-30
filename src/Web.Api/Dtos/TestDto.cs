using Core.Entities.Questions;
using System;
using System.Collections.Generic;

namespace Web.Api.Dtos
{
    public class TestDto
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public int AgeRestriction { get; set; }
        public int QuestionCount { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Question> Questions { get; set; }
    }
}
