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
                Description = createRoomDto.Description,
                CreatedAt = createRoomDto.CreatedAt,
                Address = createRoomDto.Address.ToRoomAddress(),
                Images = createRoomDto
                    .Images
                    .Select(
                        image => new RoomImage 
                        { Data = Convert.FromBase64String(createRoomDto.Images[0])}
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
                Description = updateRoomDto.Description,
                UpdatedAt = updateRoomDto.UpdatedAt,
                Address = updateRoomDto.Address.ToRoomAddress(),
                Images = updateRoomDto
                    .Images
                    .Select(
                        image => new RoomImage 
                        { Data = Convert.FromBase64String(updateRoomDto.Images[0])}
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
                Images = room.Images.Select(image => Convert.ToBase64String(image.Data)).ToList(),
                Size = room.Size,
                Description = room.Description,
                CreatedAt = room.CreatedAt,
                UpdatedAt = room.UpdatedAt,
                Owner = room.Owner.ToRoomOwnerDto(),
                SavedByCount = room.SavedBy.Count,
                Address = room.Address.ToRoomAddressDto(),
            };
        }
    }
}