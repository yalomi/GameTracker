using Application.Dtos;

namespace Application.IServices;

public interface IAuthenticationService
{
    Task<RegisterUserDto> Register(RegisterUserDto user);
}