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

        // Установка Random Seed
        Random.InitState(currentMap.RandomSeed);

        // Рандомизация пути врагов
        Vector3[] enemyPath = GenerateEnemyPath(currentMap.DefaultEnemyPath);

        // Рандомизация зон башен
        Vector3[] towerSpots = GenerateTowerSpots(currentMap.DefaultTowerSpots);

        // Реализация изменений на карте
        PlaceEnemyPath(enemyPath);
        PlaceTowerSpots(towerSpots);
    }

    private Vector3[] GenerateEnemyPath(Vector3[] defaultPath)
    {
        // Слегка варьируем координаты пути
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
        // Перемещаем башенные зоны в пределах небольшого радиуса
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
        // Создание объекта пути (например, LineRenderer или Waypoints)
        Debug.Log("Путь врагов создан.");
    }

    private void PlaceTowerSpots(Vector3[] spots)
    {
        // Размещение объектов башенных зон
        Debug.Log("Зоны башен размещены.");
    }
}
