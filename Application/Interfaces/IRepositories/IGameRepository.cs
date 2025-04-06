using Application.Dtos;
using Core.Entities;

namespace Application.Interfaces.IRepositories;

public interface IGameRepository
{
    Task AddGameAsync(Game game, RawgGame rawgGame);
    Task<Game?> GetByIdAsync(Guid gameId);
    Task AddGamesAsync(List<Game> games, List<RawgGame> rawgGames);
    Task<List<Game>> GetAllAsync();
}