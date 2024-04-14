using AutoMapper;
using ChatbotNinja.Contracts.Dtos;
using ChatbotNinja.Contracts.Enums;
using ChatbotNinja.DataAccess;
using ChatbotNinja.Core;
using ChatbotNinja.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ChatbotNinja.Core.Entities;

namespace ChatbotNinja.Application.Services
{
    public class CharactersService : BaseService, ICharactersService
    {
        #region CONSTRUCTOR
        // guid dummy temp 
        public static Guid UserDummyId = new Guid("14653061-a874-4176-a526-131e3f657892");
        private readonly ICharactersRepository _repositoryCharacters;

        public CharactersService(IMapper mapper, ICharactersRepository repositoryCharacters) : base(mapper)
        {
            _repositoryCharacters = repositoryCharacters;
        }
        #endregion

        public async Task<CharacterDto> GetById(Guid id)
        {
            var result = _mapper.Map<Character, CharacterDto>(_repositoryCharacters.GetById(id));
            return result;
        }

        public async Task<List<CharacterDto>> List(int status)
        {
            var result = _mapper.Map<List<Character>, List<CharacterDto>>(_repositoryCharacters.List(status));
            return result;
        }
        public async Task<List<CharacterDto>> List()
        {
            var result = _mapper.Map<List<Character>, List<CharacterDto>>(_repositoryCharacters.List());
            return result;

        }
        public async Task<CharacterDto> Create(CharacterDto dto)
        {
            try
            {
                var item = _mapper.Map<CharacterDto, Character>(dto);


                // modificamos en negocio, aunque con sesión debiera venir informado en el dto.
                item.Status = (int)Status.Active;
                item.CreatedByUserId = UserDummyId;
                item.CreatedAt = DateTime.Now;


                var newchar = _repositoryCharacters.CreateReturn(item);
                return _mapper.Map<Character, CharacterDto>(newchar);

            }
            catch (Exception ex)
            {
                throw ex;
                // Crearíamos una capa de gestión de business exception condistintos niveles de error.
                // En ella realizaríamos login - logintrace , y enviaríamos un correo al administrador, así como una pantalla de error en la aplicación.
                // throw new BusinessException("errorAlModificar", MethodBase.GetCurrentMethod(), ex, dto);
            }
        }

        public async Task Update(CharacterDto dto)
        {
            try
            {
                var item = _mapper.Map<CharacterDto, Character>(dto);

                // modificamos en negocio, aunque con sesión debiera venir informado en el dto.
                item.ModifiedByUserId = UserDummyId;
                item.ModifiedAt = DateTime.Now;

                _repositoryCharacters.Update(item);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var item =  _repositoryCharacters.GetById(id);

                item.DeletedByUserId = UserDummyId;
                item.DeletedAt = DateTime.Now;
                _repositoryCharacters.Delete(item);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }


}
