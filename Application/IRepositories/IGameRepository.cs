using Core.Entities;

namespace Application.IRepositories;

public interface IGameRepository
{
    Task AddGameAsync(Game game, RawgGame rawgGame);
}