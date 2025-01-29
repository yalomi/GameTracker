using System.Linq.Expressions;
using Application.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class
{
    private readonly GameContext _context;

    protected RepositoryBase(GameContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression).AsNoTracking();
    }
    public void Create(T entity)
    {
        _context.Set<T>().AddAsync(entity);
    }
}