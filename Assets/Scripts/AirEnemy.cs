using UnityEngine;

public class AirEnemy : Enemy
{
    private void Awake()
    {
        // »нициализаци€ данных дл€ летающего врага
        if (EnemyData != null)
        {
            EnemyData.Health = 80;  // —реднее здоровье
            EnemyData.Speed = 3f;   // —редн€€ скорость
            EnemyData.Reward = 15;  // —редн€€ награда
        }
    }

    // ѕереопредел€ем движение дл€ летающих врагов
    protected override void MoveTowardsNextWaypoint()
    {
        Vector3 target = waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }
}
