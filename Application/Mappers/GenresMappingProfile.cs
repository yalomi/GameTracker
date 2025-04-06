using Application.Dtos;
using Application.Dtos.GetDtos;
using AutoMapper;
using Core.Entities;

namespace Application.Mappers;

public class GenresMappingProfile : Profile
{
    public GenresMappingProfile()
    {
        CreateMap<RawgGenre, Genre>()
            .ForMember(dest => dest.Id, opt 
                => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.RawgId, opt
                => opt.MapFrom(src => src.RawgId))
            .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(src => src.Name));

        CreateMap<Genre, GetGenreDto>();
    }
}