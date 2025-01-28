using Core.Entities;

namespace Infrastructure.Contracts;

public interface IRepositoryBase<T>
{
    Task<List<T>> GetAll();
}