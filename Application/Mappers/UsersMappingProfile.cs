using Application.Dtos;
using AutoMapper;
using Core.Entities;

namespace Application.Mappers;

public class UsersMappingProfile : Profile
{
    public UsersMappingProfile()
    {
        CreateMap<UserRegisterDto, User>().ForMember(dest => dest.Id, opt 
            => opt.MapFrom(source => Guid.NewGuid()));
        
        CreateMap<User, UserDto>();
        
    }
}