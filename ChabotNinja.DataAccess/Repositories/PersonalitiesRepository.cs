using ChatbotNinja.Core.Entities;
using ChatbotNinja.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.DataAccess.Repositories
{
    public class PersonalitiesRepository : BaseRepository<Personality, int>, IPersonalitiesRepository
    { 
        private readonly ApplicationDbContext _contexto;
        public PersonalitiesRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }


        #region GET
        public List<Personality> List()
        {
            var result = _contexto.Personalities.ToList();
            return result;
        }

        public Personality? GetById(int idPersonality)
        {
            return _contexto.Personalities.SingleOrDefault(x => x.PersonalityId == idPersonality);
        }
        #endregion

        #region SET
        public void Delete(Personality item)
        {
            var itembdd = _contexto.Personalities.SingleOrDefault(x => x.PersonalityId == item.PersonalityId);
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
