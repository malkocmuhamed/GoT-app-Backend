using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ReadyDev_backend.Domain.Interfaces;
using ReadyDev_backend.Domain.Services;
using ReadyDev_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ReadyDev_backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        got_databaseContext _context;



        public UserController(IUserService userService, got_databaseContext context)
        {
            this._userService = userService;
            this._context = context;
        }


        //GET api/<UserController>
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        //GET api/<UserController>/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            User userInDB = await _userService.GetUserById(id);
            if (userInDB == null)
            {
                return NotFound();
            }
            return Ok(await _userService.GetUserById(id));
        }


        //POST api/<UserController>
        [HttpPost]

        public async Task<IActionResult> CreateUser(User user)
        {
            await _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }
            if (user.Username == "muh" && user.Password == "1234")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44304",
                    audience: "http://localhost:44304",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new AuthenticatedResponse { Token = tokenString });
            }
            return Unauthorized();
        }

    }
}
