using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelMenu"); 
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");

    }
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings"); 
    }

    public void ExitGame()
    {
        Application.Quit(); 
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Для выхода в редакторе
#endif
    }
}
