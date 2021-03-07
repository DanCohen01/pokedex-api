using pokedex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Domain.Interfaces
{
    public interface IPokemonTranslation
    {
        Task<string> GetPokemonTranslation(string description, string habitat, bool isLegendary);
    }
}
