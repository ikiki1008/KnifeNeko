using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpeechManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI bubble;
    [SerializeField] private Image bubbleImage;
    void Start()
    {
        StartCoroutine(Speech(0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Speech(float waitTime) {
        yield return new WaitForSeconds(waitTime);
    }
}
