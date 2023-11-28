using System;
using Enemy.Interface;
using UIScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class Armor : IHealthStats
    {
        public float MaxHealth { get; }
        public float CurrentHealth { get; }

        private IHealthStats _healthStats;
        private IImageClamp _imageClamp;
        private float _armor;
        private float _maxArmor;
        public Armor(IHealthStats stats, float armor, IImageClamp imageClamp)
        {
            _healthStats = stats;
            _armor = armor;
            _imageClamp = imageClamp;
            _maxArmor = _armor;
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
            
            _imageClamp.SetFillImage.Invoke(_armor, _maxArmor);
        }

        public void AddHealth(float value) => _healthStats.AddHealth(value);
    }
}