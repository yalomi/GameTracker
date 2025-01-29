using Application.IRepositories;
using Core.Entities;

namespace Infrastructure.Repositories;

public class GenresRepository : RepositoryBase<Genre>, IGenreRepository
{
    public GenresRepository(GameContext context) : base(context)
    {
    }

    public IEnumerable<Genre> GetAllGenres()
    {
        return GetAll().OrderBy(g => g.Name).ToList();
    }

    public Genre GetGenreById(Guid id)
    {
        return GetByCondition(g => g.Id == id).FirstOrDefault();
    }

    public void CreateGenre(Genre genre)
    {
        Create(genre);
    }
}