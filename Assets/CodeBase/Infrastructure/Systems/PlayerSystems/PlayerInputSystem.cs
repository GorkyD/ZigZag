using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Audio;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Infrastructure.Systems.PlayerSystems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputData> _filter;
        private ScoreCountService _scoreCountService;
        private AudioService _audioService;
        private StaticData _staticData;
        
        public void Run()
        {
            foreach (int i in _filter)
            {
                if (_staticData.isDead || _staticData.isPause || _staticData.isCheat) continue;
                
                ref var input = ref _filter.Get1(i);
                if (Input.GetMouseButtonDown(0))
                {
                    input.Direction = input.Direction == Vector3.forward ? Vector3.right : Vector3.forward;

                    if (input.Direction == Vector3.zero)
                    {
                        input.Direction = Vector3.forward;
                    }
                    _scoreCountService.AddScore();
                    _audioService.PlayTurnSound();
                }
            }
        }
    }
}