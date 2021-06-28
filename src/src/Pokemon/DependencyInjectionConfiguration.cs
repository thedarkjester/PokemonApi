using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Pokemon
{
    public static class DependencyInjectionConfiguration
    {
        public static void ConfigureDependencyInjection(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pokemon API", Version = "v1" });
            });
        }
    }
}
