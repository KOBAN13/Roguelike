using System.Collections.Generic;
using AbstractFactory.SecondFactory;
using Enemy.Interface;
using PlayerScripts;
using Spawner;
using UnityEngine;
using Zenject;

public class InstallScene : MonoInstaller
{
    [SerializeField] private Player playerStrategy;
    [SerializeField] private List<ScriptableObject> configs;
    public override void InstallBindings()
    {
        BindPlayer();
        BindCounter();
        BindArgumentsForEnemy();
        BindListUnits();
    }

    private void BindListUnits()
    {
        Container.Bind<IListUnit>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<CounterOperations>().AsSingle().NonLazy();
        Container.Bind<TypeUnit>().AsSingle().NonLazy();
    }
    
    private void BindCounter()
    {
        Container.Bind<ICounterMax>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<Counter>().AsSingle().NonLazy();
    }

    private void BindPlayer()
    {
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(playerStrategy).AsSingle().NonLazy();
    }

    private void BindArgumentsForEnemy()
    {
        Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<List<ScriptableObject>>().FromInstance(configs);
    }
}
