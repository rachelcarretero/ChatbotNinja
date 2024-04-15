using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Core.Entities
{
    public class Personality
    {
        [Key]
        public int PersonalityId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }


        public virtual Character Character { get; set; }
        public virtual IEnumerable<Instruction> PersonalityInstructions { get; set; }

        public virtual IEnumerable<PersonalityTrail> PersonalityTrails { get; set; } = new List<PersonalityTrail>();





    }
}
