using Core.Entities;
using Infrastructure;

namespace Application;

public class GenreService
{
    private readonly GameContext _context;
    private readonly ExternalApiService.RawgService _rawgService;

    public GenreService(GameContext context, ExternalApiService.RawgService rawgService)
    {
        _context = context;
        _rawgService = rawgService;
    }

    public async Task CreateGenre(int id)
    {
        var genre = await _rawgService.FetchGenreAsync(id);
        
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();
    }
}