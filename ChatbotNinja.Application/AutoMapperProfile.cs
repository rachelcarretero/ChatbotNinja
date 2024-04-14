﻿using AutoMapper;
using ChatbotNinja.Contracts.Dtos;
using ChatbotNinja.Core.Entities;
 

namespace ChatbotNinja.Application
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterDto, Character>();

            CreateMap<Personality, PersonalityDto>();
            CreateMap<PersonalityDto, Personality>();

            CreateMap<PersonalityTrail, PersonalityTrailDto>();
            CreateMap<PersonalityTrailDto, PersonalityTrail>();

            CreateMap<TemplateRole, TemplateRoleDto>();
            CreateMap<PersonalityTrailDto, TemplateRole>();

            CreateMap<PersonalityTrail, PersonalityTrailDto>();
            CreateMap<PersonalityTrailDto, PersonalityTrail>();
        }
    }
 
}
