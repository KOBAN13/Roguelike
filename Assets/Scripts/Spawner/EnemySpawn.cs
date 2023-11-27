using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Configs;
using Enemy;
using UnityEngine;
using Zenject;

namespace AbstractFactory.SecondFactory
{
    public class EnemySpawn : MonoBehaviour
    {
        [SerializeField] private float timeToSpawn;
        [SerializeField] private List<Transform> spawnPoint;
        private List<ScriptableObject> _listConfigs;
        private EnemyFactory _enemyFactory;
        public List<UnitEnemy> ListCreateUnits { get; private set; }

        private Coroutine _coroutineSpawnEnemy;
        
        [Inject]
        public void Construct(EnemyFactory enemyFactory, List<ScriptableObject> configs)
        {
            if (enemyFactory == null || configs == null)
                throw new ArgumentNullException($"One of the arguments construct is null {nameof(enemyFactory)} or {nameof(configs)}");
            
            _enemyFactory = enemyFactory;
            _listConfigs = configs;
            ListCreateUnits = new List<UnitEnemy>();
        }

        internal void StartSpawnEnemy()
        {
            StopSpawnEnemy();
            _coroutineSpawnEnemy = StartCoroutine(SpawnEnemy());
        }
        
        internal void StopSpawnEnemy()
        {
            if(_coroutineSpawnEnemy != null)
                StopCoroutine(_coroutineSpawnEnemy);
        }

        private IEnumerator SpawnEnemy()
        {
            while (true)
            {
                var enemy = GetRandomEnemy();
                enemy.MoveToSpawnPoint(spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Count)].position);
                ListCreateUnits.Add(enemy);
                yield return new WaitForSeconds(timeToSpawn);
            }
        }

        private UnitEnemy GetRandomEnemy()
        {
            var index = UnityEngine.Random.Range(0, _listConfigs.Count);
            return _enemyFactory.CreateEnemy(_enemyFactory, (IConfigable)_listConfigs[index]);
        }
    }
}
