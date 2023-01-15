using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Audio;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

public class SceneBootstrapper : MonoInstaller
{
    [SerializeField] private AudioService audioService;
    
    public override void InstallBindings()
    {
        Container.BindInstance(new EcsWorld());
        Container.BindInterfacesAndSelfTo<SpawnTileService>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ScoreCountService>().AsSingle().NonLazy();
        Container.Bind<AudioService>().FromInstance(audioService).AsSingle().NonLazy();
    }
}
