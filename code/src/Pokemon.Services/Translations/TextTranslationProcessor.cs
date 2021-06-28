using System.Threading.Tasks;
using Pokemon.Domain.Services;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Pokemon.Services.Translations.Models;

namespace Pokemon.Services
{
    public class TextTranslationProcessor : ITextTranslationProcessor
    {
        private readonly ILogger<TextTranslationProcessor> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public TextTranslationProcessor(ILogger<TextTranslationProcessor> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Process(string stringToTranslate, string translateTo)
        {
            _logger.LogInformation($"Translating {stringToTranslate} into {translateTo}");

            var request = BuildRequestMessage(stringToTranslate,translateTo);
            var client = _httpClientFactory.CreateClient("TranslationApi");
            
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                Translation translationResponse = null;

                using var jsonStream = await response.Content.ReadAsStreamAsync();
                translationResponse = await JsonSerializer.DeserializeAsync<Translation>(jsonStream);

                if(translationResponse.TranslationSuccess.Total > 0)
                {
                    return translationResponse.Contents.Translated;
                }
            }

            return stringToTranslate;
        }

        // this could possibly be extracted into a message builder class
        private HttpRequestMessage BuildRequestMessage(string stringToTranslate, string translateTo)
        {
            var json = JsonSerializer.Serialize(new { text = stringToTranslate });
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var request = new HttpRequestMessage(HttpMethod.Post, $"{translateTo}")
            {
                Content = stringContent
            };

            return request;
        }
    }
}
