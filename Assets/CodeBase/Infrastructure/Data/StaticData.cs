using UnityEngine;

namespace CodeBase.Infrastructure.Data
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [Header("Player")][Space]
        public float playerSpeed;

        [Space] [Header("GameStates")] [Space] 
        public bool isCheat;
        public bool isPause;
        public bool isDead;
        public bool isStart;

        [Space] [Header("AudioClips")] [Space] 
        public AudioClip collectSound;
        public AudioClip deathSound;
        public AudioClip turnSound;
    }
}