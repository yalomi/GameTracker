using Application.Dtos;
using Core.Entities;

namespace Application.IServices;

public interface IGameService
{
    Task<List<GameDto>> GetAllAsync();
    Task CreateOne(int id);
    Task CreateMany(int quantity);
}