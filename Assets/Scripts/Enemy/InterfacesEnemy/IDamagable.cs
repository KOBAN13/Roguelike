using System;
using Enemy.Interface;

namespace Enemy
{
    public interface IDamagable
    {
        IHealthStats Health { get; }
        float DealDamage();
    }
}