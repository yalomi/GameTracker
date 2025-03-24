namespace Application.IRepositories;

public interface IRepositoryManager
{
    IGenreRepository GenreRepository { get; }
    IGameRepository GameRepository { get; }
    IUserRepository UserRepository { get; }
    Task SaveAsync();
}