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
    [SerializeField] private TextMeshProUGUI scoreResultText;
    [SerializeField] private Image gameOverImage;
    // [SerializeField] private GameObject winPrefab; // 승리 프리팹
    // [SerializeField] private GameObject losePrefab; // 패배 프리팹
    // [SerializeField] private Transform prefabParent; // 프리팹을 배치할 부모 오브젝트
    [SerializeField] private GameObject WeaponList; //무기 리스트 오브젝트
    private TextMeshProUGUI[] finalLevels;

    private void Start()
    {
        gameOverPanel.SetActive(false); // 패널을 비활성화된 상태로 시작
    }

    public void GameOverResult(bool win)
    {
        MonsterSpawner monsterSpawner = FindObjectOfType<MonsterSpawner>();
        Monster monster = FindObjectOfType<Monster>();
        Player player = FindObjectOfType<Player>();
        EmptyWeaponList emptyWeaponList = FindObjectOfType<EmptyWeaponList>();

        Sprite winImage = Resources.Load<Sprite>("winOrlose/" + "Win");
        Sprite loseImage = Resources.Load<Sprite>("winOrlose/" + "Lose");

        if(monster != null && monsterSpawner != null && player != null && emptyWeaponList != null) {
            Monster.PauseMonsters();  
            monsterSpawner.StopEnemyRoutine();
            player.Stop(true);  
            finalLevels = emptyWeaponList.ShowWeaponLevels();
        }

        //게임 오버 후 각 무기 최종 레벨 구현
        if (finalLevels.Length >= 5) { 
            scoreResultText.SetText(
                "Dagger Level : " + finalLevels[0].text + "\n" +
                "Fire Level : " + finalLevels[1].text + "\n" +
                "Ice Level : " + finalLevels[2].text + "\n" +
                "Tree Level : " + finalLevels[3].text + "\n" +
                "Thunder Level : " + finalLevels[4].text
            );
        }

        if (win){
            gameOverText.SetText("FINISHED \nFIRST STAGE !!");
            if (winImage != null) {
                gameOverImage.sprite = winImage;
            }
            // instance = Instantiate(winPrefab, prefabParent); // 승리 프리팹 생성
        } else {
            gameOverText.SetText("YOU LOSE ...");
            if (loseImage != null) {
                gameOverImage.sprite = loseImage;
            }
            // instance = Instantiate(losePrefab, prefabParent); // 패배 프리팹 생성
        }

        gameOverPanel.SetActive(true);
        WeaponList.SetActive(false);
    }

    public void PlayAgain() 
    {
        gameOverPanel.SetActive(false);
        WeaponList.SetActive(false);
        SceneManager.LoadScene("InGameScene");
    }

    public void Exit() 
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }
}
