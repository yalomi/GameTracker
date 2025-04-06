using Application.Dtos;
using Application.Dtos.PostDtos;

namespace Application.Interfaces.IServices;

public interface IUserService
{
    Task Register(UserRegisterDto user);
    Task<string> Login(UserLoginDto userDto);
    Task<List<UserDto>> GetAll();
}