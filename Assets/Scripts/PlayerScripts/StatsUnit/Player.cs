using System;
using Configs;
using Enemy;
using Enemy.Interface;
using UIScripts;
using UnityEngine;
using Zenject;

namespace PlayerScripts
{
    public class Player : MonoBehaviour, ITransformPlayer, IDamagable, IDied<Player> 
    {
        public IHealthStats Health { get; private set; }
        public Func<float> ApplyDamage { get; private set; }
        public Action<Player> Died { get; set; }

        public Transform PlayerTransform => transform;
        [SerializeField] private PlayerConfig config;
        [SerializeField] private UiBarHealth imageClampHealth;
        [SerializeField] private UiBarArmor imageClampArmor;

        [Inject]
        public void Construct()
        {
            Health = new Armor(new Health<Player>(config.MaxHealth, this, imageClampHealth, this), config.Armor, imageClampArmor);
        }

        public void OnEnable()
        {
            ApplyDamage += DealDamage;
            Died += OnDiedUnit;
        }

        public void OnDisable()
        {
            ApplyDamage -= DealDamage;
            Died -= OnDiedUnit;
        }

        public float DealDamage() => config.Damage;

        public void OnDiedUnit(Player player) => player.gameObject.SetActive(false);

        public void OnCollisionEnter(Collision enemyCollider)
        {
            if (enemyCollider.gameObject.TryGetComponent<IDamagable>(out var enemy))
            {
               enemy.Health.SetDamage(ApplyDamage.Invoke());
            }
        }
    }
}