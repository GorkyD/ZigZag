using UnityEngine;

namespace CodeBase.Infrastructure.Data
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [Header("Player")][Space]
        public float playerSpeed;

        [Space][Header("GameStates")][Space]
        public bool isPause = false;
        public bool isStart = false;
        public bool isDead = false;

        [Space] [Header("AudioClips")] [Space] 
        public AudioClip collectSound;
        public AudioClip deathSound;
        public AudioClip turnSound;
    }
}