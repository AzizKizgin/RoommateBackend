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
                BirthDate = createUserDto.BirthDate,
                CreatedAt = DateTime.Now,
                UserName = createUserDto.Email,
            };
        }

        public static AppUser ToUser(this UpdateUserDto updateUserDto)
        {
            return new AppUser
            {
                FirstName = updateUserDto.FirstName,
                LastName = updateUserDto.LastName,
                ProfilePicture = updateUserDto.ProfilePicture == string.Empty ? null : Convert.FromBase64String(updateUserDto.ProfilePicture),
                About = updateUserDto.About,
                BirthDate = updateUserDto.BirthDate,
                Job = updateUserDto.Job,
                PhoneNumber = updateUserDto.PhoneNumber,
            };
        }

        public static RoomUserDto ToRoomOwnerDto(this AppUser appUser)
        {
            return new RoomUserDto
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                ProfilePicture = appUser.ProfilePicture != null ? Convert.ToBase64String(appUser.ProfilePicture) : string.Empty,
                About = appUser.About,
                BirthDate = appUser.BirthDate.ToString("dd-MM-yyyy").Replace('-' , '.' ),
                Job = appUser.Job,
                CreatedAt = appUser.CreatedAt,
            };
        }

        public static UserDto ToUserDto(this AppUser appUser)
        {
            return new UserDto
            {
                Id = appUser.Id,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                ProfilePicture = appUser.ProfilePicture != null ? Convert.ToBase64String(appUser.ProfilePicture) : string.Empty,
                About = appUser.About,
                BirthDate = appUser.BirthDate.ToString("dd-MM-yyyy").Replace('-' , '.' ),
                Job = appUser.Job,
                CreatedAt = appUser.CreatedAt,
                Rooms = appUser.Rooms.Select(room => room.ToRoomDto()).ToList(),
                SavedRooms = appUser.SavedRooms.Select(room => room.ToRoomDto()).ToList(),
                Email = appUser.Email ?? string.Empty,
                PhoneNumber = appUser.PhoneNumber ?? string.Empty,
            };
        }
    }
}