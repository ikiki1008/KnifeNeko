using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmptyWeaponList : MonoBehaviour
{
    [SerializeField] private Image[] timerImages;
    [SerializeField] public TextMeshProUGUI[] timerTexts;

    public TextMeshProUGUI[] ShowWeaponLevels() {
        return timerTexts;
    }

    public void WeaponLevelUp(string weapon)
    {
        int index = GetWeaponIndex(weapon);
        if (index != -1)
        {
            int currentLevel = int.Parse(timerTexts[index].text);
            timerTexts[index].text = (currentLevel + 1).ToString();
        }
    }

    public void AddNewWeapon(string newWeapon)
    {
        int index = GetWeaponIndex(newWeapon);
        if (index != -1)
        {
            Sprite weaponSprite = Resources.Load<Sprite>("weapon/" + newWeapon);
            if (weaponSprite != null)
            {
                timerImages[index].sprite = weaponSprite;
                timerTexts[index].text = "1";
            }
            else
            {
                Debug.LogError("Failed to load sprite for weapon: " + newWeapon);
            }
        }
    }

    private int GetWeaponIndex(string weapon)
    {
        switch (weapon)
        {
            case "ninja":
                return 0;
            case "fire":
                return 1;
            case "ice":
                return 2;
            case "log":
                return 3;
            case "thunder":
                return 4;
            default:
                Debug.LogError("Invalid weapon name: " + weapon);
                return -1;
        }
    }
}
