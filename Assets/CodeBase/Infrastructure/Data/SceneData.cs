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
        public Button startScreenButton;
        public Button resetButton;
        public TextMeshProUGUI scoretext;
        public TextMeshProUGUI highScoreText;
        public TextMeshProUGUI gamesPlayedText;
        
        [Space]
        public GameObject baseTile;
        public Transform playerSpawnPoint;
    }
}