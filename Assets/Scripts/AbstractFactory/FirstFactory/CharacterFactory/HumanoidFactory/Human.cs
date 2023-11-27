using System;
using AbstractFactory.CharacterFactory;
using UnityEngine;

namespace AbstractFactory
{
    public class Human : HumanoidFactory
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

        public override void Move() => Debug.Log($"Я {typeof(Human)} и я реализую какое то движение со {nameof(_speed)} {_speed}");

        public override void Damage() => Debug.Log($"Я {typeof(Human)} и наношу дамаг с параметром {_damageTo}");

        public override void ArmYourself() => Debug.Log("Вооружился мечом");
    }
}