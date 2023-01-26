using Core.Entities;
using System;

namespace Web.Api.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public AccountMode AccountMode { get; set; }
    }
}
