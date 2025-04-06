using Application.Dtos;
using Core.Entities;

namespace Application.Interfaces.IRepositories;

public interface IUsersRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
}