using Application.IRepositories;
using Core.Entities;

namespace Infrastructure.Repositories;

public class GamesRepository : RepositoryBase<Game>, IGameRepository
{
    public GamesRepository(GameContext context) 
        : base(context)
    {
    }
    
    public async Task AddGameAsync(Game game, RawgGame rawgGame)
    {
        // var genres = Context.Genres.Where(genre =>
        //     genre.RawgId == rawgGame.Genres.Select(rawgGenre => rawgGenre.RawgId).First()).ToList();
        
        var genres = Context.Genres
            .Where(genre => rawgGame.Genres
                .Select(rawgGenre => rawgGenre.RawgId)
                .Contains(genre.RawgId))
            .ToList(); // Находим все жанры по RawgId
        
        game.Genres = genres;
        
        await CreateAsync(game);
    }
}