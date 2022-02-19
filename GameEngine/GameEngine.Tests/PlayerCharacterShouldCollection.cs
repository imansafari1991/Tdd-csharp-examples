using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShouldCollection
    {
       
        [Fact]
        public void HaveALongBow()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains("Long Bow", sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.DoesNotContain("Staff Of Wonder", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Contains(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.All(sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }
    }
}
