using Core.Entities;

namespace Application.Interfaces.IRepositories;

public interface ICollectionRepository
{
    Task<List<UserGame>> GetAll(Guid userId);
    Task AddGameToCollection(UserGame userGame);
}