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
using ChatbotNinja.DataAccess.Repositories;

namespace ChatbotNinja.Application.Services
{
    public class TemplatesRolesService : BaseService, ITemplatesRolesService
    {
        #region CONSTRUCTOR
        // guid dummy temp 
        public static Guid UserDummyId = new Guid("14653061-a874-4176-a526-131e3f657892");
        private readonly ITemplateRolesRepository _repositoryTemplatesRoles;

        public TemplatesRolesService(IMapper mapper, ITemplateRolesRepository repositoryTemplatesRoles) : base(mapper)
        {
            _repositoryTemplatesRoles = repositoryTemplatesRoles;
        }
        #endregion

        public async Task<TemplateRoleDto> GetById(int id)
        {
            var result = _mapper.Map<TemplateRole, TemplateRoleDto>(_repositoryTemplatesRoles.GetById(id));
            return result;
        }

 
        public async Task<List<TemplateRoleDto>> List()
        {
            var result = _mapper.Map<List<TemplateRole>, List<TemplateRoleDto>>(_repositoryTemplatesRoles.List());
            return result;

        }
        public Task<List<TemplateRoleDto>> ListByCharacterId(Guid id)
        {
            //var result = _mapper.Map<List<TemplateRole>, List<TemplateRoleDto>>(_repositoryTemplatesRoles.ListByCharacterId(id).ToList());
            //return result;
            throw new NotImplementedException();

        }

        public async Task<TemplateRoleDto> Create(TemplateRoleDto dto)
        {
            try
            {
                var item = _mapper.Map<TemplateRoleDto, TemplateRole>(dto);


                // modificamos en negocio, aunque con sesión debiera venir informado en el dto.
                item.CreatedByUserId = UserDummyId;
                item.CreatedAt = DateTime.Now;


                var newchar = _repositoryTemplatesRoles.CreateReturn(item);
                return _mapper.Map<TemplateRole, TemplateRoleDto>(newchar);

            }
            catch (Exception ex)
            {
                throw ex;
                // Crearíamos una capa de gestión de business exception condistintos niveles de error.
                // En ella realizaríamos login - logintrace , y enviaríamos un correo al administrador, así como una pantalla de error en la aplicación.
                // throw new BusinessException("errorAlModificar", MethodBase.GetCurrentMethod(), ex, dto);
            }
        }

        public async Task Update(TemplateRoleDto dto)
        {
            try
            {
                var item = _mapper.Map<TemplateRoleDto, TemplateRole>(dto);

                // modificamos en negocio, aunque con sesión debiera venir informado en el dto.
                item.ModifiedByUserId = UserDummyId;
                item.ModifiedAt = DateTime.Now;

                _repositoryTemplatesRoles.Update(item);

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
                var item =  _repositoryTemplatesRoles.GetById(id);

                item.Active = false;
                item.DeletedByUserId = UserDummyId;
                item.DeletedAt = DateTime.Now;
                _repositoryTemplatesRoles.Delete(item);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public Task<TemplateRoleDto> Create(PersonalityDto dto)
        {
            throw new NotImplementedException();
        }
    }


}
