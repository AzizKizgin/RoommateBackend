using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoommateBackend.Helpers;
using RoommateBackend.Models;

namespace RoommateBackend.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomById(int id);
        Task<IEnumerable<Room>> GetRooms(RoomQueryObject queryObject);
        Task<IEnumerable<Room>> GetRoomByUserId(int userId);
        Task<IEnumerable<Room>> GetUserSavedRooms(int userId);
        Task<Room?> CreateRoom(Room room);
        Task<Room?> UpdateRoom(Room room);
        Task<Room?> DeleteRoom(int id);
    }
}