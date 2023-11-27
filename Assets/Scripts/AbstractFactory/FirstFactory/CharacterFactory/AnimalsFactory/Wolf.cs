using System;
using AbstractFactory.CharacterFactory;
using UnityEngine;

namespace AbstractFactory
{
    public class Wolf : AnimalsFactory
    {
        private float _damageTo;
        private float _speed;
        private float _health;

        public override void Initilizate(ConfigUnit configUnit)
        {
            if (configUnit.DamageTo < 0 || configUnit.Speed < 0 || configUnit.Health < 0)
                throw new ArgumentException($"Wrong parameters {nameof(configUnit.DamageTo)} or {nameof(configUnit.Speed)} or {nameof(configUnit.Health)}");

            _damageTo = configUnit.DamageTo;
            _speed = configUnit.Speed;
            _health = configUnit.Health;
        }

        public override void Move() => Debug.Log($"Я {nameof(Wolf)} и я двигаюсь со скоростью {_speed * 2}");

        public override void Damage() => Debug.Log($"Я {nameof(Wolf)} и я наношу дамаг {_damageTo}");

        public override void ImproveSomeCharacteristics()
        {
            Debug.Log("Ночное зрение");
            Debug.Log($"Повышенное значение {nameof(_speed)} x2 {_speed * 2}");
        }
    }
}