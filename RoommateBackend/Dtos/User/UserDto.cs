using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoommateBackend.Dtos.Room;

namespace RoommateBackend.Dtos.User
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string? ProfilePicture { get; set; }
        public List<RoomDto> Rooms { get; set; } = new List<RoomDto>();
        public List<RoomDto> SavedRooms { get; set; } = new List<RoomDto>();
        public DateTime CreatedAt { get; set; }
        public string About { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Job { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Token { get; set; }
    }
}