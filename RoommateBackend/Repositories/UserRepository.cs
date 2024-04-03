using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoommateBackend.Data;
using RoommateBackend.Dtos.User;
using RoommateBackend.Mappers;
using RoommateBackend.Models;
using RoommateBackend.Repositories.Interfaces;

namespace RoommateBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        
        public UserRepository(ApplicationDBContext context, UserManager<AppUser> userManger)
        {
            _context = context;
            _userManager = userManger;
        }

        public async Task<AppUser?> CreateUser(CreateUserDto user)
        {
            var newUser = user.ToUser();
            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                var userRoleResult = await _userManager.AddToRoleAsync(newUser, "User");
                if (!userRoleResult.Succeeded)
                {
                    await _userManager.DeleteAsync(newUser);
                    return null;
                }
            }
            return newUser;
        }

        public async Task<AppUser?> DeleteUser(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return null;
            }
            else
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
        }

        public Task<AppUser?> GetUserById(string id)
        {
            var user = _context.Users
                            .Include(u => u.Rooms)
                            .FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<AppUser?> UpdateUser(string id, UpdateUserDto user)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (userToUpdate == null)
            {
                return null;
            }
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.ProfilePicture = Convert.FromBase64String(user.ProfilePicture);
            userToUpdate.Description = user.Description;
            userToUpdate.Age = user.Age;
            userToUpdate.Job = user.Job;
            var result = _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<AppUser?> LoginUser(LoginUserDto user)
        {
            var userToLogin = await _userManager.FindByEmailAsync(user.Email);
            if (userToLogin != null)
            {
                var result = await _userManager.CheckPasswordAsync(userToLogin, user.Password);
                if (result)
                {
                    return userToLogin;
                }
            }
            return null;
        }

        public async Task<IEnumerable<Room>> GetRoomByUserId(string userId)
        {
            var room = await _context.Rooms
                            .Include(r => r.Owner)
                            .Include(r => r.Address)
                            .Where(r => r.OwnerId == userId)
                            .ToListAsync();
            return room;
        }

        public async Task<IEnumerable<Room>> GetUserSavedRooms(string userId)
        {
            var rooms = _context.Rooms
                            .Include(r => r.Owner)
                            .Include(r => r.Address)
                            .Where(r => r.SavedBy.Any(u => u.Id == userId));
            return await rooms.ToListAsync();
        }
    }
}