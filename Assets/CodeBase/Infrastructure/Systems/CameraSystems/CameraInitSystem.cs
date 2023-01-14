using CodeBase.Infrastructure.Components;
using CodeBase.Infrastructure.Data;
using Leopotam.Ecs;

namespace CodeBase.Infrastructure.Systems.CameraSystems
{
    public class CameraInitSystem : IEcsInitSystem
    {
        private EcsFilter<PlayerComponent,TransformComponent> _playerFilter;
        
        private EcsWorld _ecsWorld;
        private StaticData _staticData;
        private SceneData _sceneData;
        
        public void Init()
        {
            EcsEntity cameraEntity = _ecsWorld.NewEntity();
            
            ref TransformComponent playerTransformComponent = ref _playerFilter.Get2(1);
            ref var cameraComponent = ref cameraEntity.Get<CameraComponent>();
            ref var transformComponent = ref cameraEntity.Get<TransformComponent>();

            transformComponent.Transform = _sceneData.mainCamera.transform;
            cameraComponent.FollowTransform = playerTransformComponent.Transform;
        }
    }
}