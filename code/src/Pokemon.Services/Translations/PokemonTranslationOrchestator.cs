using System.Threading.Tasks;
using Pokemon.Domain.Models;
using Pokemon.Domain.Services;
using System;
using Microsoft.Extensions.Logging;

namespace Pokemon.Services.Translations
{
    public class PokemonTranslationOrchestator : IPokemonTranslationOrchestator
    {
        private readonly IPokemonLookupProcessor _pokemonLookupProcessor;
        private readonly ITextTranslationProcessor _textTranslationProcessor;
        private readonly ILogger<PokemonTranslationOrchestator> _logger;

        public PokemonTranslationOrchestator(
            ILogger<PokemonTranslationOrchestator> logger,
            IPokemonLookupProcessor pokemonLookupProcessor,
            ITextTranslationProcessor textTranslationProcessor)
        {
            _logger = logger;
            _pokemonLookupProcessor = pokemonLookupProcessor;
            _textTranslationProcessor = textTranslationProcessor;
        }

        public async Task<PokemonEntity> Orchestrate(string pokemonName)
        {
            var pokemonEntity = await _pokemonLookupProcessor.Process(pokemonName);

            if (pokemonEntity != null)
            {
                if (ShouldGetYodaTranslation(pokemonEntity))
                {
                    await TryTranslate(pokemonEntity, "yoda");
                }
                else
                {
                    await TryTranslate(pokemonEntity, "shakespeare");
                }
            }

            return pokemonEntity;
        }

        private async Task TryTranslate(PokemonEntity pokemonEntity, string translateTo)
        {
            try
            {
                var translatedText = await _textTranslationProcessor.Process(pokemonEntity.Description, translateTo);

                pokemonEntity.Description = translatedText;
            }
            catch (Exception exception) //very brute force, ideally a fallthrough with better error codes 
            {
                // there is no PII or security risk in here, so I can log the full exception
                _logger.LogInformation($"An error occured when translating the {pokemonEntity.Name} description to {translateTo}. Exception={exception}");
            }
        }

        private bool ShouldGetYodaTranslation(PokemonEntity pokemonEntity)
        {
            return pokemonEntity.IsLegendary || pokemonEntity.Habitat.Equals("cave", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
