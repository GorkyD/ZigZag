using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoBehaviour
{
    public SpawnTileService SpawnTileService;

    [Inject]
    private void Construct(SpawnTileService spawnTileService)
    {
        SpawnTileService = spawnTileService;
    }
}
