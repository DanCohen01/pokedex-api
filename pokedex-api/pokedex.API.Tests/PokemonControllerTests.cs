using NSubstitute;
using NUnit.Framework;
using pokedex.Api;
using pokedex.Application.Interfaces;
using pokedex.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NSubstitute.ExceptionExtensions;
using System;

namespace pokedex.API.Tests
{
    [TestFixture]
    public class Tests
    {
        private PokemonController _testClass;

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public async Task Given_PokemonDescription_When_ValidPokemon_Then_200_Returned()
        {
            var pokemonName = "snorlax";
            var pokemonDescription = Substitute.For<IPokemonDescription>();
            pokemonDescription.GetByName(pokemonName).Returns(new Pokemon(pokemonName, "", "", false));
           
            _testClass = new PokemonController(pokemonDescription);
            var result = await _testClass.PokemonDescription(pokemonName);

            Assert.IsInstanceOf<OkObjectResult>(result.Result);
          
        }

        [Test]
        public async Task Given_PokemonDescription_When_Error_Then_500_Returned()
        {
            var pokemonName = "snorlax";
            var pokemonDescription = Substitute.For<IPokemonDescription>();
            pokemonDescription.GetByName(pokemonName).Throws(new Exception() { });
           
            _testClass = new PokemonController(pokemonDescription);
            var result = await _testClass.PokemonDescription(pokemonName);
            var actionResult = result.Result as ObjectResult;
            Assert.AreEqual(actionResult.StatusCode, 500);
            Assert.AreEqual(actionResult.Value, "There was an error getting the pokemon description, please try again. If the error persists contact the support team.");

        }

        [Test]
        public async Task Given_PokemonDescription_When_NotFound_Then_404_Returned()
        {
            var pokemonName = "snorlax";
            var pokemonDescription = Substitute.For<IPokemonDescription>();
            pokemonDescription.GetByName(pokemonName).Returns(new UnknownPokemon(pokemonName));

            _testClass = new PokemonController(pokemonDescription);
            var result = await _testClass.PokemonDescription(pokemonName);

            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);


        }

        [Test]
        public async Task Given_PokemonDescriptionWithTranslation_When_ValidPokemon_Then_200_Returned()
        {
            var pokemonName = "snorlax";
            var pokemonDescription = Substitute.For<IPokemonDescription>();
            pokemonDescription.GetByName(pokemonName, true).Returns(new Pokemon(pokemonName, "", "", false));

            _testClass = new PokemonController(pokemonDescription);
            var result = await _testClass.PokemonDescriptionWithTranslation(pokemonName);

            Assert.IsInstanceOf<OkObjectResult>(result.Result);

        }

        [Test]
        public async Task Given_PokemonDescriptionWithTranslation_When_Error_Then_500_Returned()
        {
            var pokemonName = "snorlax";
            var pokemonDescription = Substitute.For<IPokemonDescription>();
            pokemonDescription.GetByName(pokemonName, true).Throws(new Exception() { });

            _testClass = new PokemonController(pokemonDescription);
            var result = await _testClass.PokemonDescriptionWithTranslation(pokemonName);
            var actionResult = result.Result as ObjectResult;
            Assert.AreEqual(actionResult.StatusCode, 500);
            Assert.AreEqual(actionResult.Value, "There was an error getting the pokemon description with translation, please try again. If the error persists contact the support team.");

        }

        [Test]
        public async Task Given_PokemonDescriptionWithTranslation_When_NotFound_Then_404_Returned()
        {
            var pokemonName = "snorlax";
            var pokemonDescription = Substitute.For<IPokemonDescription>();
            pokemonDescription.GetByName(pokemonName, true).Returns(new UnknownPokemon(pokemonName));

            _testClass = new PokemonController(pokemonDescription);
            var result = await _testClass.PokemonDescriptionWithTranslation(pokemonName);

            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);


        }
    }
}