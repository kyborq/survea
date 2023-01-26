using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class PassedTest : BaseEntity
    {
        public int TestPassingId { get; set; }      
        public DateTime FinishedAt { get; set; }

        public int UserId { get; set; } 
        public User User { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
