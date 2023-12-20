using System;
using Enemy;
using Enemy.Interface;
using Spawner;
using Zenject;

namespace AbstractFactory.SecondFactory
{
    public class Counter : IVisitorEnemy
    {
        public ICounterMax CounterEnemySpawner { get; private set; }

        private int _theNumberActiveBoarUnitsNow;
        private int _theNumberActiveWolfUnitsNow;
        private int _theNumberActiveHumanUnitsNow;
        private int _theNumberActiveOrkUnitsNow;

        [Inject]
        public Counter(ICounterMax counter)
        {
            CounterEnemySpawner = counter ?? throw new ArgumentNullException($"Argument {nameof(counter)} is null");
        }
        
        public CounterOutputParameters VisitBaseEnemy(UnitEnemy enemy, int value) => Visit((dynamic)enemy, value);

        public CounterOutputParameters Visit(Enemy.Boar boar, int value)
            => new(_theNumberActiveBoarUnitsNow += value,
                _theNumberActiveBoarUnitsNow < CounterEnemySpawner.MaximumNumberOfBoarUnits);

        public CounterOutputParameters Visit(Enemy.Wolf wolf, int value)
            => new (_theNumberActiveWolfUnitsNow += value,
                _theNumberActiveWolfUnitsNow < CounterEnemySpawner.MaximumNumberOfWolfUnits);

        public CounterOutputParameters Visit(Enemy.Human human, int value)
            => new (_theNumberActiveHumanUnitsNow += value,
                _theNumberActiveHumanUnitsNow < CounterEnemySpawner.MaximumNumberOfHumanUnits);

        public CounterOutputParameters Visit(Enemy.Ork ork, int value)           
            => new (_theNumberActiveOrkUnitsNow += value,
                _theNumberActiveOrkUnitsNow < CounterEnemySpawner.MaximumNumberOfOrkUnits);
    }
}