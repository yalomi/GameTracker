using Application.Dtos;
using Application.Dtos.GetDtos;
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
        
        CreateMap<PostGameDto, UserGame>().ForMember(dest => dest.FinishedAt, opt 
                => opt.MapFrom(src => src.FinishedAt)) 
            .ForMember(dest => dest.Status, opt 
                => opt.MapFrom(src => GameStatus.Finished))
            .ForMember(dest => dest.AddedAt, opt 
                => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UserId, opt
                => opt.Ignore());
        
        CreateMap<UserGame, GetGameDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Game.Id))
            .ForMember(dest => dest.Rawgid, opt => opt.MapFrom(src => src.Game.RawgId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Game.Name))
            .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.Game.ReleaseDate))
            .ForMember(dest => dest.BackgroundImage, opt => opt.MapFrom(src => src.Game.BackgroundImage))
            .ForMember(dest => dest.Metacritic, opt => opt.MapFrom(src => src.Game.Metacritic))
            .ForMember(dest => dest.GenresNames, opt => opt.MapFrom(src => src.Game.Genres.Select(g => g.Name)))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Review, opt => opt.MapFrom(src => src.Review))
            .ForMember(dest => dest.FinishedAt, opt => opt.MapFrom(src => src.FinishedAt));
        
    }
}