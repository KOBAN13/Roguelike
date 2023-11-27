using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Configs;
using Enemy;
using Enemy.Interface;
using Zenject;

namespace AbstractFactory.SecondFactory
{
    public class EnemyFactory : AbstractFactoryEnemy, IVisitor
    {
        private readonly ITransformPlayer _playerTransform;
        private DiContainer _container;
        private UnitEnemy _currentCreateEnemy;

        public EnemyFactory(DiContainer container, ITransformPlayer player)
        {
            _playerTransform = player ?? throw new NullReferenceException($"{nameof(player)}");
            _container = container;
        }

        public override UnitEnemy CreateEnemy(EnemyFactory enemyFactory, IConfigable configs)
        {
            configs.Accept(enemyFactory);
            
            return _currentCreateEnemy;
        }

        private TEnemy CreateNewEnemy<TEnemy>(IConfigable config) where TEnemy : UnitEnemy
        {
            return _container.InstantiatePrefabForComponent<TEnemy>(config.Prefab);
        }

        private void InitializeEnemy(IConfigable config)
        {
            _currentCreateEnemy.Initialize(config, _playerTransform);
        }

        public void Visit(BoarConfig boarConfig)
        {
            _currentCreateEnemy = CreateNewEnemy<Enemy.Boar>(boarConfig);
            InitializeEnemy(boarConfig);
        }

        public void Visit(WolfConfig wolfConfig)
        {
            _currentCreateEnemy = CreateNewEnemy<Enemy.Wolf>(wolfConfig);
            InitializeEnemy(wolfConfig);
        }

        public void Visit(HumanConfig humanConfig)
        {
            _currentCreateEnemy = CreateNewEnemy<Enemy.Human>(humanConfig);
            InitializeEnemy(humanConfig);
        }

        public void Visit(OrkConfig orkConfig)
        {
            _currentCreateEnemy = CreateNewEnemy<Enemy.Ork>(orkConfig);
            InitializeEnemy(orkConfig);
        }
    }
}