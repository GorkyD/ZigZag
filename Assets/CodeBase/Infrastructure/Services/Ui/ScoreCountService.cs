using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class ScoreCountService
    {
        private SceneData _sceneData;
        private int _score;
        private int _gamesPlayed;
        
        private const string ScoreKey = "ScoreKey";
        private const string GamesKey = "GamesKey";

        private int HighScore
        {
            get => PlayerPrefs.GetInt(ScoreKey);
            set
            {
                if (HighScore < _score)
                {
                    PlayerPrefs.SetInt(ScoreKey, _score);
                }
            } 
        }
        
        public int GamesPlayed
        {
            get => PlayerPrefs.GetInt(GamesKey);
            set => PlayerPrefs.SetInt(GamesKey, value);
        }

        public ScoreCountService()
        {
            _sceneData = Object.FindObjectOfType<SceneData>();
            _sceneData.highScoreText.text = "BEST SCORE: " + HighScore;
            _sceneData.gamesPlayedText.text = "GAMES PLAYED: " + GamesPlayed;
        }

        public void AddScore()
        {
            _score++;
            _sceneData.scoreText.text = _score.ToString();
            HighScore = _score;
            PlayerPrefs.Save();
        }
    }
}