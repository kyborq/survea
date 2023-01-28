using Core.Entities;
using System;

namespace Web.Api.Dtos
{
    public class RegisterUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AccountMode AccountMode { get; set; }
        public string Password { get; set; }
    }
}
