using LightBDD.NUnit3;
using NUnit.Framework;
using Pokemon.Tests.Service.Pokemon.Tests.Service;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Pokemon.Tests.Service.APIMocks;
using Pokemon.ApiModels;

namespace Pokemon.Tests.Service.Features
{
    public partial class PokemonEndpoint : FeatureFixture
    {
        private readonly JsonSerializerOptions serializationOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        private HttpClient _httpClient;
        private HttpResponseMessage _response;

        private Task Given_an_http_client()
        {
            _httpClient = TestServer.GetClient();
            return Task.CompletedTask;
        }

        private async Task When_I_call_the_pokemon_endpoint_with_POKEMON(string pokemon)
        {
            _response = await _httpClient.GetAsync($"/pokemon/{pokemon}");
        }

        private Task And_the_lookup_will_return_no_data()
        {
            PokeApiMockDriver.ConfigureNotFoundLookup("charmandermissing");

            return Task.CompletedTask;
        }

        private Task And_the_lookup_will_return_data()
        {
            PokeApiMockDriver.MockSpeciesLookup("ditto");

            return Task.CompletedTask;
        }

        private async Task And_the_pokemon_data_is_correct()
        {
            PokemonOverview pokemonOverview = null;

            using (var jsonStream = await _response.Content.ReadAsStreamAsync())
            {
                pokemonOverview = await JsonSerializer.DeserializeAsync<PokemonOverview>(jsonStream, serializationOptions);
            }

            Assert.NotNull(pokemonOverview, "overview should not be null");
            Assert.AreEqual("I like to describe", pokemonOverview.Description);
            Assert.AreEqual("thedarkside", pokemonOverview.Habitat,"habit is wrong");
            Assert.IsTrue(pokemonOverview.IsLegendary);
        }

        private Task Then_I_should_receive_a_valid_StatusCode(HttpStatusCode statusCode)
        {
            Assert.AreEqual(statusCode, _response.StatusCode, "Status code is not correct");
            return Task.CompletedTask;
        }
    }
}
