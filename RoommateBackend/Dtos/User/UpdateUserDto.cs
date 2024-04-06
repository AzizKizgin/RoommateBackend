using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoommateBackend.Dtos.User
{
    public class UpdateUserDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string ProfilePicture { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Job { get; set; } = string.Empty;
        
    }
}