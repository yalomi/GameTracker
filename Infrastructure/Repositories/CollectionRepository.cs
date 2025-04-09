using Application.Dtos.PutDtos;
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
            .Include(ug => ug.Game)
            .ThenInclude(g => g.Genres)
            .ToListAsync();

    public async Task<UserGame?> GetByGameAndUserId(Guid gameId, Guid userId)
        => await GetByCondition(ug => ug.GameId == gameId && ug.UserId == userId, false)
            .Include(ug => ug.Game)
            .ThenInclude(g => g.Genres)
            .FirstOrDefaultAsync();
    
    public async Task AddUserGame(UserGame userGame)
        => await CreateAsync(userGame);

    public async Task UpdateUserGame(UserGame userGame, PutGameDto gameDto)
        => await Context.UserGames
            .Where(ug => ug.GameId == userGame.GameId && ug.UserId == userGame.UserId)
            .ExecuteUpdateAsync(x
                => x.SetProperty(ug => ug.Rating, gameDto.Rating)
                    .SetProperty(ug => ug.Review, gameDto.Review)
                    .SetProperty(ug => ug.FinishedAt, gameDto.FinishedAt));
    
    public async Task DeleteUserGame(Guid gameId, Guid userId) => await Context.UserGames
        .Where(ug => ug.GameId == gameId && ug.UserId == userId)
        .ExecuteDeleteAsync();
}