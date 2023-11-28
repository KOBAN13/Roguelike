using System;
using Configs;
using Enemy.Interface;
using PlayerScripts;
using UIScripts;
using UnityEngine;

namespace Enemy
{
    public class Human : UnitEnemy, IDamagable, IMovable, IDied
    {
        public IHealthStats Health { get; private set; }
        public Action Died { get; private set; }
        
        [SerializeField] private UiBarArmor imageClampArmor;

        public override void Initialize(IConfigable config, ITransformPlayer transformPlayer)
        {
            Config = config;
            TransformPlayer = transformPlayer;
            Health =  new Armor(new Health(Config.MaxHealth, this, uiBarHealth), Config.Armor, imageClampArmor);

            Died += DiedUnit;
        }

        public float DealDamage() => Config.Damage;

        public override void Move()
        {
            Vector3 direction = (TransformPlayer.PlayerTransform.position - transform.position).normalized;
            transform.Translate(direction * Config.Speed * Time.deltaTime);
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