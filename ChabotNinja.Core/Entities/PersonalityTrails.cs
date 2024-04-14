using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Core.Entities
{
    public class PersonalityTrail
    {
        [Key]
        public int PersonalityTrailId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }


        [ForeignKey("PersonalityId")]
        public int PersonalityId { get; set; }
        public virtual Personality Personality { get; set; }

    }
}
