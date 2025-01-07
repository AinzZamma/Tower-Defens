using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    private bool isOccupied = false; // ������ �� �����
    public Material AvailableMaterial;
    public Material OccupiedMaterial;
    private GameObject currentTower;


    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        UpdateMaterial();
    }

    public void PlaceTower(GameObject towerPrefab)
    {
        if (isOccupied) return;

        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        isOccupied = true;
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        if (renderer != null)
        {
            renderer.material = isOccupied ? OccupiedMaterial : AvailableMaterial;
        }
    }

    private void OnMouseDown()
    {
        if (currentTower == null)
        {
            TowerSelectionUI uiManager = FindObjectOfType<TowerSelectionUI>();

            if (uiManager == null)
            {
                Debug.LogError("TowerSelectionUI �� ������ � �����!");
                return;
            }

            GameObject selectedTower = uiManager.GetSelectedTower();
            if (selectedTower == null)
            {
                Debug.LogWarning("����� �� �������!");
                return;
            }

            // ������ �����
            currentTower = Instantiate(selectedTower, transform.position, Quaternion.identity);
            UpdateMaterial();
        }
        else
        {
            Debug.Log("��� ����� ��� ������!");
        }
    }


}
