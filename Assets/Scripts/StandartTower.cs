using UnityEngine;

public class StandardTower : Tower
{
    private void Awake()
    {
        AttackRange = 5f;
        Damage = 10f;
        AttackSpeed = 1f;
    }
}