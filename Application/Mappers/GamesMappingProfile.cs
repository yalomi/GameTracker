using Application.Dtos;
using Application.Dtos.PostDtos;
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
        
        CreateMap<AddGameToCollectionDto, UserGame>().ForMember(dest => dest.FinishedAt, opt 
                => opt.MapFrom(src => src.FinishedAt)) 
            .ForMember(dest => dest.Status, opt 
                => opt.MapFrom(src => GameStatus.Finished))
            .ForMember(dest => dest.AddedAt, opt 
                => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UserId, opt
                => opt.Ignore());
        
    }
}