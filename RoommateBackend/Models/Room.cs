using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public List<RoomImage> Images { get; set; } = new List<RoomImage>();
        public double Size { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public AppUser Owner { get; set; }
        public string OwnerId { get; set; }
        public List<AppUser> SavedBy { get; set; } = new List<AppUser>();
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}