using CodeBase.Infrastructure.Data;
using Leopotam.Ecs;

namespace CodeBase.Infrastructure.Systems
{
    public class StartButtonInitSystem : IEcsInitSystem
    {
        private StaticData _staticData;
        private SceneData _sceneData;
        public void Init()
        {
            _staticData.isStart = false;
            _sceneData.startScreenButton.onClick.AddListener(() =>
            {
                _staticData.isStart = true;
                _sceneData.inGamePanel.SetActive(true);
                _sceneData.scoreText.gameObject.SetActive(true);
                _sceneData.startScreenButton.gameObject.SetActive(false);
            });
        }
    }
}