using Core.Entities;

namespace Application.Interfaces.IRepositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
}