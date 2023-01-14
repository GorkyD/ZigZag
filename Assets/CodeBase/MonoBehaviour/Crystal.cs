using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 6) return;
        particleSystem.Play();
        gameObject.SetActive(false);
    }
}
