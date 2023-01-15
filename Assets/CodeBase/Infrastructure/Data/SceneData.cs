using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.Data
{
    public class SceneData : MonoBehaviour
    {
        [Header("Camera")][Space]
        public Camera mainCamera;
        public Vector3 mainCameraOffset;

        [Space][Header("Ui")][Space]
        public Canvas mainCanvas;
        public Button resetButton;
        public Button startScreenButton;
        public Button pauseButton;
        public Button cheatButton;
        public GameObject inGamePanel;
        public GameObject pausePanel;
        
        [Space]
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI highScoreText;
        public TextMeshProUGUI gamesPlayedText;
        
        [Space]
        public GameObject baseTile;
        public Transform playerSpawnPoint;

        [Space] [Header("Audio")] [Space] 
        public AudioSource audioSource;
    }
}