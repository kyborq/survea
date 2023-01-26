using Core.Entities;
using System;

namespace Web.Api.Dtos
{
    public class DetailedUserInfoDto
    {
        public int PassedTestCount { get; set; }
        public int CreatedTestCount { get; set; }
        public Gender Gender { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
