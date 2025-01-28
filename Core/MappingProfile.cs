﻿using AutoMapper;
using Core.Entities;

namespace Core;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RawgGenre, Genre>()
            .ForMember(dest => dest.Id, opt 
                => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(dest => dest.RawgId, opt
                => opt.MapFrom(src => src.RawgId))
            .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(src => src.Name));
    }
}