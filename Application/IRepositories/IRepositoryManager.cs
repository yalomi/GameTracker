namespace Application.IRepositories;

public interface IRepositoryManager
{
    IGenreRepository GenreRepository { get; }
    IGameRepository GameRepository { get; }
    Task SaveAsync();
}