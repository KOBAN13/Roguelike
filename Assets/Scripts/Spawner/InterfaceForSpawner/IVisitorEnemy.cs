using Spawner;

using AbstractFactory.SecondFactory;

namespace Enemy.Interface
{
    public interface IVisitorEnemy
    {
        CounterOutputParameters Visit(Boar boar, int value);
        CounterOutputParameters Visit(Wolf wolf, int value);
        CounterOutputParameters Visit(Human human, int value);
        CounterOutputParameters Visit(Ork ork, int value);
        CounterOutputParameters VisitBaseEnemy(UnitEnemy enemy, int value);
    }
}