namespace GameTracker.Domain.Entities;

public class RawgGame
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly ReleaseDate { get; set; }
    public string BackgroundImage { get; set; } = string.Empty;
    public int Metacritic { get; set; }
    public List<Genre> Genres { get; set; } = [];
}