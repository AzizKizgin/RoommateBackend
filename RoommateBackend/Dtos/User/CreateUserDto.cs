using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoommateBackend.Dtos.User
{
    public class CreateUserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}