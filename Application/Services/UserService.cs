using Application.Dtos;
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

    public UserService(
        IRepositoryManager manager, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _manager = manager;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task Register(UserRegisterDto userDto)
    {
        var hashed = _passwordHasher.Generate(userDto.Password);
        var user = _mapper.Map<User>(userDto);
        user.PasswordHash = hashed;
        //should first check if user with this email does not exist
        await _manager.UserRepository.AddAsync(user);
        await _manager.SaveAsync();
    }

    public async Task<string> Login(UserLoginDto userDto)
    {
        var user = await _manager.UserRepository.GetByEmailAsync(userDto.Email);

        var verify = _passwordHasher.Verify(userDto.Password, user.PasswordHash);
        if (verify == false)
        {
            throw new Exception("Failed to login");
        }

        return "";
    }
}