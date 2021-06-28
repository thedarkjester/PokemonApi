using System.Text.Json.Serialization;

namespace Pokemon.Services.Translations.Models
{
    public class TranslationSuccess
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}