using Application.Interfaces.IRepositories;
using Core.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CollectionRepository : RepositoryBase<UserGame>, ICollectionRepository
{
    public CollectionRepository(GameTrackerContext context) : base(context)
    {
    }

    public async Task<List<UserGame>> GetAll(Guid userId)
        => await GetByCondition(ug => ug.UserId == userId, false)
            .Include(ug => ug.Game).ThenInclude(g => g.Genres).ToListAsync();

    public async Task AddGameToCollection(UserGame userGame)
        => await Context.UserGames.AddAsync(userGame);
    
}