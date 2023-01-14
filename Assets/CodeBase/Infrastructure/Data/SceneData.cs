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
        
        [Space]
        public GameObject baseTile;
        public Transform playerSpawnPoint;
    }
}