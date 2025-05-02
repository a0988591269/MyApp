using AutoMapper;
using MyApp.Application.DTOs;
using MyApp.Domain.Entities;

namespace MyApp.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create your mappings here
            // For example:
            // CreateMap<SourceClass, DestinationClass>();
            CreateMap<Player, PlayerDto>();
            CreateMap<Player, PlayerWithCharactersDto>();
            CreateMap<Character, CharacterDto>();

            CreateMap<PlayerForCreationDto, Player>();
            CreateMap<PlayerForUpdateDto, Player>();
        }
    }
}
