using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ReadyDev_backend.Domain.Interfaces;
using ReadyDev_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyDev_backend.Controllers
{
    [Route("api/family")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyService _familyService;

        public FamilyController(IFamilyService familyService)
        {
            this._familyService = familyService;
        }

        //GET api/<FamiliyController>/3
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

        //POST api/<FamilyController>
        [HttpPost]

        public async Task<IActionResult> CreateFamily(Family family)
        {
            await _familyService.CreateFamily(family);
            return CreatedAtAction(nameof(GetFamilyById), new { id = family.Id }, family);
        }

        //GET api/<FamilyController>
        [HttpGet]
        public IActionResult GetAllFamilies()
        {
            return Ok(_familyService.GetAllFamilies());
        }

        // PUT api/<FamilyController>
        [HttpPut]
        public async Task<IActionResult> EditFamily(Family family)
        {
            Family familyInDB = await _familyService.GetFamilyById(family.Id);
            if (familyInDB == null)
            {
                return NotFound();
            }
            await _familyService.EditFamily(familyInDB, family);
            return Ok();
        }

        // DELETE api/<FamilyController>/3
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamily(int id)
        {
            Family familyInDB = await _familyService.GetFamilyById(id);
            if (familyInDB == null)
            {
                return NotFound();
            }
            await _familyService.DeleteFamily(familyInDB);
            return Ok();
        }
    }
}
