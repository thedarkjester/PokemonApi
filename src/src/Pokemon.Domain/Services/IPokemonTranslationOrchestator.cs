using Pokemon.Domain.Models;
using System.Threading.Tasks;

namespace Pokemon.Domain.Services
{
    public interface IPokemonTranslationOrchestator
    {
        Task<PokemonEntity> Orchestrate(string pokemonName);
    }
}
