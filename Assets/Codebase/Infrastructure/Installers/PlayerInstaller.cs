using UnityEngine;
using Zenject;
using Assets.Codebase.Mechanics.ControllSystem;

public class PlayerInstaller : MonoInstaller
{

    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Transform _spawnTransform;
    
    public override void InstallBindings()
    {
        var player = Container.
            InstantiatePrefabForComponent<Player>
            (_player,_spawnTransform);

        Container.BindInterfacesAndSelfTo<Player>().
            FromInstance(player).
            AsSingle().
            NonLazy();
    }
}