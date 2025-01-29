namespace Application.IServices;

public interface IServiceManager
{
    IGenreService GenreService { get; }
    IGameService GameService { get; }
}