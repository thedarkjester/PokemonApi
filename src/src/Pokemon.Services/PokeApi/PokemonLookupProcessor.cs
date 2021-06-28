using Microsoft.Extensions.Logging;
using Pokemon.Services.PokeApi;
using Pokemon.Services.PokeApi.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using System;
using Pokemon.Domain.Models;

namespace Pokemon.Services
{
    public interface IPokemonLookupProcessor
    {
        Task<PokemonEntity> Process(string pokemonName);
    }

    public class PokemonLookupProcessor : IPokemonLookupProcessor
    {
        private readonly ILogger<PokemonLookupProcessor> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public PokemonLookupProcessor(ILogger<PokemonLookupProcessor> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PokemonEntity> Process(string pokemonName)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"pokemon/{pokemonName}");
            var client = _httpClientFactory.CreateClient("PokeApi");
            var response = await client.SendAsync(request);

            _logger.LogInformation($"Lookup for {pokemonName} returned statusCode={response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                PokeApiName nameResponse = null;

                using var jsonStream = await response.Content.ReadAsStreamAsync();
                nameResponse = await JsonSerializer.DeserializeAsync<PokeApiName>(jsonStream);

                _logger.LogInformation($"Retrieving species data for {pokemonName} found Pokemon");
                var speciesData = await LookUpPokemonSpeciesData(client, nameResponse);

                // this ideally should be split into a language parser so that we can swap out later, but that is over-engineering at this point
                var firstEnglishDescription = speciesData.FalvourTextEntries.FirstOrDefault(lang => lang.Language.Name.Equals("en", StringComparison.InvariantCultureIgnoreCase));

                return new PokemonEntity()
                {
                    Name = pokemonName,
                    Description = firstEnglishDescription?.Description,
                    Habitat = speciesData.Habitat.Name,
                    IsLegendary = speciesData.IsLegendary
                };
            }

            return null;
        }

        private async Task<PokeApiSpecies> LookUpPokemonSpeciesData(HttpClient client, PokeApiName nameResponse)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, nameResponse.Species.Url);
            var response = await client.SendAsync(request);
            PokeApiSpecies speciesResponse = null;

            if (response.IsSuccessStatusCode)
            {
                // track found metric
                using var jsonStream = await response.Content.ReadAsStreamAsync();
                speciesResponse = await JsonSerializer.DeserializeAsync<PokeApiSpecies>(jsonStream);
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // track not found metric
                    _logger.LogInformation($"Species data for {nameResponse.Species.Name} not found");
                }
            }

            return speciesResponse;
        }
    }


}
