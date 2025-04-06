namespace Core.Entities;

public class UserGame
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    public Guid GameId { get; set; }
    
    public int Rating { get; set; }

    public GameStatus Status { get; set; }
    
    public string? Review { get; set; }
    public DateTime AddedAt { get; set; }
    public DateOnly? FinishedAt { get; set; }
    
    public User User { get; set; }
    public Game Game { get; set; }
}