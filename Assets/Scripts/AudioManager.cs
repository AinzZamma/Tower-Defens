using UnityEngine;

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
