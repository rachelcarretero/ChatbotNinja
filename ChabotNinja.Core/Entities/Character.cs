using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
namespace ChatbotNinja.Core.Entities
{
    [Index("Status", Name = "Status")]
    [Index("Name", Name = "Name", IsUnique = true)]
    [Index("CharacterId", Name = "CharacterId")]
    public class Character
    {


        [Key]
        public Guid CharacterId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public int TemplateRoleId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedByUserId { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Guid? ModifiedByUserId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }


        [ForeignKey("PersonalityId")]
        public virtual Personality BasePersonality { get; set; }

        public virtual ICollection<TemplateRole> TemplatesRoles { get; set; }


    }
}
