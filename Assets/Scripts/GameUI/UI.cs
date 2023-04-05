using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [HideInInspector]
    public bool gameStarted = false;

    [SerializeField] private TMP_Text count;

    void Start()
    {
        StartCoroutine(CountStart());
    }

    private IEnumerator CountStart()
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
        gameStarted = true;
        yield return new WaitForSeconds(1);
        count.text = "";
    }
}
