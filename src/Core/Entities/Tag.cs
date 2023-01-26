using System.Collections.Generic;

namespace Core.Entities
{
    public class Tag : BaseEntity
    {
        public int TagId { get; set; }
        public string TagValue { get; set; }

        public List<User> Users { get; set; }
        public List<Test> Tests { get; set; }
    }
}
