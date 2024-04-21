using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoommateBackend.Dtos.RoomAddress;
using RoommateBackend.Dtos.User;

namespace RoommateBackend.Dtos.Room
{
    public class RoomDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int RoomCount { get; set; }
        public int BathCount { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public double Size { get; set; }
        public string About { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public RoomUserDto Owner { get; set; }
        public List<RoomUserDto> SavedBy { get; set; } = new List<RoomUserDto>();
        public RoomAddressDto Address { get; set; }
    }

    public class RoomsResponse
    {
        public List<RoomDto> Rooms { get; set; } = new List<RoomDto>();
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}