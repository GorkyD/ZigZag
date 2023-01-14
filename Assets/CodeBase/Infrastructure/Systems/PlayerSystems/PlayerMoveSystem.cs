using CodeBase.Infrastructure.Components;
using CodeBase.Infrastructure.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Infrastructure.Systems.PlayerSystems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<TransformComponent,PlayerComponent,PlayerInputData> _filter;
        private StaticData _staticData;

        public void Run()
        {
            foreach (int i in _filter)
            {
                if (_staticData.isPause == false)
                {
                    ref var playerTransformComponent = ref _filter.Get1(i);
                    ref var playerComponent          = ref _filter.Get2(i);
                    ref var playerInputDataComponent = ref _filter.Get3(i);
                    float amountToMove = playerComponent.PlayerSpeed * Time.deltaTime;
                    playerTransformComponent.Transform.Translate(playerInputDataComponent.Direction * amountToMove);
                }
            }
        }
    }
}