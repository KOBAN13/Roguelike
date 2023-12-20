using System;
using Enemy.Interface;
using UIScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class Health<T> : IHealthStats
    {
        private IDied<T> _unitDie;
        private IImageClamp _imageClamp;
        private T objectEventDie;
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }

        public Health(float maxHealth, IDied<T> unitDie, IImageClamp imageClamp, T objectHealth)
        {
            MaxHealth = CurrentHealth = maxHealth;
            _unitDie = unitDie;
            _imageClamp = imageClamp;
            objectEventDie = objectHealth;
        }

        public void SetDamage(float value)
        {
            if (value < 0) throw new ArgumentException($"The Argument {nameof(value)} cannot be <0");

            CurrentHealth = Mathf.Clamp(CurrentHealth - value, 0f, MaxHealth);
            
            _imageClamp.SetFillImage.Invoke(CurrentHealth, MaxHealth);
            
            if(CurrentHealth == 0) _unitDie.Died.Invoke(objectEventDie);
        }

        public void AddHealth(float value)
        {
            if (value < 0) throw new ArgumentException($"The Argument {nameof(value)} cannot be <0");
            
            CurrentHealth = CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0f, MaxHealth);
            
            _imageClamp.SetFillImage.Invoke(CurrentHealth, MaxHealth);
        }
    }
}