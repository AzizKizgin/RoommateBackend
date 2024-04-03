using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoommateBackend.Dtos.Room;
using RoommateBackend.Helpers;
using RoommateBackend.Models;

namespace RoommateBackend.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room?> GetRoomById(int id);
        Task<IEnumerable<Room>> GetRooms(RoomQueryObject queryObject);
        Task<Room?> FavoriteRoom(string userId, int roomId);
        Task<Room?> CreateRoom(CreateRoomDto room);
        Task<Room?> UpdateRoom(int id, string userId, UpdateRoomDto room);
        Task<Room?> DeleteRoom(int id, string userId);
    }
}