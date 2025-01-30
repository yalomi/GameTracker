using Application.IRepositories;
using Application.IServices;
using Core.Entities;
using ExternalApiService;

namespace Application.Services;

public class GenreService : IGenreService
{
    private readonly IRepositoryManager _repositoryManager;
    public GenreService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public async Task<List<Genre>> GetAll()
    {
        var genres = await _repositoryManager.GenreRepository.GetAllGenres();
        //Mapping
        return genres;
    }

    public async Task<Genre> GetById(Guid id)
    {
        var genre = await _repositoryManager.GenreRepository.GetGenreById(id);
        //Mapping
        return genre;
    }
    // public async Task CreateGenre(int id)
    // {
    //     var genre = await _rawgService.FetchGenreAsync(id);
    //     
    //     _context.Genres.Add(genre);
    //     await _context.SaveChangesAsync();
    // }
}