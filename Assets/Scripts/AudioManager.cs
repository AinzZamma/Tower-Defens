using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;

    [System.Serializable]
    public class SceneMusic
    {
        public string sceneName;   // Название сцены
        public AudioClip music;    // Музыка для этой сцены
    }

    public SceneMusic[] sceneMusics; // Массив музыки для сцен

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    private void PlayMusicForScene(string sceneName)
    {
        AudioClip clip = GetMusicForScene(sceneName);
        if (clip != null)
        {
            PlayMusic(clip);
        }
        else
        {
            Debug.LogWarning($"No music assigned for the scene: {sceneName}");
        }
    }

    private AudioClip GetMusicForScene(string sceneName)
    {
        foreach (var sceneMusic in sceneMusics)
        {
            if (sceneMusic.sceneName == sceneName)
            {
                return sceneMusic.music;
            }
        }
        return null; // Если не найдено
    }

    private void PlayMusic(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("Tried to play a null AudioClip.");
            return;
        }

        if (audioSource.isPlaying && audioSource.clip == clip)
        {
            return; // Не перезапускаем ту же музыку
        }

        audioSource.clip = clip;
        audioSource.Play();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp01(volume);
    }
}


