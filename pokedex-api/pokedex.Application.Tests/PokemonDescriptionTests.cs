namespace pokedex.Application.Tests
{
    using pokedex.Application;
    using System;
    using NUnit.Framework;
    using NSubstitute;
    using pokedex.Application.Interfaces;
    using System.Threading.Tasks;
    using pokedex.Application.InfrastructureModels;
    using pokedex.Application.Models;
    using System.Linq;

    [TestFixture]
    public class PokemonDescriptionTests
    {
        private PokemonDescription _testClass;

        [SetUp]
        public void SetUp()
        {
          
        }

        [Test]
        public async Task Given_GetByName_When_ValidPokemon_Then_ValidFieldsReturned()
        {
            var pokemonName = "snorlax";
            var pokemonApiProvider = Substitute.For<IPokeApiProvider>();
            pokemonApiProvider.GetPokemonSpeciesByName(pokemonName).Returns(new PokemonSpecies()
            {
                Habitat = new Item() { Name = "some habitat" },
                IsLegendary = false,
                Name = pokemonName,
                FlavorTextEntries = new System.Collections.Generic.List<FlavorTextEntry>(){new FlavorTextEntry(){
            FlavorText = "some description", Language = new Item(){Name = "en"} } }
            });
            _testClass = new PokemonDescription(pokemonApiProvider, Substitute.For<IPokemonTranslation>());
            var result = await _testClass.GetByName(pokemonName, false);
            Assert.IsNotEmpty(result.Description);
            Assert.IsNotEmpty(result.Habitat);
        }

        [Test]
        public async Task Given_GetByName_When_InvalidPokemon_Then_UnknownPokemonReturned()
        {
            var pokemonName = "unknown";
            var pokemonApiProvider = Substitute.For<IPokeApiProvider>();
           
            _testClass = new PokemonDescription(pokemonApiProvider, Substitute.For<IPokemonTranslation>());
            var result = await _testClass.GetByName(pokemonName, false);
            Assert.True(result is UnknownPokemon);
           
        }

        [Test]
        public async Task Given_GetByName_When_TranslateDescription_Then_PokemonTranslationIsCalledOnce()
        {
            var pokemonName = "unknown";
            var pokemonApiProvider = Substitute.For<IPokeApiProvider>();
            var translation = Substitute.For<IPokemonTranslation>();
            pokemonApiProvider.GetPokemonSpeciesByName(pokemonName).Returns(new PokemonSpecies()
            {
                Habitat = new Item() { Name = "some habitat" },
                IsLegendary = false,
                Name = pokemonName,
                FlavorTextEntries = new System.Collections.Generic.List<FlavorTextEntry>(){new FlavorTextEntry(){
            FlavorText = "some description", Language = new Item(){Name = "en"} } }
            });

            _testClass = new PokemonDescription(pokemonApiProvider, translation);
            var result = await _testClass.GetByName(pokemonName, true);
            await translation.Received(1).GetPokemonTranslation("some description", "some habitat", false);
           

        }

        [Test]
        public async Task Given_GetByName_Then_PokemonApiCalledOnce()
        {
            var pokemonName = "snorlax";
            var pokemonApiProvider = Substitute.For<IPokeApiProvider>();
            pokemonApiProvider.GetPokemonSpeciesByName(pokemonName).Returns(new PokemonSpecies()
            {
                Habitat = new Item() { Name = "some habitat" },
                IsLegendary = false,
                Name = pokemonName,
                FlavorTextEntries = new System.Collections.Generic.List<FlavorTextEntry>(){new FlavorTextEntry(){
            FlavorText = "some description", Language = new Item(){Name = "en"} } }
            });
            _testClass = new PokemonDescription(pokemonApiProvider, Substitute.For<IPokemonTranslation>());
            var result = await _testClass.GetByName(pokemonName, false);
            await pokemonApiProvider.Received(1).GetPokemonSpeciesByName(pokemonName);
        }


    }
}