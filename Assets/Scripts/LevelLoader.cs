using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel()
    {
        if (MapManager.Instance == null)
        {
            Debug.LogError("MapManager.Instance �� ������!");
            return;
        }

        // ���������� LoadSelectedMap ������ LoadScene
        MapManager.Instance.LoadSelectedMap();
    }
}
