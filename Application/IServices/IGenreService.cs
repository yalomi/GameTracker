using Core.Entities;

namespace Application.IServices;

public interface IGenreService
{
    Task<List<Genre>> GetAll();
}