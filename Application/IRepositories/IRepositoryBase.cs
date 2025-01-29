using System.Linq.Expressions;

namespace Application.IRepositories;

public interface IRepositoryBase<T>
{
    IQueryable<T> GetAll();
    IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
    void Create(T entity);
}