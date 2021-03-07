using pokedex.Domain.Interfaces;
using pokedex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Application
{
    public class PokemonDescription : IPokemonDescription
    {
        public async Task<Pokemon> GetByName(string pokemonName, bool translateDescription = false)
        {
            return await Task.FromResult(new UnknownPokemon(pokemonName));
        }
    }
}
