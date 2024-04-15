using ChatbotNinja.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Core.IRepositories
{
    public interface ITemplatesRolesRepository : IBaseRepository<TemplateRole, int>
    {

        List<TemplateRole> ListByCharacterId(Guid id);

    }
}
