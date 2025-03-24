using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class TrackerContext : DbContext
{
    public TrackerContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Game> Games { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<User> Users { get; set; }
}