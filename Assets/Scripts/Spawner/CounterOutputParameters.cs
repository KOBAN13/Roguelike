using System;

namespace Spawner
{
    public class CounterOutputParameters
    {
        public readonly int CountElementOnScene;
        public readonly bool IsSpawnUnit;

        public CounterOutputParameters(int countElementOnScene, bool isSpawnUnit)
        {
            CountElementOnScene = countElementOnScene < 0
                ? throw new ArgumentOutOfRangeException($"{nameof(countElementOnScene)} not be < 0")
                : countElementOnScene;
            IsSpawnUnit = isSpawnUnit;
        }
    }
}