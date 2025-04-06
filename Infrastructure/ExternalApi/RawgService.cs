using Application.Dtos;
using Application.IExternalApiServices;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Infrastructure.ExternalApi;

public class RawgService : IRawgService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl = $"https://api.rawg.io/api";

    public RawgService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["Rawg:ApiKey"] ?? throw new Exception("Rawg API Key is missing");
    }

    public async Task<RawgGenre> FetchGenreAsync(int genreId)
    {
        var response = await _httpClient.GetAsync(
            $"{_baseUrl}/genres/{genreId}?key={_apiKey}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Unable to find genre with id: {genreId}");
        }
        
        var content = await response.Content.ReadAsStringAsync();
        var rawgGenre = JsonConvert.DeserializeObject<RawgGenre>(content);
        
        return rawgGenre;
    }

    public async Task<List<RawgGenre>> FetchGenresAsync()
    {
        var response = await _httpClient.GetAsync(
            $"{_baseUrl}/genres?key={_apiKey}");

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Unable to find genres");
        }
        
        var content = await response.Content.ReadAsStringAsync();
        var rawgGenres = JsonConvert.DeserializeObject<RawgGenresResponse>(content).Results;
        return rawgGenres;
    }

    public async Task<RawgGame> FetchGameAsync(int gameId)
    {
        var response = await _httpClient.GetAsync(
            $"{_baseUrl}/games/{gameId}?key={_apiKey}");
    
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Unable to find game with id: {gameId}");
        }
        
        var content = await response.Content.ReadAsStringAsync();
        var rawgGame = JsonConvert.DeserializeObject<RawgGame>(content);
    
        return rawgGame;    
    }

    public async Task<List<RawgGame>> FetchGamesAsync(int quantity)
    {
        var rawgGames = new List<RawgGame>();
        for (int page = 1; page <= quantity; page++)
        {
            var response = await _httpClient.GetAsync(
                $"{_baseUrl}/games?key={_apiKey}&ordering=-metacritic&page_size=40&page={page}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Unable to find games");
            }
            
            var content = await response.Content.ReadAsStringAsync();
            var games = JsonConvert.DeserializeObject<RawgGamesResponse>(content).Results;
            rawgGames.AddRange(games);
        }
        return rawgGames;
    }
}