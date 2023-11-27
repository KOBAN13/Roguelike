using System;
using AbstractFactory.CharacterFactory;
using UnityEngine;

namespace AbstractFactory
{
    public class Boar : AnimalsFactory
    {
        private float _damageTo;
        private float _speed;
        private float _health;

        public override void Move() => Debug.Log($"Я {nameof(Boar)} и я двигаюсь со скоростью {_speed / 0.5f}");

        public override void Damage() => Debug.Log($"Я {nameof(Boar)} и я наношу дамаг {_damageTo}");

        public override void Initilizate(ConfigUnit configUnit)
        {
            if (configUnit.DamageTo < 0 || configUnit.Speed < 0 || configUnit.Health < 0)
                throw new ArgumentException($"Wrong parameters {nameof(configUnit.DamageTo)} or {nameof(configUnit.Speed)} or {nameof(configUnit.Health)}");

            _damageTo = configUnit.DamageTo;
            _speed = configUnit.Speed;
            _health = configUnit.Health;
        }

        public override void ImproveSomeCharacteristics()
        {
            Debug.Log($"Увеличиный параметр здоровья на x3 {_health}");
            Debug.Log($"Уменьшена скорость передвижения на x0.5 {_speed / 0.5f}");
        }
    }
}