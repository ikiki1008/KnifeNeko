using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject gameOverPanel;
    private float time = 0f;
    private bool isPause = false;

    // Update is called once per frame
    void Update()
    {
        if (levelUpPanel.activeSelf || gameOverPanel.activeSelf) {
            //패널이 열려있는가?
            isPause = true;
        } else {
            isPause = false;
        }
        TimerStart();
    }

    private void TimerStart() {
        if (!isPause) {
            time += Time.deltaTime;
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time % 60f);
            timer.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
        }   
    }
}
