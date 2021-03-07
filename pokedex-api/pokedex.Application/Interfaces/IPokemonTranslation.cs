using pokedex.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Application.Interfaces
{
    public interface IPokemonTranslation
    {
        Task<string> GetPokemonTranslation(string description, string habitat, bool isLegendary);
    }
}
