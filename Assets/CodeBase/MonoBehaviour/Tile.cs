using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpawnTileService _spawnTileService;
    
    public int spawnIndex;

    private void Start()
    {
        _spawnTileService = FindObjectOfType<ServiceInstaller>().SpawnTileService;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 6) return;
        _spawnTileService.SpawnFromPool();
    }
}
