using System;

namespace Core.Entities
{
    public class DetailedUserInfo : BaseEntity
    {
        public int DetailedUserInfoId { get; set; }
        public int PassedTestCount { get; set; }
        public int CreatedTestCount { get; set; }
        public Gender Gender { get; set; }
        public DateTime RegistrationDate { get; set; }

        public User User { get; set; }
    }
}
