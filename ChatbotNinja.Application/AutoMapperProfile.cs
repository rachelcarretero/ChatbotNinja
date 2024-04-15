using AutoMapper;
using ChatbotNinja.Contracts.Dtos;
using ChatbotNinja.Core.Entities;
 

namespace ChatbotNinja.Application
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
     
            CreateMap<CharacterDto, Character>().ReverseMap();
            CreateMap<IQueryable<CharacterDto>, IQueryable<Character>>().ReverseMap();

            CreateMap<PersonalityDto, Personality>().ReverseMap();
            CreateMap<IQueryable<PersonalityDto>, IQueryable<Personality>>().ReverseMap();

            CreateMap<PersonalityTrailDto, PersonalityTrail>().ReverseMap();
            CreateMap<IQueryable<PersonalityTrailDto>, IQueryable<PersonalityTrail>>().ReverseMap();

            CreateMap<TemplateRoleDto, TemplateRole>().ReverseMap();
            CreateMap<IQueryable<TemplateRoleDto>, IQueryable<TemplateRole>>().ReverseMap();

            CreateMap<InstructionDto, Instruction>().ReverseMap();
            CreateMap<IQueryable<InstructionDto>, IQueryable<Instruction>>().ReverseMap();
        }
    }
 
}
