using CodeBase.Infrastructure.Components;
using CodeBase.Infrastructure.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Infrastructure.Systems.CameraSystems
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private EcsFilter<TransformComponent, CameraComponent> _filter;
        
        private EcsWorld _ecsWorld;
        private SceneData _sceneData;
        private StaticData _staticData;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                if (_staticData.isDead == false)
                {
                    ref var cameraTransform = ref _filter.Get1(i);
                    ref var cameraComponent = ref _filter.Get2(i);

                    cameraTransform.Transform.position = 
                        Vector3.Lerp(cameraTransform.Transform.position,cameraComponent.FollowTransform.position + _sceneData.mainCameraOffset,Time.deltaTime * 10f);
                }
            }
        }
    }
}