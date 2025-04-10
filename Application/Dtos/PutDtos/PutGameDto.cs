namespace Application.Dtos.PutDtos;

public class PutGameDto
{
    public int? Rating { get; set; }
    public string? Review { get; set; }
    public DateOnly? FinishedAt { get; set; }
}