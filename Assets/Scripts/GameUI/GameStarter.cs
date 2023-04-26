using System.Collections;
using UnityEngine;
using TMPro;

public class GameStarter : MonoBehaviour
{
    public static bool GameStarted = false;

    [SerializeField] private TMP_Text count;

    void Start()
    {
        GameStarted = false;
        StartCoroutine(CountStart());
    }

    IEnumerator CountStart()
    {
        count.fontSize = 700; 
        count.text = "3";
        yield return new WaitForSeconds(1);
        count.text = "2";
        yield return new WaitForSeconds(1);
        count.text = "1";
        yield return new WaitForSeconds(1);
        count.fontSize = 200;
        count.text = "Start!";
        GameStarted = true;
        yield return new WaitForSeconds(1);
        count.text = "";
    }
}
