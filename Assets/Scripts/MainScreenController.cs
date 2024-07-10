using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainScreenController : MonoBehaviour
{
    [SerializeField] private Button PowerBtn;
    [SerializeField] private Button SettingBtn;
    [SerializeField] private Button PlayBtn;
    [SerializeField] private Button MusicOn;
    [SerializeField] private Button MusicOff;
    [SerializeField] private Button PanelOff;
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private AudioSource backgroundMusic; // 배경 음악 AudioSource


    void Start()
    {
        if (backgroundMusic != null && PlayerPrefs.GetInt("MusicMuted", 0) == 0)
        {
            backgroundMusic.Play();
        }
    }

    public void PowerOnClick()
    {
        Debug.Log("파워 오프....");
        Application.Quit();
    }

    public void SettingsOnClick()
    {
        SettingPanel.SetActive(true);
    }

    public void PlayOnClick()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void PanelOffClick()
    {
        SettingPanel.SetActive(false);
    }

    public void MusicOnClick()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Play(); // 배경 음악 재생
            PlayerPrefs.SetInt("MusicMuted", 0); // 음악 뮤트 상태 해제
        }
    }

    public void MusicOffClick()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop(); // 배경 음악 정지
            PlayerPrefs.SetInt("MusicMuted", 1); // 음악 뮤트 상태 설정
        }
    }
}
