using Application.Dtos;
using Application.Dtos.PostDtos;

namespace Application.Interfaces.IServices;

public interface IUserService
{
    Task Register(UserRegisterDto user);
    Task<TokenResponseDto?> Login(UserLoginDto userDto);
    Task<TokenResponseDto> RefreshTokensAsync(RefreshTokenRequestDto request);
    Task<List<UserDto>> GetAll();
}