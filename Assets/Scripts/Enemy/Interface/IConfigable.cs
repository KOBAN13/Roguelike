using Enemy.Interface;
using UnityEngine;

namespace Configs
{
    public interface IConfigable
    { 
        float Speed { get; } 
        float MaxHealth { get; } 
        float Damage { get; }
        GameObject Prefab { get; }
        
        void Accept(IVisitor visitor);
    }
}