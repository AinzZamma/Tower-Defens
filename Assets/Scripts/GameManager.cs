using UnityEngine;


public class GameManager : MonoBehaviour
{
    public MapData SelectedMap;

    private void Start()
    {
        if (SelectedMap != null)
        {
            GenerateMap();
        }
    }

    private void GenerateMap()
    {
        // Генерация путей врагов
        foreach (Vector3 waypoint in SelectedMap.EnemyPath)
        {
            GameObject waypointMarker = new GameObject("Waypoint");
            waypointMarker.transform.position = waypoint;
            waypointMarker.transform.parent = transform; // Для упрощения управления
        }

        // Генерация башенных зон
        foreach (Vector3 towerSpot in SelectedMap.TowerSpots)
        {
            GameObject towerSpotMarker = new GameObject("TowerSpot");
            towerSpotMarker.transform.position = towerSpot;
            // Добавь визуальную подсказку
        }
    }
}
