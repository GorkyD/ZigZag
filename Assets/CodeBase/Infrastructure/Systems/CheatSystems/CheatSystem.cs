using CodeBase.Infrastructure.Components;
using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Audio;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Infrastructure.Systems.CheatSystems
{
    public class CheatSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputData,TransformComponent> _filter;
        private ScoreCountService _scoreCountService;
        private AudioService _audioService;
        private StaticData _staticData;
        
        public void Run()
        {
            foreach (int i in _filter)
            {
                if (!_staticData.isCheat) continue;
                
                ref var input = ref _filter.Get1(i);
                ref var transform = ref _filter.Get2(i);
                
                if (input.Direction == Vector3.zero)
                {
                    input.Direction = Vector3.forward;
                }

                if (input.Direction == Vector3.forward)
                {
                    AutomationChangeDirection(Vector3.forward, Vector3.right,ref transform,ref input);
                }
                
                if (input.Direction == Vector3.right)
                {
                    AutomationChangeDirection(Vector3.right, Vector3.forward,ref transform,ref input);
                }
            }
        }

        private void AutomationChangeDirection(Vector3 currentDirection,Vector3 oppositeDirection,ref TransformComponent transform,ref PlayerInputData input)
        {
            Ray rayToDownWithOffset = new Ray(transform.Transform.position + currentDirection, Vector3.down);
            if (!Physics.Raycast(rayToDownWithOffset,out _))
            {
                input.Direction = oppositeDirection;
                _scoreCountService.AddScore();
                _audioService.PlayTurnSound();
            }
        }
    }
}