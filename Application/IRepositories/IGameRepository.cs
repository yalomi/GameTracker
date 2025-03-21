using Application.Dtos;
using Core.Entities;

namespace Application.IRepositories;

public interface IGameRepository
{
    Task AddGameAsync(Game game, RawgGame rawgGame);
    Task AddGamesAsync(List<Game> games, List<RawgGame> rawgGames);
    Task<List<Game>> GetAllGamesAsync();
}