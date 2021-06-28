using System.Text.Json.Serialization;

namespace Pokemon.Services.PokeApi.Models
{
    public class PokeApiFlavourText
    {
        [JsonPropertyName("language")]
        public PokeApiRestItem Language { get; set; }

        [JsonPropertyName("flavor_text")]
        public string Description { get; set; }
    }
}
