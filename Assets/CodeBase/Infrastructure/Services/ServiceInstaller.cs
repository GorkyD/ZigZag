using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Audio;
using UnityEngine;
using Zenject;

public class ServiceInstaller : MonoBehaviour
{
    public ScoreCountService ScoreCountService;
    public SpawnTileService SpawnTileService;
    public AudioService AudioService;

    [Inject]
    private void Construct(SpawnTileService spawnTileService,ScoreCountService scoreCountService,AudioService audioService)
    {
        ScoreCountService = scoreCountService;
        SpawnTileService = spawnTileService;
        AudioService = audioService;
    }
}
