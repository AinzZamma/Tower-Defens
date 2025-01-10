using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager Instance;

    public GameObject[] TowerPrefabs; 
    private GameObject selectedTowerPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectTower(int towerIndex)
    {
        if (towerIndex >= 0 && towerIndex < TowerPrefabs.Length)
        {
            selectedTowerPrefab = TowerPrefabs[towerIndex];
            Debug.Log($"Selected Tower: {selectedTowerPrefab.name}");
        }
    }

    public GameObject GetSelectedTower()
    {
        return selectedTowerPrefab;
    }
}
