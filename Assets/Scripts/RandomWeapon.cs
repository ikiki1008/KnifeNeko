using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWeapon : MonoBehaviour
{
    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private Button[] buttons; // 패널에 있는 3개의 버튼 배열

    private List<Sprite> weaponSprites; // weapon 폴더의 스프라이트들을 저장할 리스트
    private List<string> selectedWeaponNames; // 선택된 무기의 이름을 저장할 리스트
    // private bool panelOpen = false;

    public void StartPanel(){
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
        selectedWeaponNames = new List<string>();

        List<Sprite> selectedWeapons = new List<Sprite>();
        while (selectedWeapons.Count < 3){
            Sprite randomWeapon = weaponSprites[Random.Range(0, weaponSprites.Count)];
            if (!selectedWeapons.Contains(randomWeapon)){
                selectedWeapons.Add(randomWeapon);
                selectedWeaponNames.Add(randomWeapon.name);
            }
        }

        for (int i = 0; i < buttons.Length; i++){
            Image buttonImage = buttons[i].GetComponent<Image>();
            buttonImage.sprite = selectedWeapons[i];
        }
    }

    public void OnWeaponButtonClicked(int index){
        string selectedWeaponName = selectedWeaponNames[index];
        Debug.Log("Button " + index + " clicked. Selected weapon: " + selectedWeaponName);
        
        levelUpPanel.SetActive(false); // 패널 비활성화
        ChosenWeapon(selectedWeaponName);
    }

    public void ChosenWeapon(string weaponName)
    {
        Debug.Log("Player Chosen weapon: " + weaponName);

        MonsterSpawner monsterSpawner = FindObjectOfType<MonsterSpawner>();
        Monster monster = FindObjectOfType<Monster>();
        Player player = FindObjectOfType<Player>();
        
        switch (weaponName) {
            case "fire":
                break;
            case "ice":
                break;
            case "ninja":
                break;
            case "log":
                break;
            case "thunder":
                break;
            default:
                break;
        
        }

        // levelUpPanel.SetActive(false);

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
}
