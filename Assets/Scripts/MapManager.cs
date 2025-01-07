using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance { get; private set; }
    public MapData SelectedMap { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetSelectedMap(MapData mapData)
    {
        SelectedMap = mapData;
    }

    public void LoadSelectedMap()
    {
        if (SelectedMap == null)
        {
            Debug.LogError("Карта не выбрана!");
            return;
        }

        string sceneName = SelectedMap.MapName;

        
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"Сцена {sceneName} не найдена! Убедитесь, что она добавлена в Build Settings.");
        }
    }
}
