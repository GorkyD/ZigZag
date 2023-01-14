using CodeBase.Infrastructure.Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Audio
{
    public class AudioService : MonoBehaviour
    {
        [SerializeField] private StaticData staticData;
        [SerializeField] private SceneData sceneData;

        public void PlayTurnSound()
        {
            sceneData.audioSource.PlayOneShot(staticData.turnSound);
        }
        
        public void PlayCollectSound()
        {
            sceneData.audioSource.PlayOneShot(staticData.collectSound);
        }
        
        public void PlayDeathSound()
        {
            sceneData.audioSource.PlayOneShot(staticData.deathSound);
        }
    }
}