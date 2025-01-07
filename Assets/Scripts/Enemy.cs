using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData EnemyData;

    private float currentHealth;
    protected float speed;
    private int reward;

    // ѕользовательские параметры
    [Header("Custom Overrides (optional)")]
    public float CustomHealth = 0;
    public float CustomSpeed = 0;
    public int CustomReward = 0;

    protected Transform[] waypoints;
    protected int currentWaypointIndex = 0;

    private void Start()
    {
        if (EnemyData == null)
        {
            Debug.LogError($"EnemyData is not assigned on {gameObject.name}");
            return;
        }

        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        // »нициализаци€ значений: либо из EnemyData, либо из пользовательских параметров
        currentHealth = CustomHealth > 0 ? CustomHealth : EnemyData.Health;
        speed = CustomSpeed > 0 ? CustomSpeed : EnemyData.Speed;
        reward = CustomReward > 0 ? CustomReward : EnemyData.Reward;

        
    }

    public void Initialize(Transform[] path)
    {
        waypoints = path;

        if (waypoints != null && waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
        else
        {
           
        }
    }

    private void Update()
    {
        if (waypoints == null || currentWaypointIndex >= waypoints.Length)
        {
            OnReachEndPoint();
            return;
        }

        MoveTowardsNextWaypoint();
    }

    protected virtual void MoveTowardsNextWaypoint()
    {
        Vector3 target = waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }

    protected virtual void OnReachEndPoint()
    {
       
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        Debug.Log($"Enemy {gameObject.name} destroyed! Player awarded {reward} gold.");
    }

    public void ModifySpeed(float multiplier)
    {
        speed *= multiplier;
        
    }

}
