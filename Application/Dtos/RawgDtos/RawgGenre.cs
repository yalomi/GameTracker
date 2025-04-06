using Newtonsoft.Json;

namespace Application.Dtos;

public class RawgGenre
{
    [JsonProperty("id")]
    public int RawgId { get; set; }
    public string Name { get; set; }
}