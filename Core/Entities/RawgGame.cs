using Newtonsoft.Json;

namespace Core.Entities;

public class RawgGame
{
    [JsonProperty("id")]
    public int RawgId { get; set; }
    public string Name { get; set; } = string.Empty;
    
    [JsonProperty("released")] 
    public string ReleaseDate { get; set; } = string.Empty;
    
    [JsonProperty("background_image")]
    public string BackgroundImage { get; set; } = string.Empty;
    
    public int? Metacritic { get; set; }
    public List<RawgGenre> Genres { get; set; } = new List<RawgGenre>();
}