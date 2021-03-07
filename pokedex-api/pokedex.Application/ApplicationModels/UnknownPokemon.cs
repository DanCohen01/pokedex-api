using System;
using System.Collections.Generic;
using System.Text;

namespace pokedex.Application.Models
{
    public class UnknownPokemon : Pokemon
    {
        public UnknownPokemon(string name) : base(name, "Hmm we haven't discovered that one yet", "Unknown", false) { }


    }
}
