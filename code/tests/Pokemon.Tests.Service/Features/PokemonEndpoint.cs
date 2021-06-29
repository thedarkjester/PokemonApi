using LightBDD.Framework;
using LightBDD.NUnit3;
using System.Threading.Tasks;
using LightBDD.Framework.Scenarios;
using System.Net;
using System;

namespace Pokemon.Tests.Service.Features
{
    [FeatureDescription(
    @"In order to provide a Pokemon Overview
    As a consumer
    I want the PokemonEndpoint to return an OK result and overview")]
    [Label("Pokemon-scaffold-epic")]
    public partial class PokemonEndpoint
    {
        [Scenario]
        [Label("Pokemon-10")]
        [ScenarioCategory(Categories.PokemonLookup)]
        public async Task Pokemon_Is_Not_Found()
        {
           await Runner.RunScenarioAsync(
                     _ => Given_an_http_client(),
                     _ => And_the_lookup_will_return_no_data(),
                     _ => When_I_call_the_pokemon_endpoint_with_POKEMON("charmandermissing"),
                     _ => Then_I_should_receive_a_valid_StatusCode(HttpStatusCode.NotFound));
        }

        [Scenario]
        [Label("Pokemon-10")]
        [ScenarioCategory(Categories.PokemonLookup)]
        public async Task Pokemon_Is_Found()
        {
            await Runner.RunScenarioAsync(
                      _ => Given_an_http_client(),
                      _ => And_the_lookup_will_return_data(),
                      _ => When_I_call_the_pokemon_endpoint_with_POKEMON("ditto"),
                      _ => Then_I_should_receive_a_valid_StatusCode(HttpStatusCode.OK),
                      _ => And_the_pokemon_data_is_correct()                      );
        }


    }
}
