using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var deletedUser = await _userRepository.DeleteUser(id);
            if (deletedUser == null)
            {
                return NotFound();
            }
            return Ok(deletedUser.ToUserDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto user)
        {
            var updatedUser = await _userRepository.UpdateUser(id, user);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser.ToUserDto());
        }
    }
}