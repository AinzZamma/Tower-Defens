using UnityEngine;

[CreateAssetMenu(fileName = "NewMapData", menuName = "TowerDefense/MapData")]
public class MapData : ScriptableObject
{
    public string MapName;       
    public string SceneName;    
    public Sprite Thumbnail;     
    public int Difficulty;       
    public int RandomSeed;
    public Vector3[] EnemyPath;
    public Vector3[] TowerSpots;
    public int MaxEnemiesOnMap;
    public int StartingGold;

    public Vector3[] DefaultEnemyPath; 
    public Vector3[] DefaultTowerSpots; 
}
