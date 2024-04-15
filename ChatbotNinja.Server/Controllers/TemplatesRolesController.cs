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
    public class TemplatesRolesController : ControllerBase
    {

        #region attributes + constructor
        private readonly ApplicationDbContext _context;
        private readonly ITemplatesRolesService _templatesRolesService;

        public TemplatesRolesController(ApplicationDbContext context, ITemplatesRolesService templatesRolesService)
        {
            _context = context;
            _templatesRolesService = templatesRolesService;
        }
        #endregion


        #region gets

        // GET: api/personalities/listall
        [HttpGet("ListAll")]
        public async Task<ActionResult<IEnumerable<TemplateRoleDto>>> ListAll()
        {
            return await _templatesRolesService.List();
        }

        // GET: api/Personality/GetById/5sad-asdf-asdf-asdf
        [HttpGet("GetById")]
        public async Task<ActionResult<TemplateRoleDto>> GetById(int id)
        {
            var templateRole = await _templatesRolesService.GetById(id);

            if (templateRole == null)
            {
                return NotFound();
            }

            return templateRole;
        }


        #endregion

        #region sets 
        // POST: api/Personality/Insert
        [HttpPost("Insert")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Insert([FromBody] TemplateRoleDto templateRole)
        {
            var created = await _templatesRolesService.Create(templateRole);
            return Ok(created);
        }

        // PUT: api/Personality/Update
        [HttpPut("Update")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] TemplateRoleDto templateRole)
        {
            await _templatesRolesService.Update(templateRole);
            return Ok();
        }

        // DELETE: api/Personality/Delete/5
        [HttpDelete("Delete/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            await _templatesRolesService.Delete(id);
            return Ok();
        }
        #endregion
    }
}
