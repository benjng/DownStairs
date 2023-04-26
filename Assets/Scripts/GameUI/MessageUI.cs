using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageUI : MonoBehaviour
{
    [SerializeField] private TMP_Text msgText;
    void Start()
    {
        StepsSpawner.PrintFloor += UpdateFloor;
    }

    void OnDestroy() {
        StepsSpawner.PrintFloor -= UpdateFloor;
    }

    void UpdateFloor(){
        msgText.fontSize = 200;
        msgText.color = new Color(msgText.color.r, msgText.color.g, msgText.color.b, 1);
        msgText.text = StepsSpawner.CurrentFloor.ToString() + "/F";
        StartCoroutine(TextFadeOut());
    }

    IEnumerator TextFadeOut(){
        for (int i=0; i<100; i++) {
            msgText.color -= new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
