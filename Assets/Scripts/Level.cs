using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour{
    [SerializeField]
    private float gameScore;
    [SerializeField]
    private int gameLevel; // int 타입으로 변경
    [SerializeField]
    private GameObject score;
    private List<GameObject> scoreObjects = new List<GameObject>();
    private float[] posX = {-1.94f, -1.44f, -0.94f, -0.44f, 0.054f };
    // private float posY = 4.3f;

    // 각 레벨에 도달하기 위한 점수 임계값 배열
    private int[] levelThresholds = {
        300, 700, 1200, 1800, 2500, 3300, 4200, 5200, 6300, 7500,
        8800, 10200, 11700, 13300, 15000, 16800, 18700, 20700, 22800, 25000
    };

    // Start is called before the first frame update
    void Start() {
        gameScore = 0;
        gameLevel = 1; // 첫 레벨
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void LevelUp() {
        gameLevel++;
        Debug.Log("Game Level: " + gameLevel);
    }

    
    public void AddScore(float score) {
        gameScore += score;
        Debug.Log("Game Score: " + gameScore);

        // 현재 레벨에서 다음 레벨로 올라갈 점수 임계값을 확인
        if (gameLevel < levelThresholds.Length) {
            if (gameScore >= levelThresholds[gameLevel - 1]) {
                LevelUp();
            }
        } else {
            Debug.LogWarning("Level thresholds array length exceeded. Check array length and conditions.");
        }
    }

}