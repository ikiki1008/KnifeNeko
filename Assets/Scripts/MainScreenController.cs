using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScreenController : MonoBehaviour
{

    [SerializeField] private Button PowerBtn;
    [SerializeField] private Button SettingBtn;
    [SerializeField] private Button PlayBtn;
    [SerializeField] private Button MusicOn;
    [SerializeField] private Button MusicOff;
    [SerializeField] private Button PanelOff;
    [SerializeField] private GameObject SettingPanel;


    public void PowerOnClick() {
        Debug.Log("파워 오프....");
        Application.Quit();
    }

    public void SettingsOnClick() {
        SettingPanel.SetActive(true);
    }

    public void PlayOnClick() {
        SceneManager.LoadScene("InGameScene");
    }

    public void PanelOffClick() {
        SettingPanel.SetActive(false);
    }

    public void MusicOnClick() {

    }

    public void MusicOffClick() {
        
    }
}
