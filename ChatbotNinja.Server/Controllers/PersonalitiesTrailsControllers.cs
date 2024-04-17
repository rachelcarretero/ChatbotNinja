﻿using ChatbotNinja.Application.Services;
using ChatbotNinja.Contracts.Dtos;
using ChatbotNinja.DataAccess;
using ChatbotNinja.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ChatbotNinja.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PersonalitiesTrailsController : ControllerBase
    {

        #region attributes + constructor
        private readonly ApplicationDbContext _context;
        private readonly IPersonalitiesTrailsService _personalityService;

        public PersonalitiesTrailsController(ApplicationDbContext context, IPersonalitiesTrailsService personalitysService)
        {
            _context = context;
            _personalityService = personalitysService;
        }
        #endregion


        #region gets

        // GET: api/personalities/listall
        [HttpGet("ListAll")]
        public async Task<ActionResult<IEnumerable<PersonalityTrailDto>>> ListAll()
        {
            return await _personalityService.List();
        }

        // GET: api/Personality/GetById/5sad-asdf-asdf-asdf
        [HttpGet("GetById")]
        public async Task<ActionResult<PersonalityTrailDto>> GetById(int id)
        {
            var personality = await _personalityService.GetById(id);

            if (personality == null)
            {
                return NotFound();
            }

            return personality;
        }


        #endregion

        #region sets 
        // POST: api/Personality/Insert
        [HttpPost("Insert")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Insert([FromBody] PersonalityTrailDto personality)
        {
            var created = await _personalityService.Create(personality);
            return Ok(created);
        }

        // PUT: api/Personality/Update
        [HttpPut("Update")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] PersonalityTrailDto personality)
        {
            await _personalityService.Update(personality);
            return Ok();
        }

        // DELETE: api/Personality/Delete/5
        [HttpDelete("Delete/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            await _personalityService.Delete(id);
            return Ok();
        }
        #endregion
    }
}
