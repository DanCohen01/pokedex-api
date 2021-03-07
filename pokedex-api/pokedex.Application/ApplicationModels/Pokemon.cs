using System;
using System.Collections.Generic;
using System.Text;

namespace pokedex.Application.Models
{
    public class Pokemon
    {
        public Pokemon(string name, string description, string habitat, bool isLegendary)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
             
        }
        public string Name { get; private set; }

        public string Description { get; set; }

        public string Habitat { get; private set; }

        public bool IsLegendary { get; private set; }
    }
}
