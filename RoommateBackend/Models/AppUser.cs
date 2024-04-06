using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RoommateBackend.Models
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<Room> SavedRooms { get; set; } = new List<Room>();
        public DateTime CreatedAt { get; set; }
        public string About { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Job { get; set; } = string.Empty;
    }
}