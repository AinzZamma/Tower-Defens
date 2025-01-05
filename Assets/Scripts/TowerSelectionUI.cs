using UnityEngine;

public class TowerSelectionUI : MonoBehaviour
{
    public GameObject[] TowerPrefabs; // ������� �����
    private GameObject selectedTower; // ��������� �����

    public void SelectTower(int index)
    {
        if (index >= 0 && index < TowerPrefabs.Length)
        {
            selectedTower = TowerPrefabs[index];
            Debug.Log($"������� �����: {TowerPrefabs[index].name}");
        }
    }

    public GameObject GetSelectedTower()
    {
        return selectedTower;
    }
}
