using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoommateBackend.Dtos.User;
using RoommateBackend.Mappers;
using RoommateBackend.Repositories.Interfaces;

namespace RoommateBackend.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController: ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto user)
        {
            var newUser = await _userRepository.CreateUser(user);
            if (newUser == null)
            {
                return BadRequest("User could not be created.");
            }
            return Ok(newUser.ToUserDto());
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDto user)
        {
            var loggedInUser = await _userRepository.LoginUser(user);
            if (loggedInUser == null)
            {
                return BadRequest("User could not be logged in. Check your credentials.");
            }
            return Ok(loggedInUser.ToUserDto());
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> LogoutUser()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (userId == null)
            {
                return BadRequest("User could not be logged out.");
            }
            var result = await _userRepository.LogoutUser(userId);
            if (result == false)
            {
                return BadRequest("User could not be logged out.");
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (userId != id)
            {
                return Unauthorized("You are not authorized to delete this user.");
            }
            var deletedUser = await _userRepository.DeleteUser(id);
            if (deletedUser == null)
            {
                return NotFound();
            }
            return Ok(deletedUser.ToUserDto());
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto user)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (userId != id)
            {
                return Unauthorized("You are not authorized to update this user.");
            }
            var updatedUser = await _userRepository.UpdateUser(id, user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser.ToUserDto());
        }

        [HttpGet("{id}/rooms")]
        public async Task<IActionResult> GetUserRooms(string id)
        {
            var rooms = await _userRepository.GetRoomByUserId(id);
            return Ok(rooms.Select(r => r.ToRoomDto()));
        }

        [HttpGet("{id}/saved-rooms")]
        [Authorize]
        public async Task<IActionResult> GetUserSavedRooms(string id)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (userId != id)
            {
                return Unauthorized("You are not authorized to view this user's saved rooms.");
            }
            var rooms = await _userRepository.GetUserSavedRooms(id);
            return Ok(rooms.Select(r => r.ToRoomDto()));
        }
    }
}