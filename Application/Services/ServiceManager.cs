using Application.IRepositories;
using Application.IServices;

namespace Application.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IGenreService> _genreService;
    private readonly Lazy<IGameService> _gamesService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _genreService = new Lazy<IGenreService>(() => new GenreService(repositoryManager));
        _gamesService = new Lazy<IGameService>(() => new GameService());
    }

    public IGenreService GenreService => _genreService.Value;
    public IGameService GameService => _gamesService.Value;
}