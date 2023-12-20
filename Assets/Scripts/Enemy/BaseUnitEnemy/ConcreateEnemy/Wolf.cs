using System;
using Configs;
using Enemy.Interface;
using PlayerScripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Enemy
{
    public class Wolf : UnitEnemy, IDamagable, IMovable, IDied<Wolf>, IPrefab
    {
        public IHealthStats Health { get; private set; }
        public Action<Wolf> Died { get; set; }
        public Object Prefab { get; private set; }
        private IDied<UnitEnemy> _unitDieSignal;

        public override void Initialize(IConfigable config, ITransformPlayer transformPlayer, IDied<UnitEnemy> onUnitDie)
        {
            Config = config;
            TransformPlayer = transformPlayer;
            Health = new Health<Wolf>(Config.MaxHealth, this, uiBarHealth, this);

            Died += OnDiedUnit;
            _unitDieSignal = onUnitDie;
        }
        
        public IPrefab GetPrefab()
        {
            Prefab = this;
            return (IPrefab)Prefab;
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

        public void OnDiedUnit(Wolf wolf)
        {
            _unitDieSignal.Died += _unitDieSignal.OnDiedUnit;
            _unitDieSignal.Died.Invoke(wolf);
            wolf.gameObject.SetActive(false);
            _unitDieSignal.Died -= _unitDieSignal.OnDiedUnit;
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
            Died -= OnDiedUnit;
        }
    }
}