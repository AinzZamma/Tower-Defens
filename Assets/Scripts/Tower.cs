using UnityEngine;

public class Tower : MonoBehaviour
{
    public float AttackRange = 5f;   
    public float Damage = 10f;      
    public float AttackSpeed = 1f;  

    private float attackCooldown = 0f;

    private void Update()
    {
        attackCooldown -= Time.deltaTime;

        Enemy target = FindTarget();
        if (target != null && attackCooldown <= 0f)
        {
            Attack(target);
            attackCooldown = 1f / AttackSpeed;
        }
    }

    private Enemy FindTarget()
    {
        // ����� ���� ������ � ������� �����
        Collider[] hits = Physics.OverlapSphere(transform.position, AttackRange);
        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
                return enemy;
        }

        return null;
    }

    protected virtual void Attack(Enemy target)
    {
        if (target != null)
        {
            target.TakeDamage(Damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // ���������� ������ ����� � ���������
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}

