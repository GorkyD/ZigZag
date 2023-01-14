using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    
    private ServiceInstaller _serviceInstaller;
    
    private void Start()
    {
        _serviceInstaller = FindObjectOfType<ServiceInstaller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 6) return;
        _serviceInstaller.AudioService.PlayCollectSound();
        _serviceInstaller.ScoreCountService.AddScore();
        particleSystem.Play();
        gameObject.SetActive(false);
    }
}
