using Core.Entities;

namespace Application.Interfaces.IRepositories;

public interface ICollectionRepository
{
    Task<List<UserGame>> GetAll(Guid userId);
    Task<UserGame?> GetByGameAndUserId(Guid gameId, Guid userId);
    Task AddGameToCollection(UserGame userGame);
}