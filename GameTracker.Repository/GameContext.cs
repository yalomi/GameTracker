using GameTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameTracker.Repository;

public class GameContext : DbContext
{
    public GameContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
}