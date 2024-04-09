using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoommateBackend.Dtos.User
{
    public class RoomUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string About { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string Job { get; set; } = string.Empty;
    }
}