﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotNinja.Contracts.Dtos
{
    public class PersonalityTrailDto
    {
        public int PersonalityTrailId { get; set; }


        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public bool Active { get; set; }
        public int PersonalityId { get; set; }
        public virtual PersonalityDto Personality { get; set; }

    }
}
