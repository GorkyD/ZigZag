using CodeBase.Infrastructure.Data;
using CodeBase.Infrastructure.Services;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.Systems
{
    public class ResetWorldInitSystem : IEcsInitSystem
    {
        private ScoreCountService _scoreCountService;
        private SceneData _sceneData;
        public void Init()
        {
            _sceneData.resetButton.onClick.AddListener(() =>
            {
                _scoreCountService.GamesPlayed += 1;
                PlayerPrefs.Save();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            });
        }
    }
}