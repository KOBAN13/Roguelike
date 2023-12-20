using System;
using Configs;
using Enemy;
using Enemy.Interface;
using PoolObject;
using Spawner;
using Zenject;

namespace AbstractFactory.SecondFactory
{
    public class EnemyFactory : AbstractFactoryEnemy, IVisitorEnemyConfigs
    {
        private readonly ITransformPlayer _playerTransform;
        private UnitEnemy _currentCreateEnemy;
        private CounterOperations _counterUnitOperations;
        private TypeUnit _typeUnit;

        private const string KeyForPoolBoar = "Boar";
        private const string KeyForPoolWolf = "Wolf";
        private const string KeyForPoolHuman = "Human";
        private const string KeyForPoolOrk = "Ork";

        public PoolObject<UnitEnemy> PoolUnit { get; private set; }

        public EnemyFactory(ITransformPlayer player, DiContainer container, CounterOperations counterUnitOperations, TypeUnit typeUnit)
        {
            if(player == null || container == null || counterUnitOperations == null)
                throw new ArgumentNullException($"One of the arguments construct is null {nameof(player)} or {nameof(container)} or {nameof(counterUnitOperations)}");
            _counterUnitOperations = counterUnitOperations;
            _playerTransform = player;
            PoolUnit = new PoolObject<UnitEnemy>(container);
            _typeUnit = typeUnit;
        }

        public override UnitEnemy CreateEnemy(IConfigable configs)
        {
            VisitConfig(configs);
            
            _counterUnitOperations.GenerateObject.Invoke(_currentCreateEnemy);
            return _currentCreateEnemy;
        }

        public bool IsACreateUnit(UnitEnemy enemy)
        {
            return enemy == null || _typeUnit.IsCreateType(enemy);
        }

        private void InitializeEnemy(IConfigable config)
        {
            _currentCreateEnemy.Initialize(config, _playerTransform, _counterUnitOperations);
        }

        private void CreateElementOrGet(IPrefab prefab, string keyPool)
        {
            if (_counterUnitOperations.IsCreateNewUnit(prefab.GetPrefab().GetType()))
            {
                PoolUnit.AddElementsInPool(keyPool, prefab.GetPrefab());
            }
        }

        public void Visit(BoarConfig boarConfig)
        {
            CreateElementOrGet(boarConfig.CertainPrefab, KeyForPoolBoar);
            _currentCreateEnemy = PoolUnit.GetElementInPool(KeyForPoolBoar);
            InitializeEnemy(boarConfig);
        }

        public void Visit(WolfConfig wolfConfig)
        {
            CreateElementOrGet(wolfConfig.CertainPrefab, KeyForPoolWolf);
            _currentCreateEnemy = PoolUnit.GetElementInPool(KeyForPoolWolf);
            InitializeEnemy(wolfConfig);
        }

        public void Visit(HumanConfig humanConfig)
        {
            CreateElementOrGet(humanConfig.CertainPrefab, KeyForPoolHuman);
            _currentCreateEnemy = PoolUnit.GetElementInPool(KeyForPoolHuman);
            InitializeEnemy(humanConfig);
        }

        public void Visit(OrkConfig orkConfig)
        {
            CreateElementOrGet(orkConfig.CertainPrefab, KeyForPoolOrk);
            _currentCreateEnemy = PoolUnit.GetElementInPool(KeyForPoolOrk);
            InitializeEnemy(orkConfig);
        }

        public void VisitConfig(IConfigable config)
        {
            Visit((dynamic)config);
        }
    }
}