using pokedex.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Application.Interfaces
{
    public interface IPokemonDescription
    {
        Task<Pokemon> GetByName(string pokemonName, bool translateDescription = false);
    }
}
