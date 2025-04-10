using Core.Entities;
using Infrastructure.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class GameTrackerContext : DbContext
{
    public GameTrackerContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserGame> UserGames { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GamesConfiguration());
        modelBuilder.ApplyConfiguration(new GenresConfiguration());
        modelBuilder.ApplyConfiguration(new UsersConfiguration());
        modelBuilder.ApplyConfiguration(new UserGamesConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}