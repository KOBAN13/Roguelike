using System;
using System.Linq;
using AbstractFactory.SecondFactory;
using Enemy;
using Enemy.Interface;
using Zenject;

namespace Spawner
{
    public class CounterOperations : IGenerated<UnitEnemy>, IDied<UnitEnemy>
    {
        public Action<UnitEnemy> Died { get; set; }
        public Action<UnitEnemy> GenerateObject { get; private set; }

        private IListUnit _listCreatedUnits;

        private const int GenerateUnit = 1;
        private const int DieUnit = -1;

        public readonly Counter Counter;
        private CounterOutputParameters _parameters;
        
        [Inject]
        public CounterOperations(Counter counter, IListUnit listCreatedUnits)
        {
            Counter = counter;
            _listCreatedUnits = listCreatedUnits;
            GenerateObject += OnGenerateUnit;
        }

        ~CounterOperations() => GenerateObject -= OnGenerateUnit;

        public bool GetCountUnitEnemyOnScene(UnitEnemy unitInGame)
        {
            _parameters = Counter.VisitBaseEnemy(unitInGame, 0);
            return _parameters.IsSpawnUnit;
        }

        public bool IsCreateNewUnit(Type enemy)
        {
            var countElementEnemyType = _listCreatedUnits.ListCreatedUnits.Count(item => item.GetType() == enemy);

            return countElementEnemyType < 5;
        }
        

        public void OnGenerateUnit(UnitEnemy enemy)
        {
            Counter.VisitBaseEnemy(enemy, GenerateUnit);
        }

        public void OnDiedUnit(UnitEnemy enemy)
        {
            Counter.VisitBaseEnemy(enemy, DieUnit);
        }

    }
}