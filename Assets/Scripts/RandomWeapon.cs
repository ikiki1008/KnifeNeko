using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject levelUpPanel;
    [SerializeField]
    private Button[] buttons; // 패널에 있는 3개의 버튼 배열

    public void StartPanel()
    {
        SetRandomWeaponImages();
    }

    private void SetRandomWeaponImages()
    {
        GameObject[] weaponPrefabs = Resources.LoadAll<GameObject>("Prefabs");

        List<GameObject> weaponList = new List<GameObject>();
        foreach (GameObject prefab in weaponPrefabs)
        {
            if (prefab.tag == "weapon")
            {
                weaponList.Add(prefab);
            }
        }

        if (weaponList.Count < 3)
        {
            Debug.LogError("Not enough weapon prefabs with 'weapon' tag found.");
            return;
        }

        List<GameObject> selectedWeapons = new List<GameObject>();
        while (selectedWeapons.Count < 3)
        {
            GameObject randomWeapon = weaponList[Random.Range(0, weaponList.Count)];
            if (!selectedWeapons.Contains(randomWeapon))
            {
                selectedWeapons.Add(randomWeapon);
            }
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            Image buttonImage = buttons[i].GetComponent<Image>();
            buttonImage.sprite = selectedWeapons[i].GetComponent<SpriteRenderer>().sprite;

            int index = i; // 클로저 문제를 피하기 위해 인덱스를 로컬 변수로 저장
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => OnWeaponButtonClicked(index));
        }
    }

    private void OnWeaponButtonClicked(int index)
    {
        Debug.Log("Button " + index + " clicked.");
        levelUpPanel.SetActive(false); // 패널 비활성화
        // ChosenWeapon();
    }

    public void ChosenWeapon()
    {
        Debug.Log("click!!!");
        MonsterSpawner monsterSpawner = FindObjectOfType<MonsterSpawner>();
        Monster monster = FindObjectOfType<Monster>();
        Player player = FindObjectOfType<Player>();

        levelUpPanel.SetActive(false);

        if (monster != null)
        {
            Monster.ResumeMonsters();
        }

        if (player != null)
        {
            player.Stop(false);
        }

        if (monsterSpawner != null)
        {
            monsterSpawner.RestartRoutine();
        }
    }
}
