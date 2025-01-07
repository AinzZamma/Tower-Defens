using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour
{
    public void Forest()
    {
        SceneManager.LoadScene("Forest");
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");

    }
    public void Desert()
    {
        SceneManager.LoadScene("Desert");
    }

    public void Winter()
    {
        SceneManager.LoadScene("Winter");
    }


    public void Vulcano()
    {
        SceneManager.LoadScene("Vulcano");
    }

   
}
