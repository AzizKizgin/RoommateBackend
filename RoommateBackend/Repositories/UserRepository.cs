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
        private readonly SignInManager<AppUser> _signInManager;
        
        public UserRepository(
            ApplicationDBContext context, 
            UserManager<AppUser> userManger, 
            SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManger;
            _signInManager = signInManager;
        }

        public async Task<AppUser?> CreateUser(CreateUserDto user)
        {
            if ((await _userManager.FindByEmailAsync(user.Email)) != null)
            {
                throw new Exception("Email already exists.");
            }
            var newUser = user.ToUser();
            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (result.Errors.Any())
            {
                throw new Exception(result.Errors.First().Description);
            }
            if (result.Succeeded)
            {
                var userRoleResult = await _userManager.AddToRoleAsync(newUser, "User");
                if (!userRoleResult.Succeeded)
                {
                    await _userManager.DeleteAsync(newUser);
                    throw new Exception("Failed to add user role.");
                }
                return newUser;
            }
            if (result.Errors.Any())
            {
                throw new Exception(result.Errors.First().Description);
            }
            throw new Exception("Failed to create user.");
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
                await _userManager.DeleteAsync(user);
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
            userToUpdate.ProfilePicture = user.ProfilePicture == string.Empty  ? null : Convert.FromBase64String(user.ProfilePicture);
            userToUpdate.About = user.About;
            userToUpdate.BirthDate = user.BirthDate;
            userToUpdate.Job = user.Job;
            userToUpdate.PhoneNumber = user.PhoneNumber;
            var result = _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<AppUser?> LoginUser(LoginUserDto user)
        {
            var userToLogin = await _userManager.FindByEmailAsync(user.Email);
            if (userToLogin != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(userToLogin, user.Password, false);
                if (result.Succeeded)
                {
                    return userToLogin;
                }
                else
                {
                    throw new Exception("Invalid password.");
                }
            }
            throw new Exception("User not found with this email.");
        }
        
        public async Task LogoutUser()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception)
            {
                throw new Exception("User could not be logged out.");
            }
        }

        public async Task<Room?> GetRoomByUserId(string userId)
        {
            var room = _context.Rooms
                            .Include(r => r.Owner)
                            .Include(r => r.Address)
                            .FirstOrDefault(r => r.OwnerId == userId);
            if (room == null)
            {
                return null;
            }
            return room;
        }

        public async Task<IEnumerable<Room>> GetUserSavedRooms(string userId)
        {
            var rooms = _context.Rooms
                            .Include(r => r.Owner)
                            .Include(r => r.Address)
                            .Include(r => r.SavedBy)
                            .Where(r => r.SavedBy.Any(u => u.Id == userId));
            return await rooms.ToListAsync();
        }

        public async Task<AppUser?> ChangePassword(string id, ChangePasswordDto password)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            var result = await _userManager.ChangePasswordAsync(user, password.OldPassword, password.NewPassword);
            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }
    }
}