using ChatbotNinja.Core.Entities;
using ChatbotNinja.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.DataAccess.Repositories
{
    public class TemplatesRolesRepository : BaseRepository<TemplateRole, int>, ITemplateRolesRepository
    { 
        private readonly ApplicationDbContext _contexto;
        public TemplatesRolesRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }


        #region GET
        public List<TemplateRole> List()
        {
            var result = _contexto.TemplatesRoles.ToList();
            return result;
        }

        public TemplateRole? GetById(int idTemplateRole)
        {
            return _contexto.TemplatesRoles.SingleOrDefault(x => x.TemplateRoleId == idTemplateRole);
        }
        #endregion

        #region SET
        public void Delete(TemplateRole item)
        {
            var itembdd = _contexto.TemplatesRoles.SingleOrDefault(x => x.TemplateRoleId == item.TemplateRoleId);
            if (itembdd != null)
            {
                itembdd.Active = false;
                itembdd.DeletedAt = DateTime.Now;
                itembdd.DeletedByUserId = item.DeletedByUserId;
            }
            _contexto.Update(itembdd);
            _contexto.SaveChanges();
        }

        public List<TemplateRole> ListByCharacterId(Guid id)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
