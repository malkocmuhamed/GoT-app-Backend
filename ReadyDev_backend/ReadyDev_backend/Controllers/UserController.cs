using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ReadyDev_backend.Domain.Interfaces;
using ReadyDev_backend.Domain.Services;
using ReadyDev_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyDev_backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
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
    }
}
