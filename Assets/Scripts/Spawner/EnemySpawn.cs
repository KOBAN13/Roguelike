using System;
using System.Collections;
using System.Collections.Generic;
using Configs;
using Enemy.Interface;
using Spawner;
using UnityEngine;
using Zenject;
using UnitEnemy = Enemy.UnitEnemy;

namespace AbstractFactory.SecondFactory
{
    public class EnemySpawn : MonoBehaviour, ICounterMax, IListUnit
    {
        [SerializeField] private List<Transform> spawnPoint;

        [field: Header("Spawn Settings")]
        [field: SerializeField, Range(1, 20)] public int MaximumNumberOfBoarUnits { get; private set; }
        [field: SerializeField, Range(1, 20)] public int MaximumNumberOfWolfUnits { get; private set; }
        [field: SerializeField, Range(1, 20)] public int MaximumNumberOfHumanUnits { get; private set; }
        [field: SerializeField, Range(1, 20)] public int MaximumNumberOfOrkUnits { get; private set; }
        
        [field : SerializeField] public bool AutoExpandPoolEnemy { get; private set; }
        [SerializeField] private float timeToSpawn;
        
        private List<ScriptableObject> _listConfigs;
        private EnemyFactory _enemyFactory;
        public IReadOnlyList<UnitEnemy> ListCreatedUnits { get; private set; }
        private List<UnitEnemy> _listUnits;

        private Coroutine _coroutineSpawnEnemy;
        
        [Inject]
        public void Construct(EnemyFactory enemyFactory, List<ScriptableObject> configs, CounterOperations counterUnitOperations)
        {
            if (enemyFactory == null || configs == null || counterUnitOperations == null)
                throw new ArgumentNullException($"One of the arguments construct is null {nameof(enemyFactory)} or {nameof(configs)} or {nameof(counterUnitOperations)}");
            
            _enemyFactory = enemyFactory;
            _enemyFactory.PoolUnit.AutoExpandPool = AutoExpandPoolEnemy;
            _listConfigs = configs;
            ListCreatedUnits = _listUnits = new List<UnitEnemy>();
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
                (UnitEnemy enemy, int index) randomPrefab = GetRandomPrefabAndIndex();
                if (_enemyFactory.IsACreateUnit(randomPrefab.Item1))
                {
                    var enemy = GetRandomEnemy(randomPrefab.Item2);
                    _listUnits.Add(enemy);
                    enemy.MoveToSpawnPoint(spawnPoint[UnityEngine.Random.Range(0, spawnPoint.Count)].position);
                    yield return new WaitForSeconds(timeToSpawn);
                }

                yield return null;
            }
        }

        private UnitEnemy GetRandomEnemy(int index) => _enemyFactory.CreateEnemy((IConfigable)_listConfigs[index]);

        private (UnitEnemy, int) GetRandomPrefabAndIndex()
        {
            var index = UnityEngine.Random.Range(0, _listConfigs.Count);
            var config = (IConfigable)_listConfigs[index];
            return ((UnitEnemy)config.Prefab, index);
        }
    }
}
