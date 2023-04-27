using System.Collections;
using UnityEngine;
using TMPro;

public class GameCounter : MonoBehaviour
{
    public static bool GameStarted = false;

    [SerializeField] private TMP_Text msgText;

    void Start()
    {
        GameStarted = false;
        StepsSpawner.PrintFloor += UpdateFloor;
        StartCoroutine(CountStart());
    }

    void OnDestroy() {
        StepsSpawner.PrintFloor -= UpdateFloor;
    }

    IEnumerator CountStart()
    {
        msgText.fontSize = 700; 
        for (int i = 3; i > 0; i--){
            msgText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        
        msgText.fontSize = 200;
        msgText.text = "Start!";
        GameStarted = true;
        yield return new WaitForSeconds(1);
        msgText.text = "";
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
