using Application.IRepositories;

namespace Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IGenreRepository> _genreRepository;
    private readonly Lazy<IGameRepository> _gameRepository;
    private readonly GameContext _context;

    public RepositoryManager(GameContext context)
    {
        _genreRepository = new Lazy<IGenreRepository>(() => new GenresRepository(context));
        _gameRepository = new Lazy<IGameRepository>(() => new GamesRepository());
        _context = context;
    }
    public IGenreRepository GenreRepository => _genreRepository.Value;
    public IGameRepository GameRepository => _gameRepository.Value;
}