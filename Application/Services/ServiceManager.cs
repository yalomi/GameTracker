using Application.IExternalApiServices;
using Application.Interfaces;
using Application.Interfaces.IManagers;
using Application.Interfaces.IServices;
using Application.IRepositories;
using AutoMapper;

namespace Application.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IGenreService> _genreService;
    private readonly Lazy<IGameService> _gamesService;
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<ICollectionService> _collectionService;

    public ServiceManager(
        IRepositoryManager repositoryManager, IMapper mapper, IRawgService rawgService, 
        IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _genreService = new Lazy<IGenreService>(
            () => new GenreService(repositoryManager, mapper, rawgService));

        _gamesService = new Lazy<IGameService>(
            () => new GameService(repositoryManager, mapper, rawgService));

        _userService = new Lazy<IUserService>(
            () => new UserService(repositoryManager, mapper, passwordHasher, jwtProvider));

        _collectionService = new Lazy<ICollectionService>(
            () => new CollectionService(repositoryManager, mapper));
    }

    public IGenreService GenreService => _genreService.Value;
    public IGameService GameService => _gamesService.Value;
    public IUserService UserService => _userService.Value;
    public ICollectionService CollectionService => _collectionService.Value;
}