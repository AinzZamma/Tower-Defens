using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public MapData currentMap;

    public void GenerateMap()
    {
        if (currentMap == null)
        {
            Debug.LogError("Карта не выбрана!");
            return;
        }

        
        Random.InitState(currentMap.RandomSeed);

        
        Vector3[] enemyPath = GenerateEnemyPath(currentMap.DefaultEnemyPath);

       
        Vector3[] towerSpots = GenerateTowerSpots(currentMap.DefaultTowerSpots);

        
        PlaceEnemyPath(enemyPath);
        PlaceTowerSpots(towerSpots);
    }

    private Vector3[] GenerateEnemyPath(Vector3[] defaultPath)
    {
        
        for (int i = 0; i < defaultPath.Length; i++)
        {
            defaultPath[i] += new Vector3(
                Random.Range(-1f, 1f),
                0,
                Random.Range(-1f, 1f)
            );
        }
        return defaultPath;
    }

    private Vector3[] GenerateTowerSpots(Vector3[] defaultSpots)
    {
        
        for (int i = 0; i < defaultSpots.Length; i++)
        {
            defaultSpots[i] += new Vector3(
                Random.Range(-0.5f, 0.5f),
                0,
                Random.Range(-0.5f, 0.5f)
            );
        }
        return defaultSpots;
    }

    private void PlaceEnemyPath(Vector3[] path)
    {
        
        Debug.Log("Путь врагов создан.");
    }

    private void PlaceTowerSpots(Vector3[] spots)
    {
        
        Debug.Log("Зоны башен размещены.");
    }
}
