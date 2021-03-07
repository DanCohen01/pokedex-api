using NUnit.Framework;

namespace pokedex.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        //pokemon has valid - description, habitat and is legenadry status 
        // when pokemon not found unknown is returned 
        // when description cannot be transalated the original is returned 
        //when translatation errors return original 
        //habiatt cave or legendary then yoda else shakespeare
    }
}