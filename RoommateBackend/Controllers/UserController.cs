using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RoommateBackend.Dtos.User;
using RoommateBackend.Mappers;
using RoommateBackend.Models;
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
        private readonly UserManager<AppUser> _userManager;

        public UserController(IUserRepository userRepository, ITokenService tokenService, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _userManager = userManager;
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

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto user)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest("Invalid user data.");
                }
                
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
                if (ModelState.IsValid == false)
                {
                    return BadRequest("Invalid user data.");
                }
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
            var username = User.Identity?.Name;
            if (username == null)
            {
                return BadRequest("User not found.");
            }
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return BadRequest("User not found.");
            }
            try
            {
                await _userRepository.LogoutUser();
                return Ok(user.ToUserDto());
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
                var username = User.Identity?.Name;
                if (username == null)
                {
                    return BadRequest("User not found.");
                }
                var userId = (await _userManager.FindByNameAsync(username))?.Id;
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
                if (ModelState.IsValid == false)
                {
                    return BadRequest("Invalid user data.");
                }
                var username = User.Identity?.Name;
                if (username == null)
                {
                    return BadRequest("User not found.");
                }
                var userId = (await _userManager.FindByNameAsync(username))?.Id;
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
                if (rooms == null)
                {
                    return BadRequest("Rooms not found.");
                }
                return Ok(rooms.ToRoomDto());
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
                var username = User.Identity?.Name;
                if (username == null)
                {
                    return BadRequest("User not found.");
                }
                var userId = (await _userManager.FindByNameAsync(username))?.Id;
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

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest("Invalid password data.");
                }
                var username = User.Identity?.Name;
                if (username == null)
                {
                    return BadRequest("User not found.");
                }
                var userId = (await _userManager.FindByNameAsync(username))?.Id;
                if (userId == null)
                {
                    return BadRequest("User not found.");
                }
                var result = await _userRepository.ChangePassword(userId, changePasswordDto);
                if (result == null)
                {
                    return BadRequest("Password could not be changed.");
                }
                return Ok(result.ToUserDto());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}