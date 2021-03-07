﻿using pokedex.Domain.InfrastructureModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace pokedex.Domain.Interfaces
{
    public interface IPokeApiProvider
    {
        Task<PokemonSpecies> GetPokemonSpeciesByName(string pokemonName);
     
    }
}
