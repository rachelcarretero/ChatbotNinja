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
    public class PersonalitiesService : BaseService, IPersonalitiesService
    {
        #region CONSTRUCTOR
        // guid dummy temp 
        public static Guid UserDummyId = new Guid("14653061-a874-4176-a526-131e3f657892");
        private readonly IPersonalitiesRepository _repositoryPersonalitys;

        public PersonalitiesService(IMapper mapper, IPersonalitiesRepository repositoryPersonalitys) : base(mapper)
        {
            _repositoryPersonalitys = repositoryPersonalitys;
        }
        #endregion

        public async Task<PersonalityDto> GetById(int id)
        {
            var result = _mapper.Map<Personality, PersonalityDto>(_repositoryPersonalitys.GetById(id));
            return result;
        }
 

        public async Task<List<PersonalityDto>> List()
        {
            var result = _mapper.Map<List<Personality>, List<PersonalityDto>>(_repositoryPersonalitys.List());
            return result;

        }
        public async Task<PersonalityDto> Create(PersonalityDto dto)
        {
            try
            {
                var item = _mapper.Map<PersonalityDto, Personality>(dto);


                // modificamos en negocio, aunque con sesión debiera venir informado en el dto.
                item.CreatedByUserId = UserDummyId;
                item.CreatedAt = DateTime.Now;


                var newchar = _repositoryPersonalitys.CreateReturn(item);
                return _mapper.Map<Personality, PersonalityDto>(newchar);

            }
            catch (Exception ex)
            {
                throw ex;
                // Crearíamos una capa de gestión de business exception condistintos niveles de error.
                // En ella realizaríamos login - logintrace , y enviaríamos un correo al administrador, así como una pantalla de error en la aplicación.
                // throw new BusinessException("errorAlModificar", MethodBase.GetCurrentMethod(), ex, dto);
            }
        }

        public async Task Update(PersonalityDto dto)
        {
            try
            {
                var item = _mapper.Map<PersonalityDto, Personality>(dto);

                // modificamos en negocio, aunque con sesión debiera venir informado en el dto.
                item.ModifiedByUserId = UserDummyId;
                item.ModifiedAt = DateTime.Now;

                _repositoryPersonalitys.Update(item);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var item =  _repositoryPersonalitys.GetById(id);

                item.Active = false;
                item.DeletedByUserId = UserDummyId;
                item.DeletedAt = DateTime.Now;
                _repositoryPersonalitys.Delete(item);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }


}
