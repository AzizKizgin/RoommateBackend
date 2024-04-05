using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoommateBackend.Dtos.User;
using RoommateBackend.Mappers;
using RoommateBackend.Repositories.Interfaces;
using RoommateBackend.Services.Interfaces;

namespace RoommateBackend.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController: ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public UserController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            try{
                var user = await _userRepository.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user.ToUserDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto user)
        {
            try
            {
                var newUser = await _userRepository.CreateUser(user);
                if (newUser == null)
                {
                    return BadRequest("User could not be created.");
                }
                return Ok(newUser.ToUserDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDto user)
        {
            try
            {
                var loggedInUser = await _userRepository.LoginUser(user);
                if (loggedInUser == null)
                {
                    return BadRequest("User could not be logged in. Check your credentials.");
                }
                var userDto = loggedInUser.ToUserDto();
                userDto.Token = _tokenService.GenerateToken(loggedInUser);
                return Ok(userDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> LogoutUser()
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto user)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/rooms")]
        public async Task<IActionResult> GetUserRooms(string id)
        {
            try
            {
                var rooms = await _userRepository.GetRoomByUserId(id);
                return Ok(rooms.Select(r => r.ToRoomDto()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/saved-rooms")]
        [Authorize]
        public async Task<IActionResult> GetUserSavedRooms(string id)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
                if (userId != id)
                {
                    return Unauthorized("You are not authorized to view this user's saved rooms.");
                }
                var rooms = await _userRepository.GetUserSavedRooms(id);
                return Ok(rooms.Select(r => r.ToRoomDto()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}