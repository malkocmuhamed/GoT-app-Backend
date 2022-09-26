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
using Microsoft.AspNetCore.Authorization;

namespace ReadyDev_backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAppHelpers _appHelpers;
        got_databaseContext _context;

        public UserController(IUserService userService, got_databaseContext context, IAppHelpers appHelpers)
        {
            this._userService = userService;
            this._appHelpers = appHelpers;
            this._context = context;
        }

        private User GetUser(User user)
        {
            return _userService.GetUser(user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

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
        [Route("register")]
        [AllowAnonymous]
        public IActionResult CreateUser(User user)
        {
             _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] User user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }
            var validUser = GetUser(user);

            if (validUser != null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("userId", validUser.Id.ToString()));
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44304",
                    audience: "http://localhost:44304",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(1440),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new AuthenticatedResponse { Token = tokenString });
            }
            return Unauthorized();
        }

    }
}
