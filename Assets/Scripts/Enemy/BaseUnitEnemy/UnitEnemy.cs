using System;
using Configs;
using Enemy.Interface;
using PlayerScripts;
using UnityEngine;

namespace Enemy
{
    public abstract class UnitEnemy : MonoBehaviour
    {
        public IConfigable Config { get; protected set; }
        protected Func<float> ApplyDamage { get; set; }

        protected ITransformPlayer TransformPlayer;

        public void OnEnable() => AddSubscriptionsOnEvent();

        public void OnDisable() => RemoveSubscriptionsOnEvent();

        protected virtual void AddSubscriptionsOnEvent()
        { 
        
        }

        protected virtual void RemoveSubscriptionsOnEvent() {}
        public void MoveToSpawnPoint(Vector3 position) => transform.position = position;

        public abstract void Initialize(IConfigable config, ITransformPlayer transformPlayer);

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
        
        protected virtual void DiedUnit() => Destroy(gameObject);
    }
}