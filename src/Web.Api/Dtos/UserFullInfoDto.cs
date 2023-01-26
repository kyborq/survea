using Core.Entities;
using System;
using System.Collections.Generic;

namespace Web.Api.Dtos
{
    public class UserFullInfoDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public AccountMode AccountMode { get; set; }

        public DetailedUserInfoDto DetailedUserInfo { get; set; }
        public List<string> Tags { get; set; }
        public List<int> TestIds { get; set; }
    }
}
