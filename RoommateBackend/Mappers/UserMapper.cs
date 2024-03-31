using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoommateBackend.Dtos.User;
using RoommateBackend.Models;

namespace RoommateBackend.Mappers
{
    public static class UserMapper
    {
        public static AppUser ToUser(this CreateUserDto createUserDto)
        {
            return new AppUser
            {
                Email = createUserDto.Email,
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                PhoneNumber = createUserDto.PhoneNumber,
                Job = createUserDto.Job,
                Age = createUserDto.Age,
                CreatedAt = DateTime.Now,
            };
        }

        public static AppUser ToUser(this UpdateUserDto updateUserDto)
        {
            return new AppUser
            {
                FirstName = updateUserDto.FirstName,
                LastName = updateUserDto.LastName,
                ProfilePicture = Convert.FromBase64String(updateUserDto.ProfilePicture),
                Description = updateUserDto.Description,
                Age = updateUserDto.Age,
                Job = updateUserDto.Job,
            };
        }
    }
}