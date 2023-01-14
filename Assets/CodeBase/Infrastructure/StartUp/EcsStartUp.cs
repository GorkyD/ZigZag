using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Systems;
using CodeBase.Infrastructure.Systems.CameraSystems;
using CodeBase.Infrastructure.Systems.PlayerSystems;
using Leopotam.Ecs;
using UnityEngine;
using Zenject;

public class EcsStartUp : MonoBehaviour
{
    public StaticData configuration;
    public SceneData sceneData;
    
    private EcsWorld _ecsWorld;
    private EcsSystems _updateSystems;
    private EcsSystems _fixedUpdateSystems; 
    private EcsSystems _lateUpdateSystems;

    private ScoreCountService _scoreCountService;
    
    [Inject]
    private void Construct(ScoreCountService scoreCountService)
    {
        _scoreCountService = scoreCountService;
    }
    
    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _updateSystems = new EcsSystems(_ecsWorld);
        _fixedUpdateSystems = new EcsSystems(_ecsWorld);
        _lateUpdateSystems = new EcsSystems(_ecsWorld);
        
        _updateSystems
            .Add(new PauseButtonInitSystem())
            .Add(new StartButtonInitSystem())
            .Add(new ResetWorldInitSystem())
            .Add(new PlayerInitSystem())
            .Add(new PlayerInputSystem())
            .Add(new PlayerMoveSystem())
            .Add(new PlayerDeathSystem())
            .Inject(_scoreCountService)
            .Inject(configuration)
            .Inject(sceneData);

        _fixedUpdateSystems
            .Inject(configuration)
            .Inject(sceneData);

        _lateUpdateSystems
            .Add(new CameraInitSystem())
            .Add(new CameraFollowSystem())
            .Inject(configuration)
            .Inject(sceneData);

        _updateSystems.Init();
        _fixedUpdateSystems.Init();
        _lateUpdateSystems.Init();
    }
    
    private void Update()
    {
        _updateSystems?.Run();
    }

    private void FixedUpdate()
    {
        _fixedUpdateSystems?.Run();
    }

    private void LateUpdate()
    {
        _lateUpdateSystems?.Run();
    }

    private void OnDestroy()
    {
        _updateSystems?.Destroy();
        _updateSystems = null;
            
        _fixedUpdateSystems?.Destroy();
        _fixedUpdateSystems = null;
            
        _lateUpdateSystems?.Destroy();
        _lateUpdateSystems = null;

        _ecsWorld?.Destroy();
        _ecsWorld = null;
    }
}
