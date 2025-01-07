using UnityEngine;

public class FastEnemy : Enemy
{
    
    private void Awake()
    {
        
        if (EnemyData != null)
        {
            EnemyData.Health = 50;
            EnemyData.Speed = 4f;
            EnemyData.Reward = 10;
        }
    }
}
