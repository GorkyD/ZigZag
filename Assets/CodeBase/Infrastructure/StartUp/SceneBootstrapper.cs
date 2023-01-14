using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

public class SceneBootstrapper : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(new EcsWorld());
        Container.BindInterfacesAndSelfTo<SpawnTileService>().AsSingle().NonLazy();
    }
}
