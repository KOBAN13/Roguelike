using System.Collections.Generic;

namespace Enemy.Interface
{
    public interface IListUnit
    {
        IReadOnlyList<UnitEnemy> ListCreatedUnits { get; }
    }
}