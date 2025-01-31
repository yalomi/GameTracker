using Application.IExternalApiServices;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;

namespace Application.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IGenreService> _genreService;
    private readonly Lazy<IGameService> _gamesService;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IRawgService rawgService)
    {
        _genreService = new Lazy<IGenreService>(
            () => new GenreService(repositoryManager, mapper, rawgService));
        
        _gamesService = new Lazy<IGameService>(
            () => new GameService(repositoryManager, rawgService, mapper));
    }

    public IGenreService GenreService => _genreService.Value;
    public IGameService GameService => _gamesService.Value;
}