
using Microsoft.Extensions.Options;
using pokedex.Application.Configuration;
using pokedex.Application.InfrastructureModels;
using pokedex.Application.Interfaces;
using Serilog;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace pokedex.Infrastructure
{
    public class PokeApiProvider : IPokeApiProvider
    {
        private IHttpClientFactory _httpClientFactory;
        private string _pokemonApiUrl;

        public PokeApiProvider(IHttpClientFactory clientFactory, IOptions<ExternalProviderSettings> externalProviderSettings)
        {
            _httpClientFactory = clientFactory;
            _pokemonApiUrl = externalProviderSettings.Value.PokemonApiUrl;
        }



        public async Task<PokemonSpecies> GetPokemonSpeciesByName(string pokemonName)
        {
            try
            {
                var requestUri = $"{_pokemonApiUrl}/pokemon-species/{pokemonName}";
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(requestUri);

                if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var species = await JsonSerializer.DeserializeAsync<PokemonSpecies>(responseStream);
                return species;

            }
            catch (Exception e)
            {
                Log.Error(e, $"Error calling pokemon api to get species information for pokemon {pokemonName}");
                throw;

            }

        }


    }
}
