using CodeBase.Infrastructure.Data;
using Leopotam.Ecs;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Systems
{
    public class ResetWorldInitSystem : IEcsInitSystem
    {
        private SceneData _sceneData;
        public void Init()
        {
            _sceneData.resetButton.onClick.AddListener(() =>  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
        }
    }
}