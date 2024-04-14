using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Core.Entities
{
    public class Instruction
    {
        [Key]
        public int InstructionId { get; set; }


        public string Inputs { get; set; }
        public string Answers { get; set; }
        public string Triggers { get; set; }

        public DateTime CreatedAt { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }

        [ForeignKey("PersonalityId")]
        public int PersonalityId { get; set; }

        public virtual Personality Personality { get; set; }

        [ForeignKey("TemplateRoleId")]
        public int TemplateRoleId { get; set; }

        public virtual TemplateRole TemplateRole { get; set; }

    }
}
