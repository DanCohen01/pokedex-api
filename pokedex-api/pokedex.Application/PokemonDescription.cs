using pokedex.Application.Enums;
using pokedex.Application.Interfaces;
using pokedex.Application.Models;
using pokedex.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Serilog;

namespace pokedex.Application
{
    public class PokemonDescription : IPokemonDescription
    {
        private readonly IPokeApiProvider _pokeApiProvider;
        private readonly IPokemonTranslation _pokemonTranslation;

        public PokemonDescription(IPokeApiProvider pokeApiProvider, IPokemonTranslation pokemonTranslation)
        {
            _pokeApiProvider = pokeApiProvider;
            _pokemonTranslation = pokemonTranslation;
        }

     
        public async Task<Pokemon> GetByName(string pokemonName, bool translateDescription = false)
        {
            try {

                var pokemon = await _pokeApiProvider.GetPokemonSpeciesByName(pokemonName);
                if (pokemon == null)
                {
                    return new UnknownPokemon(pokemonName);
                }

                var description = StringFormatter.FormatString(pokemon.FlavorTextEntries.FirstOrDefault(x => x.Language?.Name == "en")?.FlavorText);
         
                var foundPokemon = new Pokemon(pokemon.Name, description, pokemon.Habitat.Name, pokemon.IsLegendary);

                if (translateDescription)
                {
                    foundPokemon.Description = await _pokemonTranslation.GetPokemonTranslation(foundPokemon.Description, foundPokemon.Habitat, foundPokemon.IsLegendary);
                }

            
                return foundPokemon;
              
              
            }
            catch(Exception e)
            {
                Log.Error(e, $"Error pokemonDesription.GetByName for {pokemonName} and translate {translateDescription}");
                throw;
            }
        }
    }
}
