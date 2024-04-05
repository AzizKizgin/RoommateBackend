using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoommateBackend.Dtos.Room;
using RoommateBackend.Helpers;
using RoommateBackend.Mappers;
using RoommateBackend.Repositories.Interfaces;

namespace RoommateBackend.Controllers
{
    [ApiController]
    [Route("api/room")]
    public class RoomController: ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            try
            {
                var room = await _roomRepository.GetRoomById(id);
                if (room == null)
                {
                    return NotFound();
                }
                return Ok(room.ToRoomDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms([FromQuery] RoomQueryObject queryObject)
        {
            try
            {
                var rooms = await _roomRepository.GetRooms(queryObject);
                return Ok(rooms.Select(r => r.ToRoomDto()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDto room)
        {
            try
            {
                var newRoom = await _roomRepository.CreateRoom(room);
                if (newRoom == null)
                {
                    return BadRequest("Room could not be created.");
                }
                return Ok(newRoom.ToRoomDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                if (userId == null)
                {
                    return BadRequest("User not found.");
                }
                var deletedRoom = await _roomRepository.DeleteRoom(id, userId);
                if (deletedRoom == null)
                {
                    return BadRequest("Room could not be deleted.");
                }
                return Ok(deletedRoom.ToRoomDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] UpdateRoomDto room)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                if (userId == null)
                {
                    return BadRequest("User not found.");
                }
                var updatedRoom = await _roomRepository.UpdateRoom(id, userId, room);
                if (updatedRoom == null)
                {
                    return BadRequest("Room could not be updated.");
                }
                return Ok(updatedRoom.ToRoomDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{id}/favorite")]
        [Authorize]
        public async Task<IActionResult> FavoriteRoom(int id)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
                if (userId == null)
                {
                    return BadRequest("User not found.");
                }
                var favoritedRoom = await _roomRepository.FavoriteRoom(userId, id);
                if (favoritedRoom == null)
                {
                    return BadRequest("Room could not be favorited.");
                }
                return Ok(favoritedRoom.ToRoomDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}