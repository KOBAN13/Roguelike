using System;
using Configs;
using Enemy.Interface;
using PlayerScripts;
using UIScripts;
using UnityEngine;

namespace Enemy
{
    public abstract class UnitEnemy : MonoBehaviour
    {
        protected Func<float> ApplyDamage { get; set; }
        protected IConfigable Config;

        protected ITransformPlayer TransformPlayer;

        [SerializeField] protected UiBarHealth uiBarHealth;

        public void OnEnable() => AddSubscriptionsOnEvent();

        public void OnDisable() => RemoveSubscriptionsOnEvent();

        protected virtual void AddSubscriptionsOnEvent() {}

        protected virtual void RemoveSubscriptionsOnEvent() {}
        
        public void MoveToSpawnPoint(Vector3 position) => transform.position = position;

        public abstract void Initialize(IConfigable config, ITransformPlayer transformPlayer, IDied<UnitEnemy> onUnitDie);

        public virtual void Update()
        {
            Move();
        }
        public abstract void Move();

        protected void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<IDamagable>(out var player))
            {
                player.Health.SetDamage(ApplyDamage.Invoke());
            }
        }
    }
}