using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatingApp.API.Data.Entities;
using DatingApp.API.DTOs;
using DatingApp.API.Data;
using System.Security.Cryptography;
using System.Text;
using DatingApp.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AuthController(DataContext dbContext, ITokenService tokenService)
        {
            this._context = dbContext;
            this._tokenService = tokenService;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthUserDto authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();
            if(_context.User.Any(u => u.Username == authUserDto.Username))
            {
                return BadRequest("Username is already existed!");
            }
            using var hmac = new HMACSHA512();
            var passwordByes = Encoding.UTF8.GetBytes(authUserDto.Password);
            var newUser = new Users {
                Username = authUserDto.Username,
                PasswordHash = hmac.ComputeHash(passwordByes),
                PasswordSalt = hmac.Key,
            };
            _context.User.Add(newUser);
            _context.SaveChanges();
            var token = _tokenService.CreateToken(newUser.Username);
            return Ok(token);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthUserDto authUserDto)
        {
            authUserDto.Username = authUserDto.Username.ToLower();

            var currentUser = _context.User.FirstOrDefault(u => u.Username == authUserDto.Username);
            if(currentUser == null)
            {
                return Unauthorized("Username is invalid");
            }
            using var hmac = new HMACSHA512(currentUser.PasswordSalt);
            var passwordByes = hmac.ComputeHash(Encoding.UTF8.GetBytes(authUserDto.Password));
            for(int i = 0; i < currentUser.PasswordHash.Length; i++)
            {
                if(currentUser.PasswordHash[i] != passwordByes[i])
                {
                    return Unauthorized("Password is invalid"); 
                }
            }
            
            var token = _tokenService.CreateToken(currentUser.Username);
            return Ok(token);

        }
        [Authorize]
        [HttpGet] 
        public IActionResult Get()
        {
            return Ok(_context.User.ToList());
        }
    }
}