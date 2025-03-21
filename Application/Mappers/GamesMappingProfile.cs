using Application.Dtos;
using AutoMapper;
using Core.Entities;

namespace Application.Mappers;

public class GamesMappingProfile : Profile
{
    public GamesMappingProfile()
    {
        CreateMap<RawgGame, Game>().ForMember(dest => dest.Id, opt 
                => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.RawgId, opt
                => opt.MapFrom(src => src.RawgId))
            .ForMember(dest => dest.ReleaseDate, opt
                => opt.MapFrom(src => DateOnly.Parse(src.ReleaseDate)))
            .ForMember(dest => dest.Genres, opt
                => opt.MapFrom(src => new List<Game>()));

        CreateMap<Game, GameDto>().ForMember(dest => dest.GenresNames, opt 
            => opt.MapFrom(src => src.Genres.Select(g => g.Name)));
    }
}