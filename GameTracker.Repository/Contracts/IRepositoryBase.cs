using GameTracker.Domain.Entities;

namespace GameTracker.Repository.Contracts;

public interface IRepositoryBase<T>
{
    Task<List<T>> GetAll();
}