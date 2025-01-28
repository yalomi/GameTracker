using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ExternalApiService;

public class RawgService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly IMapper _mapper;

    public RawgService(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
    {
        _httpClient = httpClient;
        _apiKey = configuration["Rawg:ApiKey"];
        _mapper = mapper;
    }

    public async Task<Genre> FetchGenreAsync(int genreId)
    {
        var response = await _httpClient.GetAsync(
            $"https://api.rawg.io/api/genres/{genreId}?key={_apiKey}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Unable to find genre with id: {genreId}");
        }
        
        var content = await response.Content.ReadAsStringAsync();
        var rawgGenre = JsonConvert.DeserializeObject<RawgGenre>(content);

        var genre = _mapper.Map<Genre>(rawgGenre);
        
        return genre;
    }

    public async Task<Game> FetchGameAsync(int gameId)
    {
        var response = await _httpClient.GetAsync(
            $"https://api.rawg.io/api/games/{gameId}?key={_apiKey}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Unable to find game with id: {gameId}");
        }
        
        var content = await response.Content.ReadAsStringAsync();
        var rawgGame = JsonConvert.DeserializeObject<RawgGame>(content);

        var game = new Game
        {
            Id = Guid.NewGuid(),
            RawgId = rawgGame.Id,
            Name = rawgGame.Name,
            ReleaseDate = rawgGame.ReleaseDate,
            BackgroundImage = rawgGame.BackgroundImage,
            Metacritic = rawgGame.Metacritic,
            Genres = rawgGame.Genres,
        };

        return game;    }
}