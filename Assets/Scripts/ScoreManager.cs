using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance = null;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int gameScore;
    private int gameLevel; // int 타입으로 변경
    private int currentExperience; // 현재 유저가 쌓은 경험치
    private int[] levelThresholds = {
        300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200
    };
    [SerializeField]
    private GameObject levelUpPanel;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        gameScore = 0;
        gameLevel = 1; // 첫 레벨
        currentExperience = 0;
        UpdateScoreText();
    }

    public void IncreaseScore(int score)
    {
        currentExperience += score;
        gameScore += score;

        Debug.Log("Game Score: " + gameScore);

        if (gameLevel <= levelThresholds.Length)
        {
            if (currentExperience >= levelThresholds[gameLevel - 1])
            {
                LevelUp();
            }
        }
        else
        {
            Debug.LogWarning("Level thresholds array length exceeded. Check array length and conditions.");
        }

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        int requiredExperience = 0;
        if (gameLevel < levelThresholds.Length)
        {
            requiredExperience = levelThresholds[gameLevel - 1];
        }

        scoreText.SetText(currentExperience.ToString() + " / " + requiredExperience.ToString() + "\nLevel: " + gameLevel.ToString());
    }

    private void LevelUp(){
        gameLevel++;
        currentExperience = 0; // 레벨업 후 경험치 초기화
        SetGameStop();
        Debug.Log("Game Level: " + gameLevel);
    }

    private void SetGameStop() {
        MonsterSpawner monsterSpawner = FindObjectOfType<MonsterSpawner>();
        Monster monster = FindObjectOfType<Monster>();
        Player player = FindObjectOfType<Player>();

        if (monster != null) {
            Monster.PauseMonsters();  
        }
        if (monsterSpawner != null) {
            monsterSpawner.StopEnemyRoutine();
        }
        if (player != null) {
            player.Stop(true);
        }

        ShowLevelUpPanel();
    }

    private void ShowLevelUpPanel() {
        RandomWeapon randomWeapon = FindObjectOfType<RandomWeapon>();
        levelUpPanel.SetActive(true); //패널 활성화
        randomWeapon.StartPanel();
    }
}
