using Application.Dtos;
using Core.Entities;

namespace Application.IServices;

public interface IGameService
{
    Task<List<GameDto>> GetAll();
    Task CreateOne(int id);
    Task CreateMany(int quantity);
}