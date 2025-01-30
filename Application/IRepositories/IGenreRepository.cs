using Core.Entities;

namespace Application.IRepositories;

public interface IGenreRepository
{
    Task<List<Genre>> GetAllGenres();
    Task<Genre> GetGenreById(Guid id);
    Task CreateGenre(Genre genre);
}