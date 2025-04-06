using Application.Interfaces.IRepositories;

namespace Application.IRepositories;

public interface IRepositoryManager
{
    IGenreRepository GenreRepository { get; }
    IGameRepository GameRepository { get; }
    IUsersRepository UsersRepository { get; }
    ICollectionRepository CollectionRepository { get; }
    Task SaveAsync();
}