using Application.Dtos;

namespace Application.Interfaces.IServices;

public interface IGameService
{
    Task<List<GameDto>> GetAllAsync();
    Task CreateOne(int id);
    Task CreateMany(int quantity);
}