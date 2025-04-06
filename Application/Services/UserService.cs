using System.Security.Authentication;
using Application.Dtos;
using Application.Dtos.PostDtos;
using Application.Interfaces;
using Application.Interfaces.IServices;
using Application.IRepositories;
using Application.IServices;
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

    public async Task<string> Login(UserLoginDto userDto)
    {
        var user = await _manager.UsersRepository.GetByEmailAsync(userDto.Email);
        
        if (user == null || _passwordHasher.Verify(userDto.Password, user.PasswordHash) == false)
        {
            throw new InvalidCredentialException();
        }
        
        var token = _jwtProvider.GenerateToken(user);

        return token;
    }

    public async Task<List<UserDto>> GetAll()
    {
        var users = await _manager.UsersRepository.GetAllAsync();
        
        var userDtos = _mapper.Map<List<UserDto>>(users);
        return userDtos;
    }

    public async Task AddGameToCollection(AddGameToCollectionDto gameDto, Guid userId)
    {
        var game =await _manager.GameRepository.GetByIdAsync(gameDto.GameId) 
                   ?? throw new GameNotFoundException(gameDto.GameId);

        var userGame = _mapper.Map<UserGame>(gameDto);
        userGame.UserId = userId;
        
        await _manager.UsersRepository.AddGameToCollection(userGame);
        await _manager.SaveAsync();
    }
}