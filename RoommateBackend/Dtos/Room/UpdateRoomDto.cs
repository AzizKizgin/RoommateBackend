using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoommateBackend.Dtos.RoomAddress;

namespace RoommateBackend.Dtos.Room
{
    public class UpdateRoomDto
    {
        public string Price { get; set; }
        public string RoomCount { get; set; }
        public string BathCount { get; set; }
        public string Size { get; set; }
        public string About { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public RoomAddressDto Address { get; set; }
        public List<string> Images { get; set; } = new List<string>();
    }
}