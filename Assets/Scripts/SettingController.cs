using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        // Устанавливаем начальное значение ползунка из сохранённых настроек
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 0.5f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);

        // Подписываемся на изменения значения ползунка
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        // Устанавливаем глобальную громкость
        AudioListener.volume = Mathf.Clamp01(volume);

        // Сохраняем значение в PlayerPrefs
        PlayerPrefs.SetFloat("GameVolume", volume);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnDestroy()
    {
        // Отписываемся от события, чтобы избежать утечек памяти
        volumeSlider.onValueChanged.RemoveListener(SetVolume);
    }
}
