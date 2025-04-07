using Application.Dtos.GetDtos;
using Application.Dtos.PostDtos;
using Application.Interfaces.IServices;
using Application.IRepositories;
using AutoMapper;
using Core.Entities;
using Core.Exceptions;

namespace Application.Services;

public class CollectionService : ICollectionService
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public CollectionService(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public async Task<List<GetGameDto>> GetAll(Guid userId)
    {
        var userGames = await _manager.CollectionRepository.GetAll(userId);
        var userGameDtos = userGames.Select(ug => _mapper.Map<GetGameDto>(ug)).ToList();
        return userGameDtos;
    }

    public async Task<GetGameDto> GetById(Guid gameId, Guid userId)
    {
        var gameExists = await _manager.GameRepository.GetByIdAsync(gameId) 
                         ?? throw new GameNotFoundException(gameId);
        
        var game = await _manager.CollectionRepository.GetByGameAndUserId(gameId, userId) 
                   ?? throw new Exception($"User with id {userId} does not have game with id {gameId}");
        
        var gameDto = _mapper.Map<GetGameDto>(game);
        return gameDto;
    }

    public async Task<GetGameDto> AddGameToCollection(PostGameDto gameDto, Guid userId)
    {
        var game = await _manager.GameRepository.GetByIdAsync(gameDto.GameId) 
                   ?? throw new GameNotFoundException(gameDto.GameId);

        var userGame = _mapper.Map<UserGame>(gameDto);
        userGame.UserId = userId;
        
        await _manager.CollectionRepository.AddGameToCollection(userGame);
        await _manager.SaveAsync();

        var createdGameDto = await GetById(userGame.GameId, userGame.UserId);
        return createdGameDto;
    }
}