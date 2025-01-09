using UnityEngine;

public class BossEnemy : Enemy
{
    private void Awake()
    {
        
        if (EnemyData != null)
        {
            EnemyData.Health = 300; 
            EnemyData.Speed = 1f;    
            EnemyData.Reward = 30;   
        }
    }

    
}
