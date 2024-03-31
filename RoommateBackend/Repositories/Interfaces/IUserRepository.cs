using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoommateBackend.Dtos.User;
using RoommateBackend.Models;

namespace RoommateBackend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetUserById(int id);
        Task<AppUser?> CreateUser(CreateUserDto user);
        Task<AppUser?> UpdateUser(int id, UpdateUserDto user);
        Task<AppUser?> DeleteUser(int id);
    }
}