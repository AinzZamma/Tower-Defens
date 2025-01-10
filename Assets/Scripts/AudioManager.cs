using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip menuMusic;
    public AudioClip levelMusic;
    public AudioClip victoryMusic;
    public AudioClip gameoverMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMenuMusic()
    {
        PlayMusic(menuMusic);
    }

    public void PlayLevelMusic()
    {
        PlayMusic(levelMusic);
    }

    public void PlayVictoryMusic()
    {
        PlayMusic(victoryMusic);
    }
    
    public void PlayGameOverMusic()
    {
        PlayMusic(gameoverMusic);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Подписка на событие загрузки сцены
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Отписка от события
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Определяем музыку для текущей сцены
        switch (scene.name)
        {
            case "MainMenu":
                PlayMenuMusic();
                break;
            case "Level1":
            case "Level2":
                PlayLevelMusic();
                break;
            case "Victory":
                PlayVictoryMusic();
                break;
            default:
                Debug.LogWarning("No music assigned for this scene!");
                break;
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp01(volume); // Устанавливаем громкость от 0 до 1
    }


    private void PlayMusic(AudioClip clip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = clip;
        audioSource.Play();
    }
}
