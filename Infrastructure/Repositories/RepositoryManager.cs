using Application.Interfaces.IRepositories;
using Application.IRepositories;
using Infrastructure.Database;

namespace Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IGenreRepository> _genreRepository;
    private readonly Lazy<IGameRepository> _gameRepository;
    private readonly Lazy<IUsersRepository> _usersRepository;
    private readonly Lazy<ICollectionRepository> _collectionRepository;
    private readonly GameTrackerContext _context;

    public RepositoryManager(GameTrackerContext context)
    {
        _genreRepository = new Lazy<IGenreRepository>(() => new GenresRepository(context));
        _gameRepository = new Lazy<IGameRepository>(() => new GamesRepository(context));
        _usersRepository = new Lazy<IUsersRepository>(() => new UsersRepository(context));
        _collectionRepository = new Lazy<ICollectionRepository>(() => new CollectionRepository(context));
        _context = context;
    }
    public IGenreRepository GenreRepository => _genreRepository.Value;
    public IGameRepository GameRepository => _gameRepository.Value;
    public IUsersRepository UsersRepository => _usersRepository.Value;
    public ICollectionRepository CollectionRepository => _collectionRepository.Value;
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}