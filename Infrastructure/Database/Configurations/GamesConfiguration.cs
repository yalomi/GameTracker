using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class GamesConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(g => g.Id);
        
        builder.HasMany(g => g.Genres)
            .WithMany(g => g.Games);
        
        builder.HasMany(g => g.UserGames)
            .WithOne(g => g.Game);
    }
}