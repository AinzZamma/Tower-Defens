using System.Collections;
using System.Collections.Generic;
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
    private int enemiesRemainingAlive;
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
            enemiesRemainingAlive = currentWave.count; // Устанавливаем кол-во врагов в текущей волне

            isSpawning = true;
            InvokeRepeating(nameof(SpawnEnemy), 0f, currentWave.spawnInterval);
        }
        else
        {
            Debug.Log("All waves completed!");
            CheckVictoryCondition();
        }
    }

    private void SpawnEnemy()
    {
        if (enemiesRemainingToSpawn > 0)
        {
            Wave currentWave = waves[currentWaveIndex];
            GameObject enemy = Instantiate(currentWave.enemyPrefab, transform.position, Quaternion.identity);

            // Уведомляем GameManager о спавне врага
            GameManager.Instance.EnemySpawned();

            // Подписываемся на событие уничтожения
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            if (enemyComponent != null)
            {
                enemyComponent.Initialize(waypoints);
                enemyComponent.OnEnemyDestroyed += OnEnemyDestroyed;
            }
            else
            {
                Destroy(enemy);
            }

            enemiesRemainingToSpawn--;
        }
        else
        {
            CancelInvoke(nameof(SpawnEnemy));
            currentWaveIndex++;
            Invoke(nameof(StartNextWave), timeBetweenWaves);
        }
    }

    private void OnEnemyDestroyed()
    {
        enemiesRemainingAlive--; // Уменьшаем количество оставшихся врагов

        // Проверяем условие победы только после всех волн и врагов
        CheckVictoryCondition();
    }

    private void CheckVictoryCondition()
    {
        if (enemiesRemainingAlive <= 0 && currentWaveIndex >= waves.Length)
        {
            GameManager.Instance.Victory();
        }
    }
}


