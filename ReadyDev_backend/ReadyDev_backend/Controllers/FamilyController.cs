using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ReadyDev_backend.Domain.Interfaces;
using ReadyDev_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ReadyDev_backend.Controllers
{
    [Route("api/family")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _familyService;
        private readonly IAppHelpers _appHelpers;


        public FamilyController(IFamilyService familyService, IAppHelpers appHelpers)
        {
            this._familyService = familyService;
            this._appHelpers = appHelpers;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFamilyById(int id)
        {
            Family familyInDB = await _familyService.GetFamilyById(id);
            if (familyInDB == null)
            {
                return NotFound();
            }
            return Ok(await _familyService.GetFamilyById(id));
        }

        [HttpPost]
        [Route("postFamily")]
        [Authorize]
        public IActionResult CreateFamily(Family family)
        {
            var userId = this._appHelpers.getUserIdClaim(HttpContext);
            family.UserId = userId;
            _familyService.CreateFamily(family);
            return CreatedAtAction(nameof(GetFamilyById), new { id = family.Id }, family);
        }

        [HttpGet]
        [Route("getAllFamilies")]
        [Authorize]

        public IActionResult GetAllFamilies()
        {
            return Ok(_familyService.GetAllFamilies());
        }

        [HttpGet]
        [Route("getFamiliesByUser")]
        [Authorize]
        public IActionResult GetFamiliesByUser()
        {
            return Ok(_familyService.GetFamiliesByUser(_appHelpers.getUserIdClaim(HttpContext)));
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditFamily(Family family)
        {
            Family familyInDB = await _familyService.GetFamilyById(family.Id);
            if (familyInDB == null)
            {
                return NotFound();
            }
            _familyService.EditFamily(familyInDB, family);
            return Ok();
        }

        [HttpDelete]
        [Route("removeFamily/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFamily(int id)
        {
            Family familyInDB = await _familyService.GetFamilyById(id);
            if (familyInDB == null)
            {
                return NotFound();
            }
            _familyService.DeleteFamily(familyInDB);
            return Ok();
        }
    }
}
