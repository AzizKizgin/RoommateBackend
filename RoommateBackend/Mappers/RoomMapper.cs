using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoommateBackend.Dtos.Room;
using RoommateBackend.Models;

namespace RoommateBackend.Mappers
{
    public static class RoomMapper
    {
        public static Room ToRoomFromCreateRoomDto(this CreateRoomDto createRoomDto)
        {
            return new Room
            {
                Price = createRoomDto.Price,
                RoomCount = createRoomDto.RoomCount,
                BathCount = createRoomDto.BathCount,
                Size = createRoomDto.Size,
                About = createRoomDto.About,
                CreatedAt = createRoomDto.CreatedAt,
                Address = createRoomDto.Address.ToRoomAddress(),
                Images = createRoomDto.Images.Select(
                    image => Convert.FromBase64String(image)
                ).ToList(),
 
            };
        }

        public static Room ToRoomFromUpdateRoomDto(this UpdateRoomDto updateRoomDto)
        {
            return new Room
            {
                Price = updateRoomDto.Price,
                RoomCount = updateRoomDto.RoomCount,
                BathCount = updateRoomDto.BathCount,
                Size = updateRoomDto.Size,
                About = updateRoomDto.About,
                UpdatedAt = updateRoomDto.UpdatedAt,
                Address = updateRoomDto.Address.ToRoomAddress(),
                Images = updateRoomDto.Images.Select(
                    image => Convert.FromBase64String(image)
                ).ToList(),
            };
        }

        public static RoomDto ToRoomDto(this Room room)
        {
            return new RoomDto
            {
                Id = room.Id,
                Price = room.Price,
                RoomCount = room.RoomCount,
                BathCount = room.BathCount,
                Images = room.Images.Select(
                    image => Convert.ToBase64String(image)
                ).ToList(),
                Size = room.Size,
                About = room.About,
                CreatedAt = room.CreatedAt,
                UpdatedAt = room.UpdatedAt,
                Owner = room.Owner.ToRoomOwnerDto(),
                SavedBy = room.SavedBy.Select(
                    user => user.ToRoomOwnerDto()
                ).ToList(),
                Address = room.Address.ToRoomAddressDto(),
            };
        }
    }
}