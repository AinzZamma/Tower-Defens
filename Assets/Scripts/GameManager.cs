using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerLives = 10;   
    public int playerGold = 100;  

    public TextMeshProUGUI livesText; 
    public TextMeshProUGUI goldText;
    

    private int enemiesRemaining = 0; 

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

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateLives(int amount)
    {
        playerLives -= amount;
        if (playerLives <= 0)
        {
            playerLives = 0;
            GameOver();
        }
        UpdateUI();
    }

    public void UpdateGold(int amount)
    {
        playerGold += amount;
        UpdateUI();
    }

    public void EnemySpawned()
    {
        enemiesRemaining++;
    }

    public void EnemyDefeated(int goldReward)
    {
        enemiesRemaining--;
        UpdateGold(goldReward);

        if (enemiesRemaining <= 0 && EnemySpawner.Instance.AllWavesCompleted())
        {
            Victory();
        }
    }

    private void GameOver()
    {
        
        SceneManager.LoadScene("GameOver");
    }

  public  void Victory()
    {
          SceneManager.LoadScene("Victory");
    }

    private void UpdateUI()
    {
        livesText.text = $"Lives: {playerLives}";
        goldText.text = $"Gold: {playerGold}";
    }
}
