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
        public string Description { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Job { get; set; } = string.Empty;
    }
}