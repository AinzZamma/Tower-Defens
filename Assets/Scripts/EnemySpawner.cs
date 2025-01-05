using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] waypoints; // Путь для врагов
    public GameObject[] enemyPrefabs; // Префабы врагов
    public float spawnInterval = 2f; // Интервал появления врагов

    private void Start()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
        {
            Debug.LogError("No enemy prefabs assigned to the spawner!");
            return;
        }

        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned to the spawner!");
            return;
        }

        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        if (enemyPrefabs[randomIndex] == null)
        {
            Debug.LogWarning($"Enemy prefab at index {randomIndex} is null. Skipping spawn.");
            return;
        }

        GameObject enemy = Instantiate(enemyPrefabs[randomIndex], transform.position, Quaternion.identity);

        Enemy enemyComponent = enemy.GetComponent<Enemy>();
        if (enemyComponent != null)
        {
            enemyComponent.Initialize(waypoints);
        }
        else
        {
            Debug.LogError($"Spawned object {enemy.name} does not have an Enemy component. Destroying it.");
            Destroy(enemy);
        }
    }
}
