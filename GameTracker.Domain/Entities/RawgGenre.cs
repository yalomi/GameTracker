using Newtonsoft.Json;

namespace GameTracker.Domain.Entities;

public class RawgGenre
{
    [JsonProperty("id")]
    public int RawgId { get; set; }
    public string Name { get; set; }
}