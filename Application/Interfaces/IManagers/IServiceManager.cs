using Application.Interfaces.IServices;

namespace Application.IServices;

public interface IServiceManager
{
    IGenreService GenreService { get; }
    IGameService GameService { get; }
    IUserService UserService { get; }
}