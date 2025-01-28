using ExternalApiService;
using Core.Entities;
using Infrastructure.Contracts;

namespace Infrastructure;

public class GamesRepository 
{
    private readonly GameContext _context;
    private readonly RawgService _rawgService;
    
    public GamesRepository(GameContext context, RawgService rawgService)
    {
        _context = context;
        _rawgService = rawgService;
    }
    public List<Game> GetAll()
    {
        return _context.Games.ToList();
    }

    public async Task FetchGameToDb(int id)
    {
        var game = await _rawgService.FetchGameAsync(id);
        
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
    }
}