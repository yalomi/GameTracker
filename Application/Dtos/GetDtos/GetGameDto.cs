using Core.Entities;

namespace Application.Dtos.GetDtos;

public class GetGameDto
{
    public Guid Id { get; set; }
    public int Rawgid { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly? ReleaseDate { get; set; }
    public string? BackgroundImage { get; set; } = string.Empty;
    public int? Metacritic { get; set; }
    public List<string> GenresNames { get; set; } = new List<string>();
    public GameStatus Status { get; set; }
    public string? Review { get; set; }
    public DateOnly? FinishedAt { get; set; }
}