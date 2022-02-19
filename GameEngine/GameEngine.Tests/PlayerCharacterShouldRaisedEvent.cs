using System;
using Xunit;
namespace GameEngine.Tests
{
    public class PlayerCharacterShouldRaisedEvent
    {
        [Fact]
        public void RaiseSleptEvent()
        {
            PlayerCharacter player = new PlayerCharacter();
            Assert.Raises<EventArgs>(
                handler => player.PlayerSlept += handler,
                handler => player.PlayerSlept -= handler,
                ()=>player.Sleep()
                );
        }
        [Fact]
        public void RaisePropertyChangedEvent()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(10));
        }

        [Theory]
        //[InlineData(0,100)]
        //[InlineData(50, 50)]
        //[InlineData(101, 1)]

        //[MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        [MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
        public void TakeDamage(int damage,int expectedHealth)
        {
            PlayerCharacter sut = new PlayerCharacter();
            sut.TakeDamage(damage);
            Assert.Equal(expectedHealth, sut.Health);
        }

    }
}
