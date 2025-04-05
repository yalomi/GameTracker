using Application.Interfaces.IRepositories;
using Application.IRepositories;
using Core.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(GameTrackerContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email) 
        => await GetByCondition(u => u.Email == email, false).SingleOrDefaultAsync();

    public async Task AddAsync(User user) 
        => await CreateAsync(user);
}