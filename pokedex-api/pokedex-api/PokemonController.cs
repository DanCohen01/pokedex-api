using Microsoft.AspNetCore.Mvc;
using pokedex.Domain.Interfaces;
using pokedex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokedex.Api
{
    [Route("pokemon")]
    public class PokemonController : ControllerBase
    {
        IPokemonDescription _pokemonDescription;

        public PokemonController(IPokemonDescription pokemonDescription)
        {
            _pokemonDescription = pokemonDescription;
        }

        [HttpGet, Route("{pokemonName}")]
        public async Task<ActionResult<Pokemon>> PokemonDescription([FromRoute] string pokemonName)
        {
            var pokemonDescription = await _pokemonDescription.GetByName(pokemonName);
            if (pokemonDescription is UnknownPokemon)
            {
                return NotFound(pokemonDescription);
            }

            return Ok(pokemonDescription);
        }

        [HttpGet, Route("translated/{pokemonName}")]
        public async Task<ActionResult<Pokemon>> PokemonDescriptionWithTranslation([FromRoute] string pokemonName)
        {
            var pokemonDescription = await _pokemonDescription.GetByName(pokemonName, translateDescription: true);
            if (pokemonDescription is UnknownPokemon)
            {
                return NotFound(pokemonDescription);
            }

            return Ok(pokemonDescription);
        }
    }
}
