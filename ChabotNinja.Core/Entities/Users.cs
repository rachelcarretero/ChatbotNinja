using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Core.Entities
{
    public class Users
    {
        [Key]
        Guid UserId { get; set; }

        [StringLength(50)]
        public string Login { get; set; } = null!;

        [StringLength(100)]
        public string PasswordHash { get; set; } = null!;

        public string Name { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime? LastLogin { get; set; }


    }
}
