using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Contracts.Dtos
{
    public class TemplateRoleDto
    {
        public int TemplateRoleId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public bool Active { get; set; }

    }
}
