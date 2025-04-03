using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class GameTrackerContext : DbContext
{
    public GameTrackerContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<User> Users { get; set; }
}