using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
}