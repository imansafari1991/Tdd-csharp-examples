using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShouldNumeric
    {
        
        [Fact]
        public void StartWithDefaultHealth()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.NotEqual(0, sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.Sleep(); // Expect increase between 1 to 100 inclusive

            //Assert.True(sut.Health >= 101 && sut.Health <= 200);
            Assert.InRange(sut.Health, 101, 200);
        }
    }
}
