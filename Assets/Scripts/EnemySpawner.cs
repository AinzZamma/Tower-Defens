using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;  
        public int count;               
        public float spawnInterval;     
    }

    public Transform[] waypoints;      
    public Wave[] waves;                
    public float timeBetweenWaves = 5f; 

    private int currentWaveIndex = 0;   
    private int enemiesRemainingToSpawn; 
    private bool isSpawning = false;    

    private void Start()
    {
        if (waves == null || waves.Length == 0)
        {
            Debug.LogError("No waves assigned to the spawner!");
            return;
        }

        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned to the spawner!");
            return;
        }

        StartNextWave();
    }

    private void StartNextWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            Wave currentWave = waves[currentWaveIndex];
            enemiesRemainingToSpawn = currentWave.count;
            isSpawning = true;
            InvokeRepeating(nameof(SpawnEnemy), 0f, currentWave.spawnInterval);
        }
        else
        {
            Debug.Log("All waves completed!");
            isSpawning = false;
        }
    }

    private void SpawnEnemy()
    {
        if (enemiesRemainingToSpawn > 0)
        {
            Wave currentWave = waves[currentWaveIndex];
            GameObject enemy = Instantiate(currentWave.enemyPrefab, transform.position, Quaternion.identity);

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

            enemiesRemainingToSpawn--;

            if (enemiesRemainingToSpawn == 0)
            {
                CancelInvoke(nameof(SpawnEnemy));
                currentWaveIndex++;
                Invoke(nameof(StartNextWave), timeBetweenWaves);
            }
        }
    }
}
