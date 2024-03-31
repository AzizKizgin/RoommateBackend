using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoommateBackend.Dtos.RoomAddress;

namespace RoommateBackend.Dtos.Room
{
    public class UpdateRoomDto
    {
        public double Price { get; set; }
        public int RoomCount { get; set; }
        public int BathCount { get; set; }
        public double Size { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public RoomAddressDto Address { get; set; }
        public List<string> Images { get; set; } = new List<string>();
    }
}