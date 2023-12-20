using Enemy;
using Enemy.Interface;

namespace Spawner
{
    public class TypeUnit
    {
        private CounterOperations _counterUnitOperations;

        public TypeUnit(CounterOperations counterOperations)
        {
            _counterUnitOperations = counterOperations;
        }

        public bool IsCreateType(UnitEnemy enemy)
        {
            return _counterUnitOperations.GetCountUnitEnemyOnScene(enemy);
        }

    }
}