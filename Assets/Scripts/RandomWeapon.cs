using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomWeapon : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private Button[] buttons; // 패널에 있는 3개의 버튼 배열
    [SerializeField] private TextMeshProUGUI[] BtnTexts; // 버튼 텍스트 배열
    [SerializeField] private GameObject weaponListScreen;
    private List<Sprite> weaponSprites; // weapon 폴더의 스프라이트들을 저장할 리스트
    private List<string> selectedWeaponNames; // 선택된 무기의 이름을 저장할 리스트
    private List<string> playerWeaponNames; // 플레이어가 가지고 있는 무기의 이름을 저장할 리스트

    private EmptyWeaponList emptyWeaponList;

    private void Awake() {
        playerWeaponNames = new List<string>(); // 초기화
        selectedWeaponNames = new List<string>();
        emptyWeaponList = FindObjectOfType<EmptyWeaponList>(); // EmptyWeaponList 인스턴스 찾기
    }

    public void StartPanel(){
        AddWeaponToSelectedList("ninja"); // 초기 무기 추가
        LoadWeaponImages();
        SetRandomWeaponImages();
    }

    private void LoadWeaponImages(){
        weaponSprites = new List<Sprite>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("weapon");

        foreach (Sprite sprite in sprites){
            weaponSprites.Add(sprite);
        }

        if (weaponSprites.Count < 3) {
            Debug.LogError("Not enough weapon images found in 'Resources/weapon'.");
        }
    }

    private void SetRandomWeaponImages(){
        selectedWeaponNames.Clear();

        List<Sprite> selectedWeapons = new List<Sprite>();
        while (selectedWeapons.Count < 3){
            Sprite randomWeapon = weaponSprites[Random.Range(0, weaponSprites.Count)];
            if (!selectedWeapons.Contains(randomWeapon)){
                selectedWeapons.Add(randomWeapon);
                selectedWeaponNames.Add(randomWeapon.name);
            }
        }

        bool isSpeed = true; // 스피드와 데미지 텍스트를 번갈아 넣기 위한 변수

        for (int i = 0; i < buttons.Length; i++){
            Image buttonImage = buttons[i].GetComponent<Image>();
            buttonImage.sprite = selectedWeapons[i];

            string weaponName = selectedWeapons[i].name;
            bool hasWeapon = playerWeaponNames.Contains(weaponName);

            //랜덤 이미지로 스타트 무기가 있다면 무조건 스피드 혹은 데미지 업 시키기
            if (!hasWeapon || weaponName == "ninja") {
                if (weaponName == "ninja") { //
                    if (isSpeed) {
                        BtnTexts[i].text = "Speed + 1";
                    } else {
                        BtnTexts[i].text = "Damage + 100";
                    }
                    isSpeed = !isSpeed; // 번갈아가며 텍스트를 변경
                } else {
                    BtnTexts[i].text = "Choose\nnew weapon";
                }
            } else {
                if (isSpeed) {
                    BtnTexts[i].text = "Speed + 1";
                } else {
                    BtnTexts[i].text = "Damage + 100";
                }
                isSpeed = !isSpeed; // 번갈아가며 텍스트를 변경
            }
        }
    }

    public void OnWeaponButtonClicked(int index){
        string selectedWeaponName = selectedWeaponNames[index];
        Debug.Log("Button " + index + " clicked. Selected weapon: " + selectedWeaponName);
        
        levelUpPanel.SetActive(false); // 패널 비활성화
        weaponListScreen.SetActive(true);
        ChosenWeapon(selectedWeaponName);
    }

    public void ChosenWeapon(string weaponName) {
        Debug.Log("Player Chosen weapon: " + weaponName);
        bool isNewWeapon = !playerWeaponNames.Contains(weaponName);
        if (isNewWeapon) {
            emptyWeaponList.AddNewWeapon(weaponName);
        } else {
            emptyWeaponList.WeaponLevelUp(weaponName);
        }

        AddWeaponToSelectedList(weaponName);

        MonsterSpawner monsterSpawner = FindObjectOfType<MonsterSpawner>();
        Monster monster = FindObjectOfType<Monster>();
        Player player = FindObjectOfType<Player>();

        if (player != null){
            switch (weaponName){
                case "fire":
                case "ice":
                case "ninja":
                case "log":
                case "thunder":
                    player.AddNewWeapon(weaponName);
                    break;
                default:
                    Debug.LogError("Invalid weapon name: " + weaponName);
                    return;
            }
        }

        if (monster != null){
            Monster.ResumeMonsters();
        }

        if (player != null){
            player.Stop(false);
        }

        if (monsterSpawner != null){
            monsterSpawner.RestartRoutine();
        }
    }

    private void AddWeaponToSelectedList(string weaponName) {
        if (!playerWeaponNames.Contains(weaponName)) {
            playerWeaponNames.Add(weaponName);
            Debug.Log("Weapon added to selected list: " + weaponName);
        } else {
            Debug.Log("Weapon already in selected list: " + weaponName);
        }
    }
}
