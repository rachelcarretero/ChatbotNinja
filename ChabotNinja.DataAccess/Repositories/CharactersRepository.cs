using ChatbotNinja.Contracts.Enums;
using ChatbotNinja.Core.Entities;
using ChatbotNinja.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.DataAccess.Repositories
{
    public class CharactersRepository : BaseRepository<Character, Guid>, ICharactersRepository
    {
        private readonly ApplicationDbContext _contexto;
        public CharactersRepository(ApplicationDbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }


        #region GET

        public List<Character> List(int status)
        {
            var result = _contexto.Characters.Where(x => x.Status == status).ToList();
            return result;
        }

        public Character? GetById(Guid id)
        {
            return _contexto.Characters.SingleOrDefault(x => x.CharacterId == id);
        }
        #endregion

        #region SET
        public void Delete(Character item)
        {
            var itembdd = _contexto.Characters.SingleOrDefault(x => x.CharacterId == item.CharacterId);
            if (itembdd != null)
            {
                itembdd.Status = (int)Status.Deleted;
                itembdd.DeletedAt = DateTime.Now;
                itembdd.DeletedByUserId = item.DeletedByUserId;
            }
            _contexto.Update(itembdd);
            _contexto.SaveChanges();
        }
        #endregion


    }
}
