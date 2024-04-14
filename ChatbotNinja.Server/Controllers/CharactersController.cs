using ChatbotNinja.Application.Services;
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
    public class CharactersController : ControllerBase
    {

        #region attributes + constructor
        private readonly ApplicationDbContext _context;
        private readonly ICharactersService _characterService;

        public CharactersController(ApplicationDbContext context, ICharactersService charactersService)
        {
            _context = context;
            _characterService = charactersService;
        }
        #endregion


        #region gets

        // GET: api/Character/ListAll
        [HttpGet("ListAll")]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> ListAll()
        {
            return await _characterService.List();
        }

        // GET: api/Character/GetById/5sad-asdf-asdf-asdf
        [HttpGet("GetById")]
        public async Task<ActionResult<CharacterDto>> GetById(Guid id)
        {
            var character = await _characterService.GetById(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }


        #endregion

        #region sets 
        // POST: api/Character/Insert
        [HttpPost("Insert")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Insert([FromBody] CharacterDto character)
        {
            var created = await _characterService.Create(character);
            return Ok(created);
        }

        // PUT: api/Character/Update
        [HttpPut("Update")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] CharacterDto character)
        {
            await _characterService.Update(character);
            return Ok();
        }

        // DELETE: api/Character/Delete/5
        [HttpDelete("Delete/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _characterService.Delete(id);
            return Ok();
        }
        #endregion
    }
}
