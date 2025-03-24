using Application.IRepositories;

namespace Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IGenreRepository> _genreRepository;
    private readonly Lazy<IGameRepository> _gameRepository;
    private readonly Lazy<IUserRepository> _usersRepository;
    private readonly TrackerContext _context;

    public RepositoryManager(TrackerContext context)
    {
        _genreRepository = new Lazy<IGenreRepository>(() => new GenresRepository(context));
        _gameRepository = new Lazy<IGameRepository>(() => new GamesRepository(context));
        _usersRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
        _context = context;
    }
    public IGenreRepository GenreRepository => _genreRepository.Value;
    public IGameRepository GameRepository => _gameRepository.Value;
    public IUserRepository UserRepository => _usersRepository.Value;
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}