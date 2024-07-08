using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 추가

public class LifeWatcher : MonoBehaviour
{
    [SerializeField] private GameObject lifePrefab; // 생명력 이미지 프리팹
    private List<GameObject> lifeObjects = new List<GameObject>(); // 생성된 생명력 이미지 객체 리스트
    [SerializeField] private TextMeshProUGUI hpText; // 생명력을 표시할 텍스트 UI

    // x 좌표
    private float posX = 1.9f;
    // y 좌표
    private float posY = -4.47f;
    // // 텍스트와 하트 객체 사이의 간격
    // private float textOffset = 10f;

    void Start()
    {
        PositionLifeImages();
        InitializeHPText();
    }

    void PositionLifeImages()
    {
        // 생명력 이미지 객체 생성
        GameObject lifeObj = Instantiate(lifePrefab, new Vector2(posX, posY), Quaternion.identity);
        lifeObjects.Add(lifeObj);
    }

    void InitializeHPText()
    {
        // Canvas 찾기 (이미 존재하는 경우에는 생략 가능)
        Canvas canvas = GetComponentInChildren<Canvas>();

        // TextMeshProUGUI 생성 및 설정
        GameObject textObj = new GameObject("HP Text");
        textObj.transform.SetParent(canvas.transform); // Canvas의 자식으로 설정

        UpdateHPText(3000); // 초기 생명력 값 설정 (여기서는 3000으로 초기화)
    }

    public void RemoveLife(float lifeHP)
    {
        if (lifeHP == 0) {
            Debug.Log("player is dead !!");
            PlayerDead();
        }
        // 생명력 텍스트 업데이트
        UpdateHPText(lifeHP);
    }

    void UpdateHPText(float hp)
    {
        hpText.text = hp.ToString(); // 텍스트 업데이트
    }

    private void PlayerDead() {
        GameOverManager gameOverManager = FindObjectOfType<GameOverManager>();
        
        if (gameOverManager != null) {
            gameOverManager.GameOverResult(false);
        }
        Debug.Log("failed loser screen up....");
    }
}
