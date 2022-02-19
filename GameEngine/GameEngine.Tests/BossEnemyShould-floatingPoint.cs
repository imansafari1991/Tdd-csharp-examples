using Xunit;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        [Fact]
        [Trait("Category","Enemy")]
        public void HaveCorrectPower()
        {
            BossEnemy sut = new BossEnemy();

            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }
    }
}
