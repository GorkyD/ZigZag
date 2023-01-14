using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

public class SceneBootstrapper : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(new EcsWorld());
        Container.BindInterfacesAndSelfTo<SpawnTileService>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ScoreCountService>().AsSingle().NonLazy();
    }
}
