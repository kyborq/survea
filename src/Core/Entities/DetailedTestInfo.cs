namespace Core.Entities
{
    public class DetailedTestInfo : BaseEntity
    {
        public int DetailedTestInfoId { get; set; }
        public int AverageTestCompletionTime { get; set; }
        public int AttemptCount { get; set; }

        public Test Test { get; set; }
    }
}
