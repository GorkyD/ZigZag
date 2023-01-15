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
            _sceneData.cheatButtonOn.onClick.AddListener(() => { _staticData.isCheat = _staticData.isCheat != true; }); 
            _sceneData.cheatButtonOff.onClick.AddListener(() => { _staticData.isCheat = _staticData.isCheat != true; }); 
        }
    }
}