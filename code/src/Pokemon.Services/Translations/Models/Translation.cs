using System.Text.Json.Serialization;

namespace Pokemon.Services.Translations.Models
{
    public class Translation
    {
        [JsonPropertyName("success")]
        public TranslationSuccess TranslationSuccess {get;set;}
       
        [JsonPropertyName("contents")]
        public TranslationContents Contents { get; set; }

    }
}
