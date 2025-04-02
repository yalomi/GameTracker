namespace Application.Dtos;

public class GetGenreDto
{
    public Guid Id { get; set; }
    public int RawgId { get; set; }
    public string? Name { get; set; }
}