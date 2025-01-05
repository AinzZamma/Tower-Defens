using UnityEngine;

public class TowerSelectionUI : MonoBehaviour
{
    public GameObject[] TowerPrefabs; // Префабы башен
    private GameObject selectedTower; // Выбранная башня

    public void SelectTower(int index)
    {
        if (index >= 0 && index < TowerPrefabs.Length)
        {
            selectedTower = TowerPrefabs[index];
            Debug.Log($"Выбрана башня: {TowerPrefabs[index].name}");
        }
    }

    public GameObject GetSelectedTower()
    {
        return selectedTower;
    }
}
