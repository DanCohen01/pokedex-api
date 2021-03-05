using Microsoft.AspNetCore.Mvc;
using pokedex.Domain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokedex_api
{
    [Route("pokemon")]
    public class PokemonController : ControllerBase 
    {
        [HttpGet, Route("{pokemonName}")]
        public async Task<ActionResult<Pokemon>> PokemonDescription([FromRoute]string pokemonName)
        {
            return await Task.FromResult(Ok(pokemonName));
        }

        [HttpGet, Route("translated/{pokemonName}")]
        public async Task<ActionResult<Pokemon>> PokemonDescriptionWithTranslation([FromRoute] string pokemonName)
        {
            return await Task.FromResult(Ok());
        }
    }
}
