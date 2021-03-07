using Microsoft.AspNetCore.Http;
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
        /// <returns>pokemon description</returns>
        /// <response code="200">pokemon found</response>    
        /// <response code="404">pokemon not found</response> 
        /// <response code="500">error getting pokemon</response> 
        [HttpGet, Route("{pokemonName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        /// <returns>pokemon description</returns>
        /// <response code="200">pokemon found</response>    
        /// <response code="404">pokemon not found</response> 
        /// <response code="500">error getting pokemon</response> 
        [HttpGet, Route("translated/{pokemonName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
