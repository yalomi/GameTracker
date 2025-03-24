using Core.Entities;

namespace Application.IRepositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User> GetByEmailAsync(string email);
}