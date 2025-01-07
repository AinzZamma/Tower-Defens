using UnityEngine;

public class SlowTower : Tower
{
    private void Awake()
    {
        AttackRange = 4f;
        Damage = 5f;
        AttackSpeed = 0.5f; 
    }

    protected override void Attack(Enemy target)
    {
        base.Attack(target);

        if (target != null)
        {

            target.ModifySpeed(0.5f);
        }
    }
}
