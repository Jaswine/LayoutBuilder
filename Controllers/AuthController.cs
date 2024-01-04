using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LayoutBuilder.Dtos.User;
using LayoutBuilder.Utils;

namespace LayoutBuilder.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult<User>> SignUpUser(SignUpUserDto newUser) 
        {
            return Ok(await _userService.SignUpUser(newUser));
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult<User>> SignInUser(SignInUserDto someUser) 
        {
            return Ok( await _userService.SignInUser(someUser));;
        }

        [HttpGet("users/{username}")]
        public async Task<ActionResult<User>> GetUserByUsername(string username) 
        {
            return Ok(await _userService.GetUserByUsername(username));
        }

        [HttpGet("users/{username}/public")]
        public async Task<ActionResult<User>> GetUserPublicByUsername(string username) 
        {
            return Ok(await _userService.GetUserPublicProjects(username));
        }

        [HttpDelete("users/{username}")]
        public async Task<ActionResult<User>> DeleteUserByUsername(string username) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok(await _userService.DeleteUserByUsername(username, userId));
        }

        [HttpPut("users/{username}")]
        public async Task<ActionResult<User>> UpdateUserByUsername(string username, UpdateUserDto updateUser) 
        {
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = new JWTGenerator().DecodeJwtToken(token);

            return Ok(await _userService.UpdateUserByUsername(username, userId, updateUser));
        }
    }
}