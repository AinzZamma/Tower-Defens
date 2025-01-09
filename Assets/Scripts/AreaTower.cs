using UnityEngine;

public class AreaTower : Tower
{
    private void Awake()
    {
        AttackRange = 3f;
        Damage = 15f;
        AttackSpeed = 0.8f;
    }

    protected override void Attack(Enemy target)
    {
        // Наносит урон всем врагам в радиусе
        Collider[] hits = Physics.OverlapSphere(transform.position, AttackRange);

        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
               
            }
        }
    }
}
