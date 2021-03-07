using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pokedex.Application.Configuration;
using pokedex.Application.Interfaces;


namespace pokedex.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppplicationCore(this IServiceCollection services, IConfiguration configuration)
        {
         
            services.AddScoped<IPokemonDescription, PokemonDescription>();
            services.AddScoped<IPokemonTranslation, PokemonTranslation>();
            return services;
        }
    }
}
