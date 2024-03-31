using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoommateBackend.Dtos.RoomAddress;
using RoommateBackend.Models;

namespace RoommateBackend.Mappers
{
    public static class RoomAddressMapper
    {
        public static RoomAddress ToRoomAddress(this RoomAddressDto roomAddressDto)
        {
            return new RoomAddress
            {
                Street = roomAddressDto.Street,
                City = roomAddressDto.City,
                State = roomAddressDto.State,
                ZipCode = roomAddressDto.ZipCode,
                Latitude = roomAddressDto.Latitude,
                Longitude = roomAddressDto.Longitude
            };
        }
    }
}