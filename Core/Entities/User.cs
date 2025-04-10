namespace Core.Entities;

public class User 
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiry { get; set; }
    public List<UserGame> UserGames { get; set; } = new List<UserGame>();
}