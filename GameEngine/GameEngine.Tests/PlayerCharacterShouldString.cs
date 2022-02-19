using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShouldfloatingPoint:IDisposable
    {
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output;
        public PlayerCharacterShouldfloatingPoint(ITestOutputHelper output)
        {
            _sut = new PlayerCharacter();
            _output=output;
        }
        [Fact]
        public void BeInexperienceWhenWe()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";
            Assert.True(_sut.IsNoob);

        }
        /// <summary>
        /// In this section we are testing String Equilency
        /// </summary>
        [Fact]
        public void CalculateFullName()
        {
            
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";
            Assert.Equal("Sarah Smith", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartingWithFirstName()
        {

            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";
            Assert.StartsWith("Sarah", _sut.FullName);
          
        }
        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.EndsWith("Smith", _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {

            _sut.FirstName = "SARAH";
            _sut.LastName = "SMITH";
            // Ignor Case Sensevity
            Assert.Equal("Sarah Smith", _sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {


            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";

            Assert.Contains("ah Sm", _sut.FullName);
        }


        [Fact]
        public void CalculateFullNameWithTitleCase()
        {

            _sut.FirstName = "iman";
            _sut.LastName = "safari";

            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
        }

        public void Dispose()
        {
            _output.WriteLine($"Disposing Player Character {_sut.FullName}");

        }
    }
}
