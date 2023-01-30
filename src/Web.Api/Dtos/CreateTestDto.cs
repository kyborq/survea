using Core.Entities.Questions;
using System.Collections.Generic;

namespace Web.Api.Dtos
{
    public class CreateTestDto
    {
        public string Name { get; set; }
        public int AgeRestriction { get; set; }
        public string Description { get; set; }

        public List<string> Tags { get; set; }

        public List<Question> Questions { get; set; }
    }
}
