using Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public abstract class RepositoryBase
{
    protected readonly GameContext _context;
    public RepositoryBase(GameContext context)
    {
        _context = context;
    }

    //public async Task<List<T>> GetAll() => await _context.Set<T>().ToListAsync();
}