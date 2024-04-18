using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoommateBackend.Data;
using RoommateBackend.Dtos.Room;
using RoommateBackend.Helpers;
using RoommateBackend.Mappers;
using RoommateBackend.Models;
using RoommateBackend.Repositories.Interfaces;

namespace RoommateBackend.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        public RoomRepository(ApplicationDBContext context, UserManager<AppUser> userManger)
        {
            _context = context;
            _userManager = userManger;
        }

        public async Task<Room?> CreateRoom(CreateRoomDto room, string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            var newRoom = room.ToRoomFromCreateRoomDto();
            newRoom.Owner = user;
            newRoom.OwnerId = user.Id;
            var result = await _context.Rooms.AddAsync(newRoom);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Room?> DeleteRoom(int id, string userId)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return null;
            }
            if (room.OwnerId != userId)
            {
                return null;
            }
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room?> FavoriteRoom(string userId, int roomId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return null;
            }
            var room = await _context.Rooms
                            .Include(r => r.SavedBy)
                            .Include(r => r.Owner)
                            .FirstOrDefaultAsync(r => r.Id == roomId);
            if (room == null)
            {
                return null;
            }
            if (room.SavedBy.Contains(user) || room.OwnerId == userId)
            {
                return null;
            }
            room.SavedBy.Add(user);
            user.SavedRooms.Add(room);
            await _context.SaveChangesAsync();
            await _userManager.UpdateAsync(user);
            return room;
        }

        public async Task<Room?> GetRoomById(int id)
        {
            var room = await _context.Rooms
                            .Include(r => r.Owner)
                            .Include(r => r.Address)
                            .Include(r => r.SavedBy)
                            .Include(r => r.Images)
                            .FirstOrDefaultAsync(r => r.Id == id);
            return room;
        }

        public async Task<IEnumerable<Room>> GetRooms(RoomQueryObject queryObject)
        {
            var rooms = _context.Rooms
                            .Include(r => r.Owner)
                            .Include(r => r.Address)
                            .Include(r => r.SavedBy)
                            .Include(r => r.Images)
                            .AsQueryable();
            if (queryObject.MinPrice.HasValue)
            {
                rooms = rooms.Where(r => r.Price >= queryObject.MinPrice);
            }
            if (queryObject.MaxPrice.HasValue)
            {
                rooms = rooms.Where(r => r.Price <= queryObject.MaxPrice);
            }
            if (queryObject.MinRoomCount.HasValue)
            {
                rooms = rooms.Where(r => r.RoomCount >= queryObject.MinRoomCount);
            }
            if (queryObject.MaxRoomCount.HasValue)
            {
                rooms = rooms.Where(r => r.RoomCount <= queryObject.MaxRoomCount);
            }
            if (queryObject.MinBathCount.HasValue)
            {
                rooms = rooms.Where(r => r.BathCount >= queryObject.MinBathCount);
            }
            if (queryObject.MaxBathCount.HasValue)
            {
                rooms = rooms.Where(r => r.BathCount <= queryObject.MaxBathCount);
            }
            if (queryObject.MinSize.HasValue)
            {
                rooms = rooms.Where(r => r.Size >= queryObject.MinSize);
            }
            if (queryObject.MaxSize.HasValue)
            {
                rooms = rooms.Where(r => r.Size <= queryObject.MaxSize);
            }
            if (queryObject.City != null)
            {
                rooms = rooms.Where(r => r.Address.City == queryObject.City);
            }
            if (queryObject.Town != null)
            {
                rooms = rooms.Where(r => r.Address.Town == queryObject.Town);
            }
            if (queryObject.Country != null)
            {
                rooms = rooms.Where(r => r.Address.Country == queryObject.Country);
            }
            if (queryObject.Street != null)
            {
                rooms = rooms.Where(r => r.Address.Street == queryObject.Street);
            }
            if (queryObject.SortBy != null)
            {
                rooms = queryObject.SortDirection switch
                {
                    SortDirection.Asc => queryObject.SortBy switch
                    {
                        SortByProperty.Price => rooms.OrderBy(r => r.Price),
                        SortByProperty.RoomCount => rooms.OrderBy(r => r.RoomCount),
                        SortByProperty.BathCount => rooms.OrderBy(r => r.BathCount),
                        SortByProperty.Size => rooms.OrderBy(r => r.Size),
                        _ => rooms
                    },
                    SortDirection.Desc => queryObject.SortBy switch
                    {
                        SortByProperty.Price => rooms.OrderByDescending(r => r.Price),
                        SortByProperty.RoomCount => rooms.OrderByDescending(r => r.RoomCount),
                        SortByProperty.BathCount => rooms.OrderByDescending(r => r.BathCount),
                        SortByProperty.Size => rooms.OrderByDescending(r => r.Size),
                        _ => rooms
                    },
                    _ => rooms
                };
            }
            if (queryObject.DateRange != null)
            {
                rooms = queryObject.DateRange switch
                {
                    DateRange.Today => rooms.Where(r => r.CreatedAt.Date == DateTime.Today),
                    DateRange.ThisWeek => rooms.Where(r => r.CreatedAt.Date >= DateTime.Today.AddDays(-7)),
                    DateRange.ThisMonth => rooms.Where(r => r.CreatedAt.Date >= DateTime.Today.AddDays(-30)),
                    DateRange.ThisYear => rooms.Where(r => r.CreatedAt.Date >= DateTime.Today.AddDays(-365)),
                    _ => rooms
                };
            }
            if (queryObject.Distance.HasValue && queryObject.Latitude != null && queryObject.Longitude != null)
            {
                double maxLat = (double)(queryObject.Latitude + (queryObject.Distance / 111.0)); // Approx. 111 km per degree of latitude
                double minLat = (double)(queryObject.Latitude - (queryObject.Distance / 111.0));
                double maxLon = (double)(queryObject.Longitude + (queryObject.Distance / (111.0 * Math.Cos((double)(queryObject.Latitude * Math.PI / 180.0)))));
                double minLon = (double)(queryObject.Longitude - (queryObject.Distance / (111.0 * Math.Cos((double)(queryObject.Latitude * Math.PI / 180.0)))));
                rooms = rooms.Where(r => r.Address.Latitude <= maxLat && r.Address.Latitude >= minLat && r.Address.Longitude <= maxLon && r.Address.Longitude >= minLon);
            }
            return await rooms
                        .Skip((queryObject.Page - 1) * queryObject.PageSize)
                        .Take(queryObject.PageSize)
                        .ToListAsync();
        }

        public async Task<Room?> UpdateRoom(int id, string userId, UpdateRoomDto room)
        {
            var existingRoom = await _context.Rooms.FindAsync(id);
            if (existingRoom == null)
            {
                return null;
            }
            if (existingRoom.OwnerId != userId)
            {
                return null;
            }
            existingRoom.Price = Convert.ToDouble(room.Price);
            existingRoom.RoomCount = Convert.ToInt32(room.RoomCount);
            existingRoom.BathCount = Convert.ToInt32(room.BathCount);
            existingRoom.Images = room.Images.Select(i => Convert.FromBase64String(i)).ToList();
            existingRoom.Size = Convert.ToDouble(room.Size);
            existingRoom.About = room.About;
            existingRoom.UpdatedAt = room.UpdatedAt;
            existingRoom.Address.UpdateRoomAddress(room.Address);
            var result = _context.Rooms.Update(existingRoom);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}