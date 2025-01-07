using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel()
    {
        if (MapManager.Instance == null)
        {
            Debug.LogError("MapManager.Instance не найден!");
            return;
        }

        // Используем LoadSelectedMap вместо LoadScene
        MapManager.Instance.LoadSelectedMap();
    }
}
