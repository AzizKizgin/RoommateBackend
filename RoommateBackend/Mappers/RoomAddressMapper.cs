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

        public static RoomAddressDto ToRoomAddressDto(this RoomAddress roomAddress)
        {
            return new RoomAddressDto
            {
                Street = roomAddress.Street,
                City = roomAddress.City,
                State = roomAddress.State,
                ZipCode = roomAddress.ZipCode,
                Latitude = roomAddress.Latitude,
                Longitude = roomAddress.Longitude
            };
        }

        public static RoomAddress UpdateRoomAddress(this RoomAddress roomAddress, RoomAddressDto roomAddressDto)
        {
            roomAddress.Street = roomAddressDto.Street;
            roomAddress.City = roomAddressDto.City;
            roomAddress.State = roomAddressDto.State;
            roomAddress.ZipCode = roomAddressDto.ZipCode;
            roomAddress.Latitude = roomAddressDto.Latitude;
            roomAddress.Longitude = roomAddressDto.Longitude;
            return roomAddress;
        }
    }
}