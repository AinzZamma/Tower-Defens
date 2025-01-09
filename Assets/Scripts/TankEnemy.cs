using UnityEngine;

public class TankEnemy : Enemy
{
    private void Awake()
    {
        
        if (EnemyData != null)
        {
            EnemyData.Health = 200;
            EnemyData.Speed = 1.5f;
            EnemyData.Reward = 20;
        }
    }
}

