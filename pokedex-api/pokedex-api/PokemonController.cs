using Microsoft.AspNetCore.Mvc;
using pokedex.Application.Interfaces;
using pokedex.Application.Models;
using Serilog;
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

        /// <summary>
        /// Gets a pokemon description by name
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns></returns>
        [HttpGet, Route("{pokemonName}")]

        public async Task<ActionResult<Pokemon>> PokemonDescription([FromRoute] string pokemonName)
        {
            try
            {
                var pokemonDescription = await _pokemonDescription.GetByName(pokemonName);
                if (pokemonDescription is UnknownPokemon)
                {
                    return NotFound(pokemonDescription);
                }

                return Ok(pokemonDescription);
            }
            catch (Exception e)
            {
                Log.Error(e, $"Error in API PokemonController.PokemonDescription");
                return StatusCode(500, $"There was an error getting the pokemon description, please try again. If the error persists contact the support team.");
            }
        }

        /// <summary>
        /// Gets a pokemon description by name with translation
        /// </summary>
        /// <param name="pokemonName"></param>
        /// <returns></returns>
        [HttpGet, Route("translated/{pokemonName}")]
        public async Task<ActionResult<Pokemon>> PokemonDescriptionWithTranslation([FromRoute] string pokemonName)
        {
            try
            {
                var pokemonDescription = await _pokemonDescription.GetByName(pokemonName, translateDescription: true);
                if (pokemonDescription is UnknownPokemon)
                {
                    return NotFound(pokemonDescription);
                }

                return Ok(pokemonDescription);
            }
            catch (Exception e)
            {
                Log.Error(e, $"Error in API PokemonController.PokemonDescriptionWithTranslation");
                return StatusCode(500, $"There was an error getting the pokemon description with translation, please try again. If the error persists contact the support team.");
            }
        }
    }
}
