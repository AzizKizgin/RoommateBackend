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
                Town = roomAddressDto.Town,
                Country = roomAddressDto.Country,
                ApartmentNo = roomAddressDto.ApartmentNo,
                BuildingNo = roomAddressDto.BuildingNo,
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
                Town = roomAddress.Town,
                Country = roomAddress.Country,
                ZipCode = roomAddress.ZipCode,
                Latitude = roomAddress.Latitude,
                Longitude = roomAddress.Longitude,
                BuildingNo = roomAddress.BuildingNo,
                ApartmentNo = roomAddress.ApartmentNo
            };
        }

        public static RoomAddress UpdateRoomAddress(this RoomAddress roomAddress, RoomAddressDto roomAddressDto)
        {
            roomAddress.Street = roomAddressDto.Street;
            roomAddress.City = roomAddressDto.City;
            roomAddress.Town = roomAddressDto.Town;
            roomAddress.Country = roomAddressDto.Country;
            roomAddress.ZipCode = roomAddressDto.ZipCode;
            roomAddress.Latitude = roomAddressDto.Latitude;
            roomAddress.Longitude = roomAddressDto.Longitude;
            roomAddress.BuildingNo = roomAddressDto.BuildingNo;
            roomAddress.ApartmentNo = roomAddressDto.ApartmentNo;
            return roomAddress;
        }
    }
}