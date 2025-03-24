using Application.IRepositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(TrackerContext context) : base(context)
    {
    }

    public async Task AddAsync(User user) 
        => await CreateAsync(user);

    public async Task<User> GetByEmailAsync(string email) 
        => await GetByCondition(u => u.Email == email, false).SingleOrDefaultAsync() 
           ?? throw new Exception("User with email not found");
        

}