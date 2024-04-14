using ChatbotNinja.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Application.Services
{
    public interface IPersonalitiesTrailsService
    {
        Task<List<PersonalityTrailDto>> List();
        Task<PersonalityTrailDto> GetById(int id);
        Task<PersonalityTrailDto> GetByCharacterId(Guid id);

        
        Task<PersonalityTrailDto> Create(PersonalityTrailDto dto);
        Task Update(PersonalityTrailDto dto);
        Task Delete(int id);
    }
}
