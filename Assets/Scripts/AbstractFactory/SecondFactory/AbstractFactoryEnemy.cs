using Configs;
using Enemy;

namespace AbstractFactory.SecondFactory
{
    public abstract class AbstractFactoryEnemy
    {
        public abstract UnitEnemy CreateEnemy(IConfigable configEnemy);
    }
}