namespace pokedex.Application.Tests
{
    using pokedex.Application;
    using System;
    using NUnit.Framework;
    using NSubstitute;
    using pokedex.Application.Interfaces;
    using System.Threading.Tasks;
    using NSubstitute.ExceptionExtensions;

    [TestFixture]
    public class PokemonTranslationTests
    {
        private PokemonTranslation _testClass;

        [SetUp]
        public void SetUp()
        {
           
        }

        [Test]
        public async Task Given_GetPokemonTranslation_When_TranslationSuccesful_NotEmpty()
        {
            var description = "fgfhfdgh";
            var habitat = "TestValue1047355675";
            var isLegendary = false;
            var translation = Substitute.For<ITranslationProvider>();
            translation.TranslateByTranslationType("stuff to translate", Enums.TranslationType.yoda).Returns("translated description");
            _testClass = new PokemonTranslation(translation);
            var result = await _testClass.GetPokemonTranslation(description, habitat, isLegendary);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task Given_GetPokemonTranslation_When_HabitatCave_Then_TranslationProviderCalledOnce()
        {
            var description = "some description";
            var habitat = "cave";
            var isLegendary = false;
            var translation = Substitute.For<ITranslationProvider>();
            translation.TranslateByTranslationType("stuff to translate", Enums.TranslationType.yoda).Returns("translated description");
            _testClass = new PokemonTranslation(translation);
            var result = await _testClass.GetPokemonTranslation(description, habitat, isLegendary);
            await translation.Received(1).TranslateByTranslationType(Arg.Any<string>(), Arg.Any<Enums.TranslationType>());
        }

        [Test]
        public async Task Given_GetPokemonTranslation_When_HabitatCave_Then_Yoda_Used()
        {
            var description = "some description";
            var habitat = "cave";
            var isLegendary = false;
            var translation = Substitute.For<ITranslationProvider>();
            translation.TranslateByTranslationType("stuff to translate", Enums.TranslationType.yoda).Returns("translated description");
            _testClass = new PokemonTranslation(translation);
            var result = await _testClass.GetPokemonTranslation(description, habitat, isLegendary);
            await translation.Received(1).TranslateByTranslationType(Arg.Any<string>(), Enums.TranslationType.yoda);
        }

        [Test]
        public async Task Given_GetPokemonTranslation_When_IsLegendary_Then_TranslationProviderCalledOnce()
        {
            var description = "fgfhfdgh";
            var habitat = "TestValue1047355675";
            var isLegendary = true;
            var translation = Substitute.For<ITranslationProvider>();
            translation.TranslateByTranslationType("stuff to translate", Enums.TranslationType.yoda).Returns("translated description");
            _testClass = new PokemonTranslation(translation);
            var result = await _testClass.GetPokemonTranslation(description, habitat, isLegendary);
            await translation.Received(1).TranslateByTranslationType(Arg.Any<string>(), Arg.Any<Enums.TranslationType>());
        }

        [Test]
        public async Task Given_GetPokemonTranslation_When_IsLegendary_Then_Yoda_Used()
        {
            var description = "fgfhfdgh";
            var habitat = "TestValue1047355675";
            var isLegendary = true;
            var translation = Substitute.For<ITranslationProvider>();
            translation.TranslateByTranslationType("stuff to translate", Enums.TranslationType.yoda).Returns("translated description");
            _testClass = new PokemonTranslation(translation);
            var result = await _testClass.GetPokemonTranslation(description, habitat, isLegendary);
            await translation.Received(1).TranslateByTranslationType(Arg.Any<string>(), Enums.TranslationType.yoda);
        }

     

        [Test]
        public async Task Given_GetPokemonTranslation_When_NotLegendary_And_HabitatNotCave_Then_Shakespeare_Used()
        {
            var description = "fgfhfdgh";
            var habitat = "TestValue1047355675";
            var isLegendary = false;
            var translation = Substitute.For<ITranslationProvider>();
            translation.TranslateByTranslationType("stuff to translate", Enums.TranslationType.yoda).Returns("translated description");
            _testClass = new PokemonTranslation(translation);
            var result = await _testClass.GetPokemonTranslation(description, habitat, isLegendary);
            await translation.Received(1).TranslateByTranslationType(Arg.Any<string>(), Enums.TranslationType.shakespeare);
        }


        [Test]
        public async Task Given_GetPokemonTranslation_When_DescriptionAndHabitatNull_Then_OriginalTypePassedToTranslation()
        {
           
            var isLegendary = false;
            var translation = Substitute.For<ITranslationProvider>();
            _testClass = new PokemonTranslation(translation);
            var result = await _testClass.GetPokemonTranslation(null, null, isLegendary);
            await translation.Received(0).TranslateByTranslationType(null, Enums.TranslationType.original);
            Assert.AreEqual(null, result);
        }

        [Test]
        public async Task Given_GetPokemonTranslation_When_TranslationErrors_Then_OriginalDescriptionReturned()
        {
            var description = "some description";
            var isLegendary = false;
            var translation = Substitute.For<ITranslationProvider>();
            _testClass = new PokemonTranslation(translation);
        
            translation
                .When(_ => _.TranslateByTranslationType("stuff to translate", Enums.TranslationType.yoda)
                .Throws(new Exception()));
          
            var result = await _testClass.GetPokemonTranslation(description, null, isLegendary);
         
            Assert.AreEqual(result, result);
        }



    }
}