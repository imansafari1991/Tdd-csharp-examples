using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        private readonly ITestOutputHelper _output;
        private readonly PlayerCharacter _sut;
        public EnemyFactoryShould(ITestOutputHelper output)
        {
            _output=output;
            _sut=new PlayerCharacter();
        }

        [Fact(Skip ="Don't need to run this")]
        public void CreateNormalEnemyByDefault()
        {
             EnemyFactory enemyFactory = new EnemyFactory();
            var enemy=enemyFactory.Create("iman");
            Assert.IsType<NormalEnemy>(enemy);
        }
        [Fact]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            _output.WriteLine("Cheking Not Type");
            EnemyFactory enemyFactory = new EnemyFactory();
            var enemy = enemyFactory.Create("iman");
            _output.WriteLine($"enemy name is {enemy.Name}");
            Assert.IsNotType<DateTime>(enemy);
        }
        [Fact]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            // Assert and get cast result
            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            // Additional asserts on typed object
            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            //Assert.IsType<Enemy>(enemy);
            Assert.IsAssignableFrom<Enemy>(enemy);
        }
        [Fact]
        public void CreateSeparateInstances()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
        }
        [Fact]
        public void NotAllowNullName()
        {
            EnemyFactory enemyFactory = new EnemyFactory();

            // Hatman bayad be lambda bashad k dar haman lahze aval ejra nashavad, assert an ra ejra konad
            //Assert.Throws<ArgumentNullException>(()=>enemyFactory.Create(null));
            Assert.Throws<ArgumentNullException>("name",() => enemyFactory.Create(null));
        }
        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyFactory enemyFactory = new EnemyFactory();
            EnemyCreationException ex= Assert.Throws<EnemyCreationException>( () =>enemyFactory.Create("Zombie",true));
            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }

    }
}
