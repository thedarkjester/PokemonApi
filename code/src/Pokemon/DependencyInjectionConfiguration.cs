using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Pokemon.Domain.Services;
using Pokemon.Services;
using Pokemon.Services.Translations;
using System;

namespace Pokemon
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(IConfiguration configuration, IServiceCollection services)
        {
            AddNamedHttpClients(configuration,services);
            RegisterCustomServices(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pokemon API", Version = "v1" });
            });
        }

        private static void AddNamedHttpClients(IConfiguration configuration, IServiceCollection services)
        {
            var pokemonApi = configuration.GetValue<string>("PokeApi:BaseUrl");
            services.AddHttpClient("PokeApi", c =>
            {
                c.BaseAddress = new Uri(pokemonApi);
            });

            var translationApi = configuration.GetValue<string>("TranslationApi:BaseUrl");
            services.AddHttpClient("TranslationApi", c =>
            {
                c.BaseAddress = new Uri(translationApi);
            });
        }

        private static void RegisterCustomServices(IServiceCollection services)
        {
            services.AddSingleton<IPokemonLookupProcessor, PokemonLookupProcessor>();
            services.AddSingleton<IPokemonTranslationOrchestator, PokemonTranslationOrchestator>();
            services.AddSingleton<ITextTranslationProcessor, TextTranslationProcessor>();
        }
    }
}
