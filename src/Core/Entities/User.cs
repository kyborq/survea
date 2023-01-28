using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public AccountMode AccountMode { get; set; }
        public string PasswordHash { get; set; }
        
        public List<Tag> Tags { get; set; }
        public List<Test> Tests { get; set; }
        public List<PassedTest> PassedTests { get; set; }

        public int ReferalCodeId { get; set; }
        public ReferalCode ReferalCode { get; set; }

        public int DetailedUserInfoId { get; set; }
        public DetailedUserInfo DetailedUserInfo { get; set; }
    }
}
