using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Contracts.Dtos
{
    public class InstructionDto
    {

        public int InstructionId { get; set; }


        public string Inputs { get; set; }
        public string Answers { get; set; }
        public string Triggers { get; set; }

        public int PersonalityId { get; set; }

        public  PersonalityDto Personality { get; set; }

        public int TemplateRoleId { get; set; }

        public virtual TemplateRoleDto TemplateRole { get; set; }
    }
}
