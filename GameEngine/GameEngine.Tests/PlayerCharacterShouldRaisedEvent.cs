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
    }
}
