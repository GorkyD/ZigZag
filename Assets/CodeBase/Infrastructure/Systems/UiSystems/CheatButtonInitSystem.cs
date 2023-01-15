using CodeBase.Infrastructure.Data;
using Leopotam.Ecs;

namespace CodeBase.Infrastructure.Systems
{
    public class CheatButtonInitSystem : IEcsInitSystem
    {
        private StaticData _staticData;
        private SceneData _sceneData;
        public void Init()
        {
            _staticData.isCheat = false;
            _sceneData.cheatButton.onClick.AddListener(() =>
            {
                _staticData.isCheat = _staticData.isCheat != true;
            }); 
        }
    }
}