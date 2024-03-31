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
    }
}