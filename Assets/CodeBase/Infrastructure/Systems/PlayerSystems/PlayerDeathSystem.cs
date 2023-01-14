using CodeBase.Infrastructure.Components;
using CodeBase.Infrastructure.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Infrastructure.Systems.PlayerSystems
{
    public class PlayerDeathSystem : IEcsRunSystem
    {
        private EcsFilter<TransformComponent,PlayerComponent,PlayerInputData> _filter;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref var playerTransformComponent = ref _filter.Get1(i);

                Ray rayToDown = new Ray(playerTransformComponent.Transform.position, Vector3.down);

                if (!Physics.Raycast(rayToDown,out _))
                {
                    _staticData.isDead = true;
                    _sceneData.resetButton.gameObject.SetActive(true);
                }
            }    
        }
    }
}