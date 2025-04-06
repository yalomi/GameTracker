﻿using Application.Interfaces.IRepositories;
using Application.IRepositories;
using Core.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UsersRepository : RepositoryBase<User>, IUsersRepository
{
    public UsersRepository(GameTrackerContext context) : base(context)
    {
    }
    
    public async Task<List<User>> GetAllAsync() 
        => await GetAll().ToListAsync();

    public async Task<User?> GetByEmailAsync(string email) 
        => await GetByCondition(u => u.Email == email, false).SingleOrDefaultAsync();

    public async Task AddAsync(User user) 
        => await CreateAsync(user);
}