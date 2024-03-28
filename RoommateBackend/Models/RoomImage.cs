using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoommateBackend.Models
{
    public class RoomImage
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}