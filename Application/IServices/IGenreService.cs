using Core.Entities;

namespace Application.IServices;

public interface IGenreService
{
    IEnumerable<Genre> GetAll();
}