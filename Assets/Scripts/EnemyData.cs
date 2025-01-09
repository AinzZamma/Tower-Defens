using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemies/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string Name; 
    public float Health; 
    public float Speed; 
    public int Reward;  
    public GameObject EnemyPrefab; 
}
