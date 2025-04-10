using Application.Dtos;
using Core.Entities;

namespace Application.Interfaces.IRepositories;

public interface IUsersRepository
{
    void Attach(User user);
    Task<List<User>> GetAllAsync();
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(Guid id);
    Task AddAsync(User user);
}