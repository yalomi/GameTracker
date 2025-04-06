using Application.Interfaces.IServices;

namespace Application.Interfaces.IManagers;

public interface IServiceManager
{
    IGenreService GenreService { get; }
    IGameService GameService { get; }
    IUserService UserService { get; }
    ICollectionService CollectionService { get; }
}