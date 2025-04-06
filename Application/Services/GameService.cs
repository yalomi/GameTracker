using Application.Dtos;
using Application.IExternalApiServices;
using Application.Interfaces.IServices;
using Application.IRepositories;
using AutoMapper;
using Core.Entities;

namespace Application.Services;

public class GameService : IGameService
{
    private readonly IRepositoryManager _manager;
    private readonly Lazy<IRawgService> _rawgService;
    private readonly IMapper _mapper;

    public GameService(
        IRepositoryManager manager, IMapper mapper, IRawgService rawgService)
    {
        _manager = manager;
        _mapper = mapper;
        _rawgService = new Lazy<IRawgService>(rawgService);
    }

    public async Task<List<GameDto>> GetAllAsync()
    {
        var games = await _manager.GameRepository.GetAllAsync();
        
        var gameDtos = _mapper.Map<List<GameDto>>(games);
        return gameDtos;
    }

    public async Task CreateOne(int id)
    {
        var rawgGame = await _rawgService.Value.FetchGameAsync(id);
        var game = _mapper.Map<Game>(rawgGame);
        await _manager.GameRepository.AddGameAsync(game, rawgGame);
        await _manager.SaveAsync();
    }

    public async Task CreateMany(int quantity)
    {
        var rawgGames = await _rawgService.Value.FetchGamesAsync(quantity);
        var games = _mapper.Map<List<Game>>(rawgGames);
        await _manager.GameRepository.AddGamesAsync(games, rawgGames);
        await _manager.SaveAsync();
    }
}