using System;
using Enemy.Interface;
using UIScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class Health : IHealthStats
    {
        private IDied _unitDie;
        private IImageClamp _imageClamp;
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }

        public Health(float maxHealth, IDied unitDie, IImageClamp imageClamp)
        {
            MaxHealth = CurrentHealth = maxHealth;
            _unitDie = unitDie;
            _imageClamp = imageClamp;
        }

        public void SetDamage(float value)
        {
            if (value < 0) throw new ArgumentException($"The Argument {nameof(value)} cannot be <0");

            CurrentHealth = Mathf.Clamp(CurrentHealth - value, 0f, MaxHealth);
            
            _imageClamp.SetFillImage.Invoke(CurrentHealth, MaxHealth);
            
            if(CurrentHealth == 0) _unitDie.Died.Invoke();
        }

        public void AddHealth(float value)
        {
            if (value < 0) throw new ArgumentException($"The Argument {nameof(value)} cannot be <0");
            
            CurrentHealth = CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0f, MaxHealth);
            
            _imageClamp.SetFillImage.Invoke(CurrentHealth, MaxHealth);
        }
    }
}