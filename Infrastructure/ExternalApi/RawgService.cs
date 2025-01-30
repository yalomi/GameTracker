using Application.IExternalApiServices;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ExternalApiService;

public class RawgService : IRawgService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public RawgService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["Rawg:ApiKey"];
    }

    public async Task<RawgGenre> FetchGenreAsync(int genreId)
    {
        var response = await _httpClient.GetAsync(
            $"https://api.rawg.io/api/genres/{genreId}?key={_apiKey}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Unable to find genre with id: {genreId}");
        }
        
        var content = await response.Content.ReadAsStringAsync();
        var rawgGenre = JsonConvert.DeserializeObject<RawgGenre>(content);
        
        return rawgGenre;
    }

    // public async Task<Game> FetchGameAsync(int gameId)
    // {
    //     var response = await _httpClient.GetAsync(
    //         $"https://api.rawg.io/api/games/{gameId}?key={_apiKey}");
    //
    //     if (!response.IsSuccessStatusCode)
    //     {
    //         throw new Exception($"Unable to find game with id: {gameId}");
    //     }
    //     
    //     var content = await response.Content.ReadAsStringAsync();
    //     var rawgGame = JsonConvert.DeserializeObject<RawgGame>(content);
    //
    //     var game = new Game
    //     {
    //         Id = Guid.NewGuid(),
    //         RawgId = rawgGame.Id,
    //         Name = rawgGame.Name,
    //         ReleaseDate = rawgGame.ReleaseDate,
    //         BackgroundImage = rawgGame.BackgroundImage,
    //         Metacritic = rawgGame.Metacritic,
    //         Genres = rawgGame.Genres,
    //     };
    //
    //     return game;    }
}