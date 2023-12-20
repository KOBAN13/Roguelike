using Enemy;
using Enemy.Interface;

namespace Configs
{
    public interface IConfigable
    { 
        float Speed { get; } 
        float MaxHealth { get; } 
        float Damage { get; }
        float Armor { get; }
        IPrefab Prefab { get; }
    }
}