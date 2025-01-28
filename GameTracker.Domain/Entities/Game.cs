namespace GameTracker.Domain.Entities;

public class Game
{
    public Guid Id { get; set; }
    public int RawgId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly ReleaseDate { get; set; }
    public string BackgroundImage { get; set; } = string.Empty;
    public int Metacritic { get; set; }
    public List<Genre> Genres { get; set; } = [];
}