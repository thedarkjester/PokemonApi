using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Pokemon.Services.PokeApi.Models
{
    public class PokeApiSpecies
    {
        [JsonPropertyName("habitat")]
        public PokeApiRestItem Habitat { get; set; }

        [JsonPropertyName("is_legendary")]
        public bool IsLegendary { get; set; }

        [JsonPropertyName("flavor_text_entries")]
        public IEnumerable<PokeApiFlavourText> FalvourTextEntries { get; set; }
    }
}
