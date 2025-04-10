using System.Security.Authentication;
using Application.Dtos;
using Application.Dtos.PostDtos;
using Application.Interfaces;
using Application.Interfaces.IServices;
using Application.IRepositories;
using AutoMapper;
using Core.Entities;
using Core.Exceptions;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _manager;
    private readonly IJwtProvider _jwtProvider;

    public UserService(
        IRepositoryManager manager, IMapper mapper, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _manager = manager;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task Register(UserRegisterDto userDto)
    {
        if (await _manager.UsersRepository.GetByEmailAsync(userDto.Email) != null)
        {
            throw new Exception($"User with email {userDto.Email} already exists.");
        }

        var hashed = _passwordHasher.Generate(userDto.Password);
        var user = _mapper.Map<User>(userDto);
        user.PasswordHash = hashed;
        
        await _manager.UsersRepository.AddAsync(user);
        await _manager.SaveAsync();
    }

    public async Task<TokenResponseDto?> Login(UserLoginDto userDto)
    {
        var user = await _manager.UsersRepository.GetByEmailAsync(userDto.Email);
        if (user == null || _passwordHasher.Verify(userDto.Password, user.PasswordHash) == false)
        {
            throw new InvalidCredentialException();
        }

        return await GenerateTokenResponseAsync(user);
    }

    public async Task<TokenResponseDto> RefreshTokensAsync(RefreshTokenRequestDto request)
    {
        var user = await _manager.UsersRepository.GetByIdAsync(request.UserId);
        if (user is null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiry <= DateTime.UtcNow)
        {
            throw new Exception("User does not exist or refresh token is invalid.");
        }
        
        return await GenerateTokenResponseAsync(user);
    }

    private async Task<TokenResponseDto> GenerateTokenResponseAsync(User user)
    {
        _manager.UsersRepository.Attach(user);
        
        var accessToken = _jwtProvider.GenerateAccessToken(user);
        var refreshToken = _jwtProvider.GenerateRefreshToken();
        
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
        await _manager.SaveAsync();

        var response = new TokenResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken
        };

        return response;
    }
    public async Task<List<UserDto>> GetAll()
    {
        var users = await _manager.UsersRepository.GetAllAsync();
        
        var userDtos = _mapper.Map<List<UserDto>>(users);
        return userDtos;
    }
}