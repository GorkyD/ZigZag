using UnityEngine;

public class Tile : MonoBehaviour
{
    public int spawnIndex;
    private SpawnTileService _spawnTileService;

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
