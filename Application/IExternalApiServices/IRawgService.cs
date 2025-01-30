using Core.Entities;

namespace Application.IExternalApiServices;

public interface IRawgService
{
    Task<RawgGenre> FetchGenreAsync(int genreId);
}