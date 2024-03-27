using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoommateBackend.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int RoomCount { get; set; }
        public int BathCount { get; set; }
        public List<byte[]> Images { get; set; } = new List<byte[]>();
        public Location Location { get; set; }
        public double Size { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public AppUser Owner { get; set; }
        public string OwnerId { get; set; }
        public List<AppUser> SavedBy { get; set; } = new List<AppUser>();
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}