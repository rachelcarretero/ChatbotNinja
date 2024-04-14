using ChatbotNinja.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Application.Services
{
    public interface IPersonalitiesService
    {
        Task<List<PersonalityDto>> List();
        Task<PersonalityDto> GetById(int id);
        Task<PersonalityDto> Create(PersonalityDto dto);
        Task Update(PersonalityDto dto);
        Task Delete(int id);
    }
}
