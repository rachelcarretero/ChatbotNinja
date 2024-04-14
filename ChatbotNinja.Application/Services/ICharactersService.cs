using ChatbotNinja.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Application.Services
{
    public interface ICharactersService
    {
        Task<List<CharacterDto>> List();
        Task<List<CharacterDto>> List(int status);
        Task<CharacterDto> GetById(Guid charId);
        Task<CharacterDto> Create(CharacterDto dto);
        Task Update(CharacterDto dto);
        Task Delete(Guid id);
    }
}
