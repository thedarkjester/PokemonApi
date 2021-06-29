
using System;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Pokemon.Tests.Service.APIMocks
{
    public static class PokeApiMockDriver
    {
        public static void ConfigureNotFoundLookup(string pokemonName)
        {
            WireMockSetup.WireMockServer
                .Given(Request.Create().WithPath($"/pokemon/{pokemonName}"))
                .RespondWith(Response.Create().WithStatusCode(404));
        }

        public static void MockSpeciesLookup(string pokemonName)
        {
            WireMockSetup.WireMockServer
                .Given(Request.Create().WithPath($"/pokemon/{pokemonName}"))
                .RespondWith(Response.Create()
                .WithStatusCode(200)
                .WithBody(DittoString));

            WireMockSetup.WireMockServer
               .Given(Request.Create().WithPath("/pokemon/species/132/"))
               .RespondWith(Response.Create()
               .WithStatusCode(200)
               .WithBody(DittoSpecies));
        }

        private const string DittoString = "{\"species\":{\"name\":\"ditto\",\"url\":\"http://localhost:1234/pokemon/species/132/\"}}";
        private const string DittoSpecies = "{\"flavor_text_entries\": [ {\"flavor_text\": \"I like to describe\",        \"language\": {            \"name\": \"en\", \"url\": \"https://pokeapi.co/api/v2/language/9/\" },\"version\": {\"name\": \"y\", \"url\": \"https://pokeapi.co/api/v2/version/24/\"        }    }],\"is_legendary\": true,\"habitat\": {    \"name\": \"thedarkside\",    \"url\": \"https://pokeapi.co/api/v2/pokemon-habitat/8/\"}}";
    }
}
