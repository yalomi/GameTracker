namespace Application.Dtos.PostDtos;

public class AddGameToCollectionDto
{
    public Guid GameId { get; set; }
    public int Rating { get; set; }
    public string? Review { get; set; }
    public DateOnly FinishedAt { get; set; }
}