using Core.Entities.Questions;
using System.Collections.Generic;

namespace TestStorage.FileSystem.Entities
{
    public class StoredTest
    {
        public int TestId { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
