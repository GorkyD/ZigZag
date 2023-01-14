using UnityEngine;

namespace CodeBase.Infrastructure.Data
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        [Header("Player")][Space]
        public float playerSpeed;
        public bool isDead = false;
    }
}