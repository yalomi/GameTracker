namespace GameTracker.Domain.Entities;

public class Genre
{
    public Guid Id { get; set; }
    public int RawgId { get; set; }
    public string Name { get; set; } = string.Empty;
    public IEnumerable<Game> Games { get; set; } = [];
}