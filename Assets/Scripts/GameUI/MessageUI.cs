using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageUI : MonoBehaviour
{
    [SerializeField] private TMP_Text countText;
    void Start()
    {
        StepsSpawner.PrintFloor += UpdateFloor;
    }

    void UpdateFloor(){
        countText.fontSize = 200;
        countText.color = new Color(countText.color.r, countText.color.g, countText.color.b, 1);
        countText.text = StepsSpawner.CurrentFloor.ToString() + "/F";
        StartCoroutine(TextFadeOut());
    }

    IEnumerator TextFadeOut(){
        for (int i=0; i<100; i++) {
            countText.color -= new Color(0, 0, 0, 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
