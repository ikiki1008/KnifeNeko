using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PlayerText;
    [SerializeField] private TextMeshProUGUI CarText;
    [SerializeField] private Image PlayerBubble;
    [SerializeField] private Image CarBubble;

    void Start()
    {
        StartCoroutine(SpeechRoutine());
    }

    IEnumerator SpeechRoutine()
    {
        yield return new WaitForSeconds(2.0f); // 2초 대기 후 실행

        // 이미지를 활성화하고 텍스트 설정
        // 이미지를 반대 방향으로 회전
        CarBubble.gameObject.SetActive(true);
        CarText.text = "Weru done, Nyan";
        yield return new WaitForSeconds(3.0f); // 3초 대기 후 실행
        CarBubble.gameObject.SetActive(false);
        CarText.text = "";

        PlayerBubble.gameObject.SetActive(true);
        PlayerText.text = "Wow!";
        yield return new WaitForSeconds(3.0f); // 3초 대기 후 실행
        PlayerBubble.gameObject.SetActive(false);
        PlayerText.text = "";
    }
}
