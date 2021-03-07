using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pokedex.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace pokedex.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPokeApiProvider, PokeApiProvider>();
            services.AddSingleton<ITranslationProvider, TranslationProvider>();
            return services;
        }
    }
}
