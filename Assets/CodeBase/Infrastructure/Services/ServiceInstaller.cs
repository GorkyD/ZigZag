using CodeBase.Infrastructure.Services;
using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoBehaviour
{
    public SpawnTileService SpawnTileService;
    public ScoreCountService ScoreCountService;
    
    [Inject]
    private void Construct(SpawnTileService spawnTileService,ScoreCountService scoreCountService)
    {
        SpawnTileService = spawnTileService;
        ScoreCountService = scoreCountService;
    }
}
