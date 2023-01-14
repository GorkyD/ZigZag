using System;
using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.Services;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Infrastructure.Systems.PlayerSystems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputData> _filter;
        private ScoreCountService _scoreCountService;
        private StaticData _staticData;
        
        public void Run()
        {
            foreach (int i in _filter)
            {
                ref var input = ref _filter.Get1(i);
                if (Input.GetMouseButtonDown(0) && _staticData.isDead == false)
                {
                    input.Direction = input.Direction == Vector3.forward ? Vector3.right : Vector3.forward;

                    if (input.Direction == Vector3.zero)
                    {
                        input.Direction = Vector3.forward;
                    }
                    _scoreCountService.AddScore();
                }
            }
        }
    }
}