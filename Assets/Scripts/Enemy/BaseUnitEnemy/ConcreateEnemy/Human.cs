using System;
using Configs;
using Enemy.Interface;
using PlayerScripts;
using UIScripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Enemy
{
    public class Human : UnitEnemy, IDamagable, IMovable, IDied<Human>, IPrefab
    {
        public IHealthStats Health { get; private set; }
        public Action<Human> Died { get; set; }
        public Object Prefab { get; private set; }
        
        [SerializeField] private UiBarArmor imageClampArmor;
        private IDied<UnitEnemy> _unitDieSignal;

        public override void Initialize(IConfigable config, ITransformPlayer transformPlayer, IDied<UnitEnemy> onUnitDie)
        {
            Config = config;
            TransformPlayer = transformPlayer;
            Health =  new Armor(new Health<Human>(Config.MaxHealth, this, uiBarHealth, this), Config.Armor, imageClampArmor);

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

        public void OnDiedUnit(Human human)
        {
            _unitDieSignal.Died += _unitDieSignal.OnDiedUnit;
            _unitDieSignal.Died.Invoke(human);
            human.gameObject.SetActive(false);
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