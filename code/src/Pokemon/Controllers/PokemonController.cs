using Microsoft.AspNetCore.Mvc;
using Pokemon.ApiModels;
using Pokemon.Domain.Services;
using Pokemon.Services;
using System.Net;
using System.Threading.Tasks;

namespace Pokemon.Controllers
{
    [ApiController]
    [Route("pokemon")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonLookupProcessor _pokemonLookupProcessor;

        public PokemonController(IPokemonLookupProcessor pokemonLookupProcessor)
        {
            _pokemonLookupProcessor = pokemonLookupProcessor;
        }

        [HttpGet]
        [Route("{pokemonName}")]
        public async Task<ActionResult<PokemonOverview>> Get([FromRoute] string pokemonName)
        {
            //ideally at this point the name has been sanitised in the pipeline (no weird redirects/javascript etc)
            //I would add that in a production environment
            int responseStatusCode = (int)HttpStatusCode.OK;

            var pokemonLookup = await _pokemonLookupProcessor.Process(pokemonName);

            //ideally there should be a mapper for this

            if(pokemonLookup == null)
            {
                return await Task.FromResult(StatusCode((int)HttpStatusCode.NotFound));
            }

            //I would also put in a mapper of sorts to keep a consistent API model vs. internal
            var pokemonResponse = new PokemonOverview
            {
                Description = pokemonLookup.Description,
                Name = pokemonLookup.Name,
                Habitat = pokemonLookup.Habitat,
                IsLegendary = pokemonLookup.IsLegendary
            };

            return await Task.FromResult(StatusCode(responseStatusCode, pokemonResponse));
        }
    }
}
