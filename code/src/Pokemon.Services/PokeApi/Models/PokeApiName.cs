using System.Text.Json.Serialization;

namespace Pokemon.Services.PokeApi.Models
{
    public class PokeApiName
    {
        [JsonPropertyName("species")]
        public PokeApiRestItem Species { get; set; }
    }
}
