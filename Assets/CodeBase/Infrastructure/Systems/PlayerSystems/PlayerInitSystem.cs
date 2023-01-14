using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Infrastructure.Components;
using CodeBase.Infrastructure.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace CodeBase.Infrastructure.Systems.PlayerSystems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld;
        private SceneData _sceneData;
        private StaticData _staticData;
        public void Init()
        {
            EcsEntity playerEntity = _ecsWorld.NewEntity();
            AssetProvider assetProvider = new AssetProvider();
            ref var player = ref playerEntity.Get<PlayerComponent>();
            ref var playerTransform = ref playerEntity.Get<TransformComponent>();
            playerEntity.Get<PlayerInputData>();

            GameObject playerGameObject = Object.Instantiate(assetProvider.Load<GameObject>(AssetPath.Player), _sceneData.playerSpawnPoint.position, Quaternion.identity);
            player.Rigidbody = playerGameObject.GetComponent<Rigidbody>();
            player.PlayerSpeed = _staticData.playerSpeed;
            playerTransform.Transform = playerGameObject.transform;
        }
    }
}