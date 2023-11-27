using System;
using Enemy.Interface;
using UnityEngine;

namespace PlayerScripts
{
    public class Armor : IHealthStats
    {
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }

        private IHealthStats _healthStats;
        private float _armor;

        public Armor(IHealthStats stats, float armor)
        {
            _healthStats = stats;
            _armor = armor;
        }
        
        public void SetDamage(float value)
        {
            if (value < 0) throw new ArgumentException($"Damage {value} cannot be < 0");

            if (_armor - value < 0 && _armor > 0)
            {
                var currentHp = Mathf.Abs(_armor - value);
                _healthStats.SetDamage(currentHp);
                _armor = 0f;
            }
            
            if(_armor == 0) _healthStats.SetDamage(value);
            else
            {
                _armor -= value;
                _healthStats.SetDamage(0f);
            }
        }

        public void AddHealth(float value) => _healthStats.AddHealth(value);
    }
}