using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.AssetManagment;
using CodeBase.Infrastructure.Data;
using DG.Tweening;
using UnityEngine;

public class SpawnTileService
{
    private List<Tile> _tilesPool = new List<Tile>();
    private Tile[] _tilePrefabs;
    
    private SceneData _sceneData;

    public SpawnTileService()
    {
        _sceneData = Object.FindObjectOfType<SceneData>();
        AssetProvider assetProvider = new AssetProvider();
        _tilePrefabs = new[]
        {
            assetProvider.Load<Tile>(AssetPath.TilePivotBottom),
            assetProvider.Load<Tile>(AssetPath.TilePivotRight)
        };
        
        for (int i = 0; i < 50; i++)
        {
            SpawnTile();
        }
    }

    private void SpawnTile()
    {
        int index = Random.Range(0, 2);
        int crystalSpawn = Random.Range(0, 5); 
        Tile newBase = Object.Instantiate(_tilePrefabs[index],_sceneData.baseTile.transform.GetChild(0).GetChild(index).position,Quaternion.identity);
        _tilesPool.Add(newBase);
        if (crystalSpawn == 0)
        {
            newBase.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);   
        }
        _sceneData.baseTile = newBase.gameObject;
    }

    public void SpawnFromPool()
    {
        int crystalSpawn = Random.Range(0, 5); 
        Tile tileFromPool = _tilesPool.First();
        _tilesPool.Remove(tileFromPool);
        Vector3 tileFromPoolTransformPosition = tileFromPool.transform.position;
        tileFromPool.transform
            .DOMove(new Vector3(tileFromPoolTransformPosition.x, tileFromPoolTransformPosition.y - 5f, tileFromPoolTransformPosition.z), 1f)
            .OnComplete(() =>
            {
                tileFromPool.transform.position = _sceneData.baseTile.transform.GetChild(0).GetChild(tileFromPool.spawnIndex).position;
                _sceneData.baseTile = tileFromPool.gameObject;
                _tilesPool.Add(tileFromPool);
                if (crystalSpawn == 0)
                {
                    tileFromPool.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);   
                }
            });
    }
}
