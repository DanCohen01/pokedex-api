using System;
using System.Collections.Generic;
using System.Text;

namespace pokedex.Domain.Models
{
    public class UnknownPokemon : Pokemon
    {
        public UnknownPokemon(string name)
        {
            Name = name;
            Description = "Unknown";
            Habitat = "Unkown";
            IsLegendary = false;

        }
    }
}
