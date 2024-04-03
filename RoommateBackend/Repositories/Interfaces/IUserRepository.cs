using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using RoommateBackend.Dtos.User;
using RoommateBackend.Models;

namespace RoommateBackend.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetUserById(string id);
        Task<IdentityResult?> CreateUser(CreateUserDto user);
        Task<AppUser?> UpdateUser(string id, UpdateUserDto user);
        Task<AppUser?> DeleteUser(string id);
    }
}