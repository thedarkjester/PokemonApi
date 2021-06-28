using System.Text.Json.Serialization;

namespace Pokemon.Services.PokeApi.Models
{
    public class PokeApiRestItem
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
