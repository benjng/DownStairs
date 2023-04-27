using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ScoreBoard rendering only (no sorting logics)
public class ScoreBoard : MonoBehaviour
{
    [SerializeField] GameObject[] scoreRows;
    void Start(){
        // Load all current ORDERED PlayerPrefs data into the scoreboard
        foreach (KeyValuePair<string, int> pair in ScoreKeeper.Ranks)
        {
            int i = 0;
            string playerName = pair.Key;
            int playerScore = pair.Value;
            // Do something with the key-value pair
            scoreRows[i].transform.Find("pName").GetComponent<TMP_Text>().text = playerName;
            scoreRows[i].transform.Find("pFloor").GetComponent<TMP_Text>().text = playerScore.ToString();
            i++;
        }
    }
}
