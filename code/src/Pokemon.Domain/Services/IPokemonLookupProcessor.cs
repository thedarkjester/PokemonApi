using Pokemon.Domain.Models;
using System.Threading.Tasks;

namespace Pokemon.Domain.Services
{
    public interface IPokemonLookupProcessor
    {
        Task<PokemonEntity> Process(string pokemonName);
    }
}
