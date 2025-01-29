using Core.Entities;

namespace Application.IRepositories;

public interface IGenreRepository
{
    IEnumerable<Genre> GetAllGenres();
    Genre GetGenreById(Guid id);
    void CreateGenre(Genre genre);
}