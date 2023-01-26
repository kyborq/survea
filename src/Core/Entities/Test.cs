using Core.Entities.Questions;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Test : BaseEntity
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public int AgeRestriction { get; set; }
        public int QuestionCount { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public int DetailedTestInfoId { get; set; }
        public DetailedTestInfo DetailedTestInfo { get; set; }

        public List<Tag> Tags { get; set; }
        public List<PassedTest> Attempts { get; set; }
        
        public List<Question> Questions { get; set; }
    }
}
