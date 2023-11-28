using System;
using Configs;
using Enemy.Interface;
using PlayerScripts;
using UnityEngine;

namespace Enemy
{
    public class Boar : UnitEnemy, IDamagable, IMovable, IDied
    {
        public IHealthStats Health { get; private set; }
        public Action Died { get; private set; }

        public override void Initialize(IConfigable config, ITransformPlayer transformPlayer)
        {
            Config = config;
            TransformPlayer = transformPlayer;
            Health = new Health(Config.MaxHealth, this, uiBarHealth);

            Died += DiedUnit;
        }

        public float DealDamage() => Config.Damage;

        public override void Move()
        {
            Vector3 direction = (TransformPlayer.PlayerTransform.position - transform.position).normalized;
            transform.Translate(direction * (Config.Speed * Time.deltaTime));
        }

        public override void Update()
        {
            base.Update();
            Move();
        }

        protected override void AddSubscriptionsOnEvent()
        {
            base.AddSubscriptionsOnEvent();
            ApplyDamage += DealDamage;
        }

        protected override void RemoveSubscriptionsOnEvent()
        {
            base.RemoveSubscriptionsOnEvent();
            ApplyDamage -= DealDamage;
            Died -= DiedUnit;
        }
    }
}