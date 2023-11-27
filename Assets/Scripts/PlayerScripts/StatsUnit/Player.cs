using System;
using Configs;
using Enemy;
using Enemy.Interface;
using UnityEngine;
using Zenject;

namespace PlayerScripts
{
    public class Player : MonoBehaviour, ITransformPlayer, IDamagable, IDied 
    {
        public IHealthStats Health { get; private set; }
        public Func<float> ApplyDamage { get; private set; }
        public Action Died { get; private set; }
        
        public Transform PlayerTransform => transform;
        [SerializeField] private PlayerConfig config;


        [Inject]
        public void Construct()
        {
            Health = new Armor(new Health(config.MaxHealth, this), config.Armor);
        }

        public void OnEnable()
        {
            ApplyDamage += DealDamage;
            Died += PlayerDied;
        }

        public void OnDisable()
        {
            ApplyDamage -= DealDamage;
            Died -= PlayerDied;
        }

        public float DealDamage() => config.Damage;

        public void OnCollisionEnter(Collision enemyCollider)
        {
            if (enemyCollider.gameObject.TryGetComponent<IDamagable>(out var enemy))
            {
               enemy.Health.SetDamage(ApplyDamage.Invoke());
            }
        }

        private void PlayerDied() => gameObject.SetActive(false);
    }
}