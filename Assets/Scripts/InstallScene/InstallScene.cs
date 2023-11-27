using System.Collections.Generic;
using AbstractFactory.SecondFactory;
using PlayerScripts;
using UnityEngine;
using Zenject;

public class InstallScene : MonoInstaller
{
    [SerializeField] private Player playerStrategy;
    [SerializeField] private List<ScriptableObject> configs;
    public override void InstallBindings()
    {
        BindPlayer();
        BindArgumentsForEnemy();
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
