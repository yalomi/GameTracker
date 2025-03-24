using Application.Dtos;
using Application.IExternalApiServices;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Core.Entities;

namespace Application.Services;

public class GameService : IGameService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly Lazy<IRawgService> _rawgService;
    private readonly IMapper _mapper;

    public GameService(IRepositoryManager repositoryManager, IMapper mapper, IRawgService rawgService)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _rawgService = new Lazy<IRawgService>(rawgService);
    }

    public async Task<List<GameDto>> GetAllAsync()
    {
        var games = await _repositoryManager.GameRepository.GetAllAsync();
        
        var gameDtos = _mapper.Map<List<GameDto>>(games);
        return gameDtos;
    }

    public async Task CreateOne(int id)
    {
        var rawgGame = await _rawgService.Value.FetchGameAsync(id);
        var game = _mapper.Map<Game>(rawgGame);
        await _repositoryManager.GameRepository.AddGameAsync(game, rawgGame);
        await _repositoryManager.SaveAsync();
    }

    public async Task CreateMany(int quantity)
    {
        var rawgGames = await _rawgService.Value.FetchGamesAsync(quantity);
        var games = _mapper.Map<List<Game>>(rawgGames);
        await _repositoryManager.GameRepository.AddGamesAsync(games, rawgGames);
        await _repositoryManager.SaveAsync();
    }
}