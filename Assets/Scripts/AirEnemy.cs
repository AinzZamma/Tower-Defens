using UnityEngine;

public class AirEnemy : Enemy
{
    private void Awake()
    {
        // ������������� ������ ��� ��������� �����
        if (EnemyData != null)
        {
            EnemyData.Health = 80;  // ������� ��������
            EnemyData.Speed = 3f;   // ������� ��������
            EnemyData.Reward = 15;  // ������� �������
        }
    }

    // �������������� �������� ��� �������� ������
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
