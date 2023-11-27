using Configs;
using Enemy;

namespace AbstractFactory.SecondFactory
{
    public abstract class AbstractFactoryEnemy
    {
        public abstract UnitEnemy CreateEnemy(EnemyFactory enemyFactory, IConfigable configEnemy);
    }
}