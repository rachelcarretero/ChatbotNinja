using ChatbotNinja.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Application.Services
{
    public interface ITemplatesRolesService
    {
        Task<List<TemplateRoleDto>> List();
        Task<List<TemplateRoleDto>> ListByCharacterId(Guid id);

        Task<TemplateRoleDto> GetById(int id);
        Task<TemplateRoleDto> Create(TemplateRoleDto dto);
        Task Update(TemplateRoleDto dto);
        Task Delete(int id);
    }
}
