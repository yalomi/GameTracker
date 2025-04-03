using Application.Dtos;
using Application.Interfaces.IRepositories;
using Application.IRepositories;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GamesRepository : RepositoryBase<Game>, IGameRepository
{
    public GamesRepository(GameTrackerContext context) 
        : base(context)
    {
    }

    public async Task<List<Game>> GetAllAsync()
    {
        var games = await GetAll().OrderByDescending(g => g.Metacritic)
            .Include(g => g.Genres).ToListAsync();
        
        return games; 
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

    public async Task AddGamesAsync(List<Game> games, List<RawgGame> rawgGames)
    {
        for (var i = 0; i < games.Count; i++)
        {
            var genres = await Context.Genres
                .Where(genre => rawgGames[i].Genres
                    .Select(rawgGenre => rawgGenre.RawgId)
                    .Contains(genre.RawgId))
                .ToListAsync();
            
            games[i].Genres = genres;
            await CreateAsync(games[i]);
        }
    }
}