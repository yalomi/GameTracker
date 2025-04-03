using System.Security.Authentication;
using Application.Dtos;
using Application.Interfaces;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Core.Entities;

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
        if (await _manager.UserRepository.GetByEmailAsync(userDto.Email) != null)
        {
            throw new Exception($"User with email {userDto.Email} already exists.");
        }

        var hashed = _passwordHasher.Generate(userDto.Password);
        var user = _mapper.Map<User>(userDto);
        user.PasswordHash = hashed;
        
        await _manager.UserRepository.AddAsync(user);
        await _manager.SaveAsync();
    }

    public async Task<string> Login(UserLoginDto userDto)
    {
        var user = await _manager.UserRepository.GetByEmailAsync(userDto.Email);
        
        if (user == null || _passwordHasher.Verify(userDto.Password, user.PasswordHash) == false)
        {
            throw new InvalidCredentialException();
        }
        
        var token = _jwtProvider.GenerateToken(user);

        return token;
    }
    
}