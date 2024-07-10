using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro; // TextMeshPro 네임스페이스 추가

public class UserNameEdit : MonoBehaviour
{
    [SerializeField] private Button UserNameChangeBtn;
    [SerializeField] private TMP_InputField UserName; // 플레이어 이름 InputField
    private Image userNameChangeButtonImage;
    private Sprite defaultButtonImage;
    private Sprite editButtonImage;
    private bool isEditingUserName = false;

    // Start is called before the first frame update
    void Start()
    {
        UserName.text = "Player_JaneDoe";
        userNameChangeButtonImage = UserNameChangeBtn.GetComponent<Image>();

        defaultButtonImage = userNameChangeButtonImage.sprite;
        editButtonImage = Resources.Load<Sprite>("1x/Unlocked");
        UserName.interactable = false;
        UserName.text = PlayerPrefs.GetString("PlayerName", "Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UserNameEditable(){
        if (isEditingUserName)
        {
            PlayerPrefs.SetString("PlayerName", UserName.text);
            userNameChangeButtonImage.sprite = defaultButtonImage;

            // InputField 비활성화
            UserName.interactable = false;
            isEditingUserName = false;
        }
        else
        {
            UserName.interactable = true;
            // 버튼 이미지 변경
            userNameChangeButtonImage.sprite = editButtonImage;
            isEditingUserName = true;
        }
    }
}
