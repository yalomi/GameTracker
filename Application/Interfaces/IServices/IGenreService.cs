using Application.Dtos;

namespace Application.Interfaces.IServices;

public interface IGenreService
{
    Task<List<GetGenreDto>> GetAll();
    Task<GetGenreDto> GetById(Guid id);
    Task CreateOne(int id);
    Task CreateMany();
    Task DeleteOne(Guid id);
}