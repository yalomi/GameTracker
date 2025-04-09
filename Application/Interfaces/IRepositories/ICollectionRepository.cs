using Application.Dtos.PutDtos;
using Core.Entities;

namespace Application.Interfaces.IRepositories;

public interface ICollectionRepository
{
    Task<List<UserGame>> GetAll(Guid userId);
    Task<UserGame?> GetByGameAndUserId(Guid gameId, Guid userId);
    Task AddUserGame(UserGame userGame);
    Task UpdateUserGame(UserGame userGame, PutGameDto gameDto);
}