using System.Linq.Expressions;
using Application.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public abstract class RepositoryBase<T> : IRepositoryBase<T>
    where T : class
{
    protected readonly TrackerContext Context;

    protected RepositoryBase(TrackerContext context)
    {
        Context = context;
    }

    public IQueryable<T> GetAll() => 
        Context.Set<T>().AsNoTracking();
    

    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
        !trackChanges ? Context.Set<T>().Where(expression).AsNoTracking() 
            : Context.Set<T>().Where(expression);
    
    public async Task CreateAsync(T entity) =>
        await Context.Set<T>().AddAsync(entity);

    public void DeleteAsync(T entity) =>
        Context.Set<T>().Remove(entity);
}