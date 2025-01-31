using Core.Entities;

namespace Application.IExternalApiServices;

public interface IRawgService
{
    Task<RawgGenre> FetchGenreAsync(int genreId);
    Task<List<RawgGenre>> FetchGenresAsync();
    Task<RawgGame> FetchGameAsync(int gameId);
}