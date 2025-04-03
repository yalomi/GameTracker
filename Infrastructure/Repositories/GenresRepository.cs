using Application.IRepositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenresRepository : RepositoryBase<Genre>, IGenreRepository
{
    public GenresRepository(GameTrackerContext context) : base(context)
    {
    }

    public Task<List<Genre>> GetAllGenres() =>
        GetAll().OrderBy(g => g.Name).ToListAsync();


    public Task<Genre?> GetGenreById(Guid id) =>
        GetByCondition(g => g.Id == id, false).FirstOrDefaultAsync();
    

    public async Task CreateGenre(Genre genre) => 
        await CreateAsync(genre);

    public async Task DeleteGenre(Guid id) =>
        DeleteAsync(await GetGenreById(id));
}