using ChatbotNinja.Core.Entities;
using ChatbotNinja.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.DataAccess.Repositories
{
    public class PersonalitiesTrailsRepository : BaseRepository<PersonalityTrail, int>, IPersonalitiesTrailsRepository
    { 
        private readonly ApplicationDbContext _contexto;
        public PersonalitiesTrailsRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }


        #region GET
        public List<PersonalityTrail> List()
        {
            var result = _contexto.PersonalitiesTrails.ToList();
            return result;
        }

        public PersonalityTrail? GetById(int idPersonality)
        {
            return _contexto.PersonalitiesTrails.SingleOrDefault(x => x.PersonalityId == idPersonality);
        }

        public PersonalityTrail GetByCharacterId(Guid id)
        {
            throw new NotImplementedException();
         }
            #endregion

            #region SET
        public void Delete(PersonalityTrail item)
        {
            var itembdd = _contexto.PersonalitiesTrails.SingleOrDefault(x => x.PersonalityId == item.PersonalityId);
            if (itembdd != null)
            {
                itembdd.Active = false;
                itembdd.DeletedAt = DateTime.Now;
                itembdd.DeletedByUserId = item.DeletedByUserId;
            }
            _contexto.Update(itembdd);
            _contexto.SaveChanges();
        }

 
        #endregion


    }
}
