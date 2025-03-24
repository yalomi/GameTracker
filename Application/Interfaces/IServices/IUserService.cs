using Application.Dtos;

namespace Application.IServices;

public interface IUserService
{
    Task Register(UserRegisterDto user);
    Task<string> Login(UserLoginDto userDto);
}