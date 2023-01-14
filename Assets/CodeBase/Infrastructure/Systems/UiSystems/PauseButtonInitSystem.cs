using CodeBase.Infrastructure.Data;
using Leopotam.Ecs;

namespace CodeBase.Infrastructure.Systems
{
    public class PauseButtonInitSystem : IEcsInitSystem
    {
        private StaticData _staticData;
        private SceneData _sceneData;
        
        public void Init()
        {
            _staticData.isPause = false;
            _sceneData.pauseButton.onClick.AddListener(() =>
            {
                _staticData.isPause = _staticData.isPause != true;
            });    
        }
    }
}