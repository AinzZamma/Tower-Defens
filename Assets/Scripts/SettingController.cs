using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        // ������������� ��������� �������� �������� �� ���������� ��������
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 0.5f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);

        // ������������� �� ��������� �������� ��������
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        // ������������� ���������� ���������
        AudioListener.volume = Mathf.Clamp01(volume);

        // ��������� �������� � PlayerPrefs
        PlayerPrefs.SetFloat("GameVolume", volume);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnDestroy()
    {
        // ������������ �� �������, ����� �������� ������ ������
        volumeSlider.onValueChanged.RemoveListener(SetVolume);
    }
}
