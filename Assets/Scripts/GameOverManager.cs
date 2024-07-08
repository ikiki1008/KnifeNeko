using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private Button AgainBtn;
    [SerializeField] private Button ExitBtn;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject winPrefab; // 승리 프리팹
    [SerializeField] private GameObject losePrefab; // 패배 프리팹
    [SerializeField] private Transform prefabParent; // 프리팹을 배치할 부모 오브젝트

    private void Start()
    {
        Debug.Log("Game Over Manager is alive...");
        // playAgainBtn.onClick.AddListener(PlayAgain);
        // exitBtn.onClick.AddListener(Exit);
        gameOverPanel.SetActive(false); // 패널을 비활성화된 상태로 시작
    }

    public void GameOverResult(bool win)
    {
        GameObject instance;
        MonsterSpawner monsterSpawner = FindObjectOfType<MonsterSpawner>();
        Monster monster = FindObjectOfType<Monster>();
        Player player = FindObjectOfType<Player>();

        if(monster != null && monsterSpawner != null && player != null) {
            Monster.PauseMonsters();  
            monsterSpawner.StopEnemyRoutine();
            player.Stop(true);
        }

        if (win)
        {
            gameOverText.SetText("FINISHED FIRST STAGE !!");
            instance = Instantiate(winPrefab, prefabParent); // 승리 프리팹 생성
        }
        else
        {
            gameOverText.SetText("YOU LOSE ...");
            instance = Instantiate(losePrefab, prefabParent); // 패배 프리팹 생성
        }

        // 프리팹의 위치와 스케일 설정
        instance.transform.localPosition = new Vector3(0.71f, -0.31f, 0f);
        instance.transform.localScale = new Vector3(2f, 2f, 2f);

        gameOverPanel.SetActive(true);
    }

    public void PlayAgain() 
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("InGameScene");
    }

    public void Exit() 
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }
}
